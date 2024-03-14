namespace ExceptionsDemo_Library;

public class DemoCode
{
	public int GrandparentMethod(int position)
	{
		int output = default;

		Console.WriteLine("Open DB Conn");

		try
		{
			output = ParentMethod(position);

			//if (position < 0)
			//{
			//    throw new IndexOutOfRangeException("The value must be >=0");
			//}
		}
		catch (Exception ex)
		{
			// Logging Here
			throw new ArgumentException("You passed in bad data", ex);
			// user friendly exception with inner exception and it could be caught later from upper methods
		}
		finally // runs no matter what
		{
			Console.WriteLine("Close DB Conn");
		}

		return output;
	}


	public int ParentMethod(int position)
	{
		return GetNumber(position);
	}

	public int GetNumber(int position)
	{
		var numbers = new[] {1, 4, 7, 2};
		var output = numbers[position];
		return output;
	}
}
