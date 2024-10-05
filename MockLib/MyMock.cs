using TypeInfo = System.Reflection.TypeInfo;

namespace MockLib;

public class MyMock<TMockable>
    where TMockable : class
{
    private readonly Dictionary<string, Func<object>> _methodInterceptors = new();
    private readonly TypeInfo _type = typeof(TMockable).GetTypeInfo();

    public TMockable Object =>
        (TMockable)Activator.CreateInstance(CreateType(), _methodInterceptors)!;

    public MyMock<TMockable> MockMethod<TResult>(
        Expression<Func<TMockable, TResult>> methodCall,
        TResult result
    )
    {
        var method = (MethodCallExpression)methodCall.Body;
        var methodName = method.Method.Name;
        _methodInterceptors[methodName] = () => result!;
        return this;
    }

    private Type CreateType()
    {
        var typeToCreate = typeof(TMockable);
        var sourceCode = new StringBuilder();
        var newTypeName = $"{_type.Name}Proxy";
        var typeFullName = GetTypeFullname(typeToCreate);

        var referenceTypes = GetMockableMethods()
            .Select(x => x.ReturnType)
            .Concat(
                GetMockableMethods()
                    .SelectMany(xx => xx.GetParameters().Select(aa => aa.ParameterType))
            );

        sourceCode.AppendLine("using System;");
        sourceCode.AppendLine("using System.Collections.Generic;");
        sourceCode.AppendLine("using System.Collections.Generic;");
        sourceCode.AppendLine($"using {typeToCreate.Namespace};");
        sourceCode.AppendLine($"using {GetType().Namespace};");

        referenceTypes
            .Select(x => x.Namespace)
            .Distinct()
            .ToList()
            .ForEach(x => sourceCode.AppendLine($"using {x!};"));

        sourceCode.AppendLine($"public class {newTypeName} : {typeFullName} {{");
        sourceCode.AppendLine(
            "private readonly Dictionary<string, Func<object>> _methodInterceptors;"
        );
        sourceCode.AppendLine(
            $"public {newTypeName}(Dictionary<string, Func<object>> methodInterceptors) {{ _methodInterceptors = methodInterceptors; }}"
        );
        sourceCode.AppendLine(
            "public object InterceptMethod(string methodName) { if (!_methodInterceptors.ContainsKey(methodName)) { throw new NotImplementedException(); } return _methodInterceptors[methodName](); }"
        );

        foreach (var mockableMethod in GetMockableMethods())
            WriteMethod(mockableMethod, sourceCode);

        sourceCode.AppendLine("}");

        var compiler = new AssemblyCompiler().UseReference<TMockable>();

        var assembly = compiler.Compile(sourceCode.ToString(), newTypeName);

        return assembly.ExportedTypes.First();
    }

    private void WriteMethod(MethodInfo mockableMethod, StringBuilder sourceCode)
    {
        var returnType = mockableMethod.ReturnType;
        var returnTypeName = returnType == typeof(void) ? "void" : returnType.Name;
        var methodName = mockableMethod.Name;
        var typeCode = Type.GetTypeCode(mockableMethod.ReturnType);

        sourceCode.AppendLine($"public {returnTypeName} {methodName} (");

        var i = 0;

        foreach (var parameter in mockableMethod.GetParameters())
            sourceCode.AppendLine(
                $"{(i++ > 0 ? "," : string.Empty)}{parameter.ParameterType.Name} {parameter.Name}"
            );

        sourceCode.AppendLine(") { ");
        sourceCode.AppendLine($"var result = InterceptMethod(\"{methodName}\");");

        if (typeCode == TypeCode.Object && returnTypeName != "void")
            sourceCode.AppendLine($"return result as {returnTypeName};");
        else
            sourceCode.AppendLine($"return ({returnTypeName})result;");

        sourceCode.AppendLine("}");
    }

    private IEnumerable<MethodInfo> GetMockableMethods()
    {
        return _type.GetMethods().Where(x => x.IsAbstract || x.IsVirtual);
    }

    private string GetTypeFullname(Type type)
    {
        var nameBuilder = type.Name;
        var current = type;

        while (current.DeclaringType != null)
        {
            nameBuilder = $"{current.DeclaringType.Name}.{nameBuilder}";
            current = current.DeclaringType;
        }

        return nameBuilder;
    }
}
