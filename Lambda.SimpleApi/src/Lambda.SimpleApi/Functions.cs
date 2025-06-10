/*
 * Created Empty Serverless Lambda
 * setup aws-lambda-tools-defaults.json config
 * cd into project
 * dotnet lambda deploy-function
 * name lambda and give role,  AWSLambdaBasicExecutionRole (6)
 * on aws console go to lambda functions and select your function
 * configure function url
 */

// Assembly attribute to enable the Lambda function's JSON input to be converted into a .NET class.

[assembly: LambdaSerializer(typeof(DefaultLambdaJsonSerializer))]

namespace Lambda.SimpleApi;

public class Functions
{
	/// <summary>
	///     Default constructor that Lambda will invoke.
	/// </summary>
	public Functions()
	{
	}

	/// <summary>
	///     A Lambda function to respond to HTTP Get methods from API Gateway
	/// </summary>
	/// <param name="request"></param>
	/// <returns>The API Gateway response.</returns>
	public APIGatewayProxyResponse Get(APIGatewayProxyRequest request, ILambdaContext context)
	{
		context.Logger.LogInformation("Get Request\n");

		var query = request.QueryStringParameters;

		var rsp = new {query, message = "Hello from Berkc"};

		var response = new APIGatewayProxyResponse
		{
			StatusCode = (int) HttpStatusCode.OK,
			Body = JsonSerializer.Serialize(rsp),
			Headers = new Dictionary<string, string> {{"Content-Type", "text/plain"}}
		};

		return response;
	}
}