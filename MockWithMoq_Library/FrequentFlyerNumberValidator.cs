using System;

namespace MockWithMoq_Library
{
    /// <summary>
    /// Mock this
    /// </summary>
    public class FrequentFlyerNumberValidator : IFrequentFlyerNumberValidator
    {
        public bool IsValid(string frequentFlyerNumber)
        {
            throw new System.NotImplementedException("Simulate");
        }

        public void IsValid(string frequentFlyerNumber, out bool isValid)
        {
            throw new System.NotImplementedException("Simulate");
        }

        public IServiceInformation ServiceInformation => throw new NotImplementedException();

        //public string LicenseKey{get{throw new NotImplementedException("For demo")}
    }
}