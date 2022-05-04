using Amazon.Lambda.Core;

/*
1 - install aws cli
2 - install dotnet amazon tools
dotnet tool install -g Amazon.Lambda.Tools
3 - install lambda project template
dotnet new --install Amazon.Lambda.Templates
4 - function name and handler should match the name in image-command aws-lambda-tools-defaults.json
5 - create IAM role in AWS console
6 - create access key id and secret access key to login
7 - login with
aws configure
8 - cd into src folder
9 - deploy with dotnet amazon tools (project name) (add profile and region to .json file or pass it like this --profile --region )
dotnet lambda deploy-function LambdaDemo
10 - wait for push to finish and select IAM role to assign
11 - check it in aws console lambda section
12 - test it in aws console with sample input
*/

// Assembly attribute to enable the Lambda function's JSON input to be converted into a .NET class.
[assembly: LambdaSerializer(typeof(Amazon.Lambda.Serialization.SystemTextJson.DefaultLambdaJsonSerializer))]
namespace LambdaDemo;

public class Function
{
    public Casing FunctionHandler(string input, ILambdaContext context)
    {
        context.Logger.Log($"got new message: {input}"); //log to cloudwatch

        return new Casing(input.ToLower(), input.ToUpper());
    }
}

public record Casing(string Lower, string Upper);