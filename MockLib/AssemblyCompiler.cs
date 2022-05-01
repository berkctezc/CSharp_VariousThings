using System.Reflection;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp;

namespace MockLib;

internal class AssemblyCompiler
{
    private readonly IList<string> _references;

    public AssemblyCompiler()
    {
        _references = new List<string>();
        UseReference<object>();
        UseReference<AssemblyCompiler>();
    }

    internal AssemblyCompiler UseReference<T>()
    {
        _references.Add(typeof(T).GetTypeInfo().Assembly.Location);
        return this;
    }

    public Assembly Compile(string src, string assemblyName)
    {
        var tree = CSharpSyntaxTree.ParseText(src);
        var compilation = CreateCompileOptions(tree, assemblyName);
        return CreateAssembly(compilation);
    }

    private static Assembly CreateAssembly(Compilation compilation)
    {
        var ms = new MemoryStream();
        var result = compilation.Emit(ms);

        if (!result.Success)
        {
            throw new Exception("Compilation failed");
        }

        return Assembly.Load(ms.ToArray());
    }

    private CSharpCompilation CreateCompileOptions(SyntaxTree tree, string assemblyName)
    {
        return CSharpCompilation.Create(
            assemblyName,
            new[] {tree},
            _references.Distinct().Select(x => MetadataReference.CreateFromFile(x)).ToList(),
            new CSharpCompilationOptions(OutputKind.DynamicallyLinkedLibrary));
    }
}