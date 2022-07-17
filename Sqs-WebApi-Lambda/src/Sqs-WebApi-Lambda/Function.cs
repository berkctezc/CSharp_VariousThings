[assembly: LambdaSerializer(typeof(Amazon.Lambda.Serialization.SystemTextJson.DefaultLambdaJsonSerializer))]

namespace Sqs_WebApi_Lambda;

public class Function
{
    public static async Task FunctionHandler(SQSEvent @event, ILambdaContext context) => 
        @event.Records.ForEach(e => context.Logger.LogLine($"Processed {e.Body.ToString()}"));
}