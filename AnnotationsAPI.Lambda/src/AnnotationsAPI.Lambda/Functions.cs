using Amazon.Lambda.Serialization.SystemTextJson;

[assembly: LambdaSerializer(
	typeof(DefaultLambdaJsonSerializer)
)]

namespace AnnotationsAPI.Lambda;

public class Functions(IConfiguration configuration)
{
	private readonly IConfiguration _configuration = configuration;

	[LambdaFunction]
	[HttpApi(LambdaHttpMethod.Get, "/")]
	public string Default()
	{
		var docs = """
		               Lambda Calculator Home:
		                       You can make the following requests to invoke other Lambda functions perform calculator operations:
		                           /add/{x}/{y}
		                           /subtract/{x}/{y}
		                           /multiply/{x}/{y}
		                           /divide/{x}/{y}
		           """;
		return docs;
	}

	[LambdaFunction]
	[HttpApi(LambdaHttpMethod.Get, "/add/{x}/{y}")]
	public IHttpResult Add(
		[FromServices] IConfiguration configuration,
		int x,
		int y,
		ILambdaContext context
	)
	{
		context.Logger.LogInformation($"{x} plus {y} is {x + y}");
		return HttpResults.Ok((x + y).ToString());
	}

	[LambdaFunction, HttpApi(LambdaHttpMethod.Get, "/subtract/{x}/{y}")]
	public int Subtract(int x, int y, ILambdaContext context)
	{
		context.Logger.LogInformation($"{x} subtract {y} is {x - y}");
		return x - y;
	}

	[LambdaFunction, HttpApi(LambdaHttpMethod.Get, "/multiply/{x}/{y}")]
	public int Multiply(int x, int y, ILambdaContext context)
	{
		context.Logger.LogInformation($"{x} multiply {y} is {x * y}");
		return x * y;
	}

	[LambdaFunction, HttpApi(LambdaHttpMethod.Get, "/divide/{x}/{y}")]
	public int Divide(int x, int y, ILambdaContext context)
	{
		context.Logger.LogInformation($"{x} divide {y} is {x / y}");
		return x / y;
	}
}