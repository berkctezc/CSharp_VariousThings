namespace MockWithMoq_Library;

public class FrequentFlyerNumberValidator : IFrequentFlyerNumberValidator
{
    public bool IsValid(string frequentFlyerNumber)
    {
        throw new NotImplementedException("Simulate");
    }

    public void IsValid(string frequentFlyerNumber, out bool isValid)
    {
        throw new NotImplementedException("Simulate");
    }

    public IServiceInformation ServiceInformation => throw new NotImplementedException();

    //public string LicenseKey{get{throw new NotImplementedException("For demo")}
}