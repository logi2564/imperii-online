using CSharpLua;
using War3Net.CodeAnalysis.Jass;
using War3Net.CodeAnalysis.Transpilers;
var root=args[0];var libs=args[1];var source="globals\n"+File.ReadAllText(Path.Combine(root,"source/globals.j"))+"\nendglobals\n"+File.ReadAllText(Path.Combine(root,"source/expansion.j"));
var t=new JassToLuaTranspiler{IgnoreComments=true,IgnoreEmptyDeclarations=true,KeepFunctionsSeparated=true};t.RegisterJassFile(JassSyntaxFactory.ParseCompilationUnit(File.ReadAllText(Path.Combine(libs,"common.j"))));t.RegisterJassFile(JassSyntaxFactory.ParseCompilationUnit(File.ReadAllText(Path.Combine(libs,"Blizzard.j"))));var unit=JassSyntaxFactory.ParseCompilationUnit(source);using var writer=new StreamWriter(args[2]);new LuaRenderer(new LuaSyntaxGenerator.SettingInfo{Indent=4},writer).RenderCompilationUnit(t.Transpile(unit));Console.WriteLine("Transpiled actual expansion JASS to Lua for deterministic state tests.");
