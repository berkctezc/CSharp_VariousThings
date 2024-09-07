namespace xUnitTutorial;

public class Calculator
{
	private CalculatorState _state = CalculatorState.Cleared;

	public decimal Value { get; private set; }

	public decimal Add(decimal value)
	{
		_state = CalculatorState.Active;
		return Value += value;
	}

	public decimal Subtract(decimal value)
	{
		_state = CalculatorState.Active;
		return Value -= value;
	}

	public decimal Multiply(decimal value)
	{
		if (Value == 0 && _state == CalculatorState.Cleared)
		{
			_state = CalculatorState.Active;
			return Value = value;
		}

		return Value *= value;
	}

	public decimal Divide(decimal value)
	{
		if (Value == 0 && _state == CalculatorState.Cleared)
		{
			_state = CalculatorState.Active;
			return Value = value;
		}

		return Value /= value;
	}
}
