namespace DynamoDb_MovieRank.IntegrationTests.Setup;

public class TestContext : IAsyncLifetime
{
	private const string ContainerImageUri = "amazon/dynamodb-local";
	private readonly DockerClient _dockerClient;
	private string _containerId;

	public TestContext()
	{
		_containerId = string.Empty;
		_dockerClient = new DockerClientConfiguration(new Uri("npipe://./pipe/docker_engine")).CreateClient();
	}

	public async Task InitializeAsync()
	{
		await PullImage();

		await StartContainer();

		await new TestDataSetup().CreateTable();
	}

	public async Task DisposeAsync()
	{
		if (_containerId != null) await _dockerClient.Containers.KillContainerAsync(_containerId, new ContainerKillParameters());
	}

	private async Task PullImage()
	{
		await _dockerClient.Images
			.CreateImageAsync(new ImagesCreateParameters
				{
					FromImage = ContainerImageUri,
					Tag = "latest"
				},
				new AuthConfig(),
				new Progress<JSONMessage>());
	}

	private async Task StartContainer()
	{
		var response = await _dockerClient.Containers.CreateContainerAsync(new CreateContainerParameters
		{
			Image = ContainerImageUri,
			ExposedPorts = new Dictionary<string, EmptyStruct>
			{
				{
					"8000", default
				}
			},
			HostConfig = new HostConfig
			{
				PortBindings = new Dictionary<string, IList<PortBinding>>
				{
					{"8000", new List<PortBinding> {new() {HostPort = "8000"}}}
				},
				PublishAllPorts = true
			}
		});

		_containerId = response.ID;

		await _dockerClient.Containers.StartContainerAsync(_containerId, null);
	}
}
