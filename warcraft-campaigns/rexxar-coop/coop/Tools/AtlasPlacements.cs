using System.Numerics;
using System.Text;
using System.Text.Json;
using War3Net.Build;
using War3Net.Build.Common;
using War3Net.Build.Extensions;
using War3Net.Build.Widget;

internal static class AtlasPlacements {
    static int Raw(string s)=>BitConverter.ToInt32(Encoding.ASCII.GetBytes(s));
    public static void Run(string inputs,string planFile,string infoFile,string output) {
        using var plan=JsonDocument.Parse(File.ReadAllText(planFile));Directory.CreateDirectory(output);
        using var infoStream=File.OpenRead(infoFile);using var infoReader=new BinaryReader(infoStream);
        var info=infoReader.ReadMapInfo();info.UpgradeData.Clear();info.TechData.Clear();info.RandomItemTables!.Clear();info.RandomUnitTables!.Clear();
        MapDoodads? doodads=null;MapUnits? units=null;int clipped=0;
        foreach(var zone in plan.RootElement.EnumerateObject()) {
            var z=zone.Value;
            var map=Map.Open(Path.Combine(inputs,zone.Name+".w3x"),MapFiles.Info|MapFiles.Units|MapFiles.Doodads);
            int Replace(int id,string? kind=null){string raw=Encoding.ASCII.GetString(BitConverter.GetBytes(id));
                if(kind is not null&&z.GetProperty("kindMaps").TryGetProperty(kind,out var table)&&table.TryGetProperty(raw,out var specific))return Raw(specific.GetString()!);
                return z.GetProperty("rawMap").TryGetProperty(raw,out var v)?Raw(v.GetString()!):id;}
            float dx=z.GetProperty("dx").GetSingle(),dy=z.GetProperty("dy").GetSingle();
            int left=z.GetProperty("cropLeft").GetInt32(),bottom=z.GetProperty("cropBottom").GetInt32(),width=z.GetProperty("cropWidth").GetInt32(),height=z.GetProperty("cropHeight").GetInt32();
            float minX=z.GetProperty("sourceX").GetSingle()+left*128,minY=z.GetProperty("sourceY").GetSingle()+bottom*128;
            bool Inside(float x,float y)=>x>=minX&&y>=minY&&x<=minX+width*128&&y<=minY+height*128;
            var itemTables=new Dictionary<int,int>();
            foreach(var table in map.Info!.RandomItemTables!) {
                int old=table.Index;table.Index=info.RandomItemTables.Count;itemTables[old]=table.Index;table.Name=zone.Name+": "+table.Name;
                foreach(var set in table.ItemSets)foreach(var item in set.Items)item.ItemId=Replace(item.ItemId);
                info.RandomItemTables.Add(table);
            }
            foreach(var table in map.Info.RandomUnitTables!) {
                table.Index=info.RandomUnitTables.Count;table.Name=zone.Name+": "+table.Name;
                foreach(var set in table.UnitSets)for(int n=0;n<set.UnitIds.Length;n++)set.UnitIds[n]=Replace(set.UnitIds[n]);
                info.RandomUnitTables.Add(table);
            }
            void Widget(WidgetData w,string kind) {
                w.TypeId=Replace(w.TypeId,kind);w.SkinId=w.TypeId;w.Position+=new Vector3(dx,dy,0);
                if(itemTables.TryGetValue(w.MapItemTableId,out int itemTable))w.MapItemTableId=itemTable;
                foreach(var set in w.ItemTableSets)foreach(var item in set.Items)item.ItemId=Replace(item.ItemId);
            }
            if(map.Doodads is not null) {
                doodads??=new MapDoodads(map.Doodads.FormatVersion,map.Doodads.SubVersion,false){SpecialDoodadVersion=map.Doodads.SpecialDoodadVersion};
                foreach(var d in map.Doodads.Doodads) {
                    if(!Inside(d.Position.X,d.Position.Y)){clipped++;continue;}
                    Widget(d,"doodad");d.CreationNumber=doodads.Doodads.Count;doodads.Doodads.Add(d);
                }
                foreach(var d in map.Doodads.SpecialDoodads) {
                    if(d.Position.X<left||d.Position.Y<bottom||d.Position.X>left+width||d.Position.Y>bottom+height){clipped++;continue;}
                    d.TypeId=Replace(d.TypeId);d.Position=new System.Drawing.Point(d.Position.X+z.GetProperty("atlasX").GetInt32()-left,d.Position.Y+z.GetProperty("atlasY").GetInt32()-bottom);doodads.SpecialDoodads.Add(d);
                }
            }
            if(map.Units is not null) {
                units??=new MapUnits(map.Units.FormatVersion,map.Units.SubVersion,false);
                foreach(var u in map.Units.Units) {
                    if(u.TypeId==Raw("sloc"))continue; // One lobby, not seventeen sets of editor start markers.
                    if(!Inside(u.Position.X,u.Position.Y))throw new InvalidDataException("Playable unit clipped: "+zone.Name+" "+u.TypeId);
                    Widget(u,"unit");u.CreationNumber=units.Units.Count;
                    if(z.GetProperty("owners").TryGetProperty(u.OwnerId.ToString(),out var owner))u.OwnerId=owner.GetInt32();
                    units.Units.Add(u);
                }
            }
        }
        foreach(var p in info.Players.Where(p=>p.Id<4))units!.Units.Add(new UnitData {
            TypeId=Raw("sloc"),SkinId=Raw("sloc"),OwnerId=p.Id,
            Position=new Vector3(p.StartPosition,0),Scale=Vector3.One,CreationNumber=units.Units.Count
        });
        using var doodadStream=File.Create(Path.Combine(output,"war3map.doo"));
        using var doodadWriter=new BinaryWriter(doodadStream);doodadWriter.Write(doodads!);
        using var unitStream=File.Create(Path.Combine(output,"war3mapUnits.doo"));
        using var unitWriter=new BinaryWriter(unitStream);unitWriter.Write(units!);
        using var outputInfoStream=File.Create(Path.Combine(output,"war3map.w3i"));
        using var infoWriter=new BinaryWriter(outputInfoStream);infoWriter.Write(info);
        Console.WriteLine($"PASS: merged {units!.Units.Count} units, {doodads!.Doodads.Count} doodads, {doodads.SpecialDoodads.Count} special doodads; clipped only {clipped} decorations in unplayable outer padding; random tables independently remapped.");
    }
}
