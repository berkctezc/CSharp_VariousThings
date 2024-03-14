namespace MediatorFromScratch.Lib;

public interface IMediator
{
	Task<TResponse> SendAsync<TResponse>(IRequest<TResponse> request);
}
