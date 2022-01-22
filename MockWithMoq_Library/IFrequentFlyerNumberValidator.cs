namespace MockWithMoq_Library;

public interface IFrequentFlyerNumberValidator
{
    bool IsValid(string frequentFlyerNumber);

    void IsValid(string frequentFlyerNumber, out bool isValid);

    //string LicenseKey { get; }
    IServiceInformation ServiceInformation { get; }
}