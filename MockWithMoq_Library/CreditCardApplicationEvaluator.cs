namespace MockWithMoq_Library;

public class CreditCardApplicationEvaluator(IFrequentFlyerNumberValidator validator)
{
	private const int AutoReferralMaxAge = 20;
	private const int HighIncomeThreshold = 100_000;
	private const int LowIncomeThreshold = 20_000;

	private readonly IFrequentFlyerNumberValidator _validator =
		validator ?? throw new ArgumentNullException(nameof(validator));

	public CreditCardApplicationDecision Evaluate(CreditCardApplication application)
	{
		if (application.GrossAnnualIncome >= HighIncomeThreshold)
			return CreditCardApplicationDecision.AutoAccepted;

		if (_validator.ServiceInformation.License.LicenseKey == "EXPIRED")
			return CreditCardApplicationDecision.ReferredToHuman;

		var isValidFrequentFlyerNumber = _validator.IsValid(application.FrequentFlyerNumber);

		if (!isValidFrequentFlyerNumber)
			return CreditCardApplicationDecision.ReferredToHuman;

		if (application.Age <= AutoReferralMaxAge)
			return CreditCardApplicationDecision.AutoDeclined;

		if (application.GrossAnnualIncome < LowIncomeThreshold)
			return CreditCardApplicationDecision.AutoDeclined;

		return CreditCardApplicationDecision.ReferredToHuman;
	}

	//public CreditCardApplicationDecision EvaluateUsingOut(CreditCardApplication application)
	//{
	//    if (application.GrossAnnualIncome >= HighIncomeThreshold)
	//    {
	//        return CreditCardApplicationDecision.AutoAccepted;
	//    }

	//    _validator.IsValid(application.FrequentFlyerNumber, out var isValidFrequentFlyerNumber);

	//    if (!isValidFrequentFlyerNumber)
	//    {
	//        return CreditCardApplicationDecision.ReferredToHuman;
	//    }

	//    if (application.Age <= AutoReferralMaxAge)
	//    {
	//        return CreditCardApplicationDecision.AutoDeclined;
	//    }

	//    if (application.GrossAnnualIncome < LowIncomeThreshold)
	//    {
	//        return CreditCardApplicationDecision.AutoDeclined;
	//    }
	//    return CreditCardApplicationDecision.ReferredToHuman;
	//}
}