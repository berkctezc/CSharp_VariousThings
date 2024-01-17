namespace MediatorFromScratch.Lib;

public class Mediator(Func<Type, object> serviceResolver, IDictionary<Type, Type> handlerDetails) : IMediator
{
    public async Task<TResponse> SendAsync<TResponse>(IRequest<TResponse> request)
    {
        var requestType = request.GetType();
        if (!handlerDetails.ContainsKey(requestType)) throw new Exception($"No handler to handle request of type: {requestType}");

        var requestHandlerType = handlerDetails[requestType];
        var handler = serviceResolver(requestHandlerType);

        return await ((Task<TResponse>) handler.GetType().GetMethod("HandleAsync")!
            .Invoke(handler, new[] {request})!)!;
    }
}