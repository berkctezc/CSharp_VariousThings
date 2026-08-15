namespace CSv11;

public static class GenericsOnAttributes
{
	[Validator<UserValidator>]
	public record User;

	[AttributeUsage(AttributeTargets.All)]
	public class ValidatorAttribute<TValidator> : Attribute
		where TValidator : IValidator
	{
		public ValidatorAttribute()
		{
			ValidatorType = typeof(TValidator);
		}

		public Type ValidatorType { get; }
	}

	public interface IValidator
	{
	}

	private sealed record UserValidator : IValidator;
}