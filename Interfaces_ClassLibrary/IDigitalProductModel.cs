namespace Interfaces_ClassLibrary;

public interface IDigitalProductModel : IProductModel
{
    int TotalDownloadsLeft { get; }
}