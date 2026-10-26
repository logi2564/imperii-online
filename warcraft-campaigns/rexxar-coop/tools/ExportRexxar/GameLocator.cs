using Microsoft.Win32;
namespace RexxarExport;
internal static class GameLocator{
    public static string? Find(){
        var paths=new List<string>{AppContext.BaseDirectory,Environment.CurrentDirectory};
        if(OperatingSystem.IsWindows()){
            foreach(var hive in new[]{RegistryHive.CurrentUser,RegistryHive.LocalMachine})
            foreach(var view in new[]{RegistryView.Registry32,RegistryView.Registry64}){
                try{
                    using var root=RegistryKey.OpenBaseKey(hive,view);
                    using var key=root.OpenSubKey(@"Software\Blizzard Entertainment\Warcraft III",false);
                    foreach(var name in new[]{"InstallPath","InstallPathX","War3Path"}){
                        if(key?.GetValue(name)is string p&&!string.IsNullOrWhiteSpace(p))paths.Add(p.EndsWith(".exe",StringComparison.OrdinalIgnoreCase)?Path.GetDirectoryName(p)!:p);
                    }
                }catch(System.Security.SecurityException){}catch(UnauthorizedAccessException){}catch(IOException){}
            }
            foreach(var root in new[]{Environment.GetFolderPath(Environment.SpecialFolder.ProgramFiles),Environment.GetFolderPath(Environment.SpecialFolder.ProgramFilesX86)}){
                paths.Add(Path.Combine(root,"Warcraft III"));paths.Add(Path.Combine(root,"Warcraft 3"));
            }
        }
        return paths.FirstOrDefault(p=>Directory.Exists(p)&&Exporter.ArchivePriority.Any(a=>File.Exists(Path.Combine(p,a))));
    }
}
