var dockerResults = await Cli.Wrap("docker")
	.WithArguments(new[] {"--version"})
	.ExecuteBufferedAsync();

Console.WriteLine(dockerResults.StandardOutput);

var bat = await Cli.Wrap("demo.bat")
	.ExecuteBufferedAsync();

Console.WriteLine(bat.StandardOutput);

var ps = await Cli.Wrap("powershell")
	.WithArguments(@"./demo.ps1")
	.ExecuteBufferedAsync();

Console.WriteLine(ps.StandardOutput);

var sh = await Cli.Wrap("bash")
	.WithArguments(@"./demo.sh")
	.ExecuteBufferedAsync();

Console.WriteLine(sh.StandardOutput);