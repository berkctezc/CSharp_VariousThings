namespace MockWithMoq_Library;

public interface IFrequentFlyerNumberValidator
{
    //string LicenseKey { get; }
    IServiceInformation ServiceInformation { get; }
    bool IsValid(string frequentFlyerNumber);

    void IsValid(string frequentFlyerNumber, out bool isValid);
}
