namespace DynamoDb_MovieRank.IntegrationTests.Setup;

public class TestDataSetup
{
	private static readonly IAmazonDynamoDB DynamoDBClient = new AmazonDynamoDBClient(
		new AmazonDynamoDBConfig {ServiceURL = "http://localhost:8000"}
	);

	public async Task CreateTable()
	{
		var request = new CreateTableRequest
		{
			AttributeDefinitions =
			[
				new AttributeDefinition {AttributeName = "UserId", AttributeType = "N"},
				new AttributeDefinition {AttributeName = "MovieName", AttributeType = "S"}
			],
			KeySchema =
			[
				new KeySchemaElement {AttributeName = "UserId", KeyType = "HASH"},
				new KeySchemaElement {AttributeName = "MovieName", KeyType = "RANGE"}
			],
			ProvisionedThroughput = new ProvisionedThroughput
			{
				ReadCapacityUnits = 1,
				WriteCapacityUnits = 1
			},
			TableName = "MovieRank",

			GlobalSecondaryIndexes =
			[
				new GlobalSecondaryIndex
				{
					IndexName = "MovieName-index",
					KeySchema = new List<KeySchemaElement>
					{
						new() {AttributeName = "MovieName", KeyType = "HASH"}
					},
					ProvisionedThroughput = new ProvisionedThroughput
					{
						ReadCapacityUnits = 1,
						WriteCapacityUnits = 1
					},
					Projection = new Projection {ProjectionType = "ALL"}
				}
			]
		};

		await DynamoDBClient.CreateTableAsync(request);
		await WaitUntilTableActive(request.TableName);
	}

	private static async Task WaitUntilTableActive(string tableName)
	{
		string? status = null;
		do
		{
			Thread.Sleep(1000);
			try
			{
				status = await GetTableStatus(tableName);
			}
			catch (ResourceNotFoundException)
			{
				// DescribeTable is eventually consistent. So you might
				// get resource not found. So we handle the potential exception.
			}
		} while (status != "ACTIVE");
	}

	private static async Task<string> GetTableStatus(string tableName)
	{
		var response = await DynamoDBClient.DescribeTableAsync(
			new DescribeTableRequest {TableName = tableName}
		);

		return response.Table.TableStatus;
	}
}