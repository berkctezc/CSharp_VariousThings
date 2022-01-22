using Moq;
using Xunit;

namespace MockWithMoq_Library.Tests;

public class CreditCardApplicationEvaluatorShould
{
    [Fact]
    public void AcceptHighIncomeApplications()
    {
        var mockValidator = new Mock<IFrequentFlyerNumberValidator>();

        var sut = new CreditCardApplicationEvaluator(mockValidator.Object);

        var application = new CreditCardApplication() {GrossAnnualIncome = 100_000};

        var decision = sut.Evaluate(application);

        Assert.Equal(CreditCardApplicationDecision.AutoAccepted, decision);
    }

    [Fact]
    public void ReferYoungApplications()
    {
        var mockValidator = new Mock<IFrequentFlyerNumberValidator>();
        mockValidator.DefaultValue = DefaultValue.Mock; // mock if value gets a null or a default value in tests
        mockValidator.Setup(x => x.IsValid(It.IsAny<string>())).Returns(true);

        var sut = new CreditCardApplicationEvaluator(mockValidator.Object);

        var application = new CreditCardApplication() {Age = 18};

        var decision = sut.Evaluate(application);

        Assert.Equal(CreditCardApplicationDecision.AutoDeclined, decision);
    }

    [Fact]
    public void DeclineLowIncomeApplications()
    {
        var mockValidator = new Mock<IFrequentFlyerNumberValidator>();

        mockValidator.Setup(x => x.ServiceInformation.License.LicenseKey).Returns("OK");

        //// Argument Matching
        //mockValidator.Setup(x => x.IsValid("x")).Returns(true); // When this parameter is passed should return ...
        //mockValidator.Setup(x => x.IsValid(It.IsAny<string>())).Returns(true); // if parameter is anything of this type should return ...
        //mockValidator.Setup(x => x.IsValid(It.Is<string>(number => number.StartsWith("y")))).Returns(true); // parameter starts with y
        //mockValidator.Setup(x => x.IsValid(It.IsInRange<string>("a", "z", Moq.Range.Inclusive))).Returns(true); // parameter is in range inclusive or exclusive
        //mockValidator.Setup(x => x.IsValid(It.IsIn<string>("a", "z", "x"))).Returns(true); // is parameter any of the parameters

        mockValidator.Setup(x => x.IsValid(It.IsRegex("[a-z]"))).Returns(true); // is parameter matches regex

        var sut = new CreditCardApplicationEvaluator(mockValidator.Object);

        var application = new CreditCardApplication()
        {
            GrossAnnualIncome = 19_999,
            Age = 42,
            FrequentFlyerNumber = "x"
        };

        var decision = sut.Evaluate(application);

        Assert.Equal(CreditCardApplicationDecision.AutoDeclined, decision);
    }

    [Fact]
    public void ReferInvalidFrequentFlyerApplication()
    {
        //Strict behaviour needs to be setup
        //var mockValidator = new Mock<IFrequentFlyerNumberValidator>(MockBehavior.Strict);
        var mockValidator = new Mock<IFrequentFlyerNumberValidator>();

        mockValidator.Setup(x => x.ServiceInformation.License.LicenseKey).Returns("OK");

        mockValidator.Setup(x => x.IsValid(It.IsAny<string>())).Returns(false);

        var sut = new CreditCardApplicationEvaluator(mockValidator.Object);

        var application = new CreditCardApplication();

        var decision = sut.Evaluate(application);

        Assert.Equal(CreditCardApplicationDecision.ReferredToHuman, decision);
    }

    //[Fact]
    //public void DeclineLowIncomeApplicationsOutDemo()
    //{
    //    var mockValidator = new Mock<IFrequentFlyerNumberValidator>();

    //    var sut = new CreditCardApplicationEvaluator(mockValidator.Object);

    //    bool isValid = true;
    //    mockValidator.Setup(x => x.IsValid(It.IsAny<string>(), out isValid));

    //    var application = new CreditCardApplication()
    //    {
    //        GrossAnnualIncome = 19_999,
    //        Age = 42,
    //    };

    //    var decision = sut.EvaluateUsingOut(application);

    //    Assert.Equal(CreditCardApplicationDecision.AutoDeclined, decision);
    //}

    [Fact]
    public void ReferWhenLicenseKeyExpired()
    {
        //    // chaining mock hierarchy
        //    var mockLicenseData = new Mock<ILicenseData>();
        //    mockLicenseData.Setup(x => x.LicenseKey).Returns("EXPIRED");
        //    var mockServiceInfo = new Mock<IServiceInformation>();
        //    mockServiceInfo.Setup(x => x.License).Returns(mockLicenseData.Object);
        //    var mockValidator = new Mock<IFrequentFlyerNumberValidator>();
        //    mockValidator.Setup(x => x.ServiceInformation).Returns(mockServiceInfo.Object);

        // SHORTER VERSION OF THE CODE ABOVE
        var mockValidator = new Mock<IFrequentFlyerNumberValidator>();
        mockValidator.Setup(x => x.ServiceInformation.License.LicenseKey).Returns("EXPIRED");

        mockValidator.Setup(x => x.IsValid(It.IsAny<string>())).Returns(true);

        var sut = new CreditCardApplicationEvaluator(mockValidator.Object);

        var application = new CreditCardApplication() {Age = 42};

        var decision = sut.Evaluate(application);

        Assert.Equal(CreditCardApplicationDecision.ReferredToHuman, decision);
    }

    public string GetLicenseKeyExpiryString()
    {
        return "EXPIRED";
    }
}