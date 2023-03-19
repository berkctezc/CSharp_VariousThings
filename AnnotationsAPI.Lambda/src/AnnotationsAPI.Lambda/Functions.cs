[assembly: LambdaSerializer(typeof(Amazon.Lambda.Serialization.SystemTextJson.DefaultLambdaJsonSerializer))]

namespace AnnotationsAPI.Lambda;

/// <summary>
/// A collection of sample Lambda functions that provide a REST api for doing simple math calculations.
/// </summary>
public class Functions
{
    private readonly IConfiguration _configuration;

    public Functions(IConfiguration configuration)
    {
        _configuration = configuration;
    }

    /// <summary>
    /// Root route that provides information about the other requests that can be made.
    /// </summary>
    /// <returns>API descriptions.</returns>
    [LambdaFunction]
    [HttpApi(LambdaHttpMethod.Get, "/")]
    public static string Default()
    {
        var docs = @"Lambda Calculator Home:
You can make the following requests to invoke other Lambda functions perform calculator operations:
/add/{x}/{y}
/subtract/{x}/{y}
/multiply/{x}/{y}
/divide/{x}/{y}
";
        return docs;
    }

    [LambdaFunction]
    [HttpApi(LambdaHttpMethod.Get, "/add/{x}/{y}")]
    public static IHttpResult Add([FromServices] IConfiguration configuration, int x, int y, ILambdaContext context)
    {
        context.Logger.LogInformation($"{x} plus {y} is {x + y}");
        return HttpResults.Ok((x + y).ToString());
    }

    [LambdaFunction]
    [HttpApi(LambdaHttpMethod.Get, "/subtract/{x}/{y}")]
    public static int Subtract(int x, int y, ILambdaContext context)
    {
        context.Logger.LogInformation($"{x} subtract {y} is {x - y}");
        return x - y;
    }

    [LambdaFunction]
    [HttpApi(LambdaHttpMethod.Get, "/multiply/{x}/{y}")]
    public static int Multiply(int x, int y, ILambdaContext context)
    {
        context.Logger.LogInformation($"{x} multiply {y} is {x * y}");
        return x * y;
    }

    [LambdaFunction]
    [HttpApi(LambdaHttpMethod.Get, "/divide/{x}/{y}")]
    public static int Divide(int x, int y, ILambdaContext context)
    {
        context.Logger.LogInformation($"{x} divide {y} is {x / y}");
        return x / y;
    }
}