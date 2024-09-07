namespace MediatorFromScratch.ConsoleUI;

public class PrintToConsole
{
	public record Request(string Text) : IRequest<bool>;

	public class Handler : IHandler<Request, bool>
	{
		public Task<bool> HandleAsync(Request request)
		{
			Console.WriteLine(request.Text);
			return Task.FromResult(true);
		}
	}
}
