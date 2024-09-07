namespace MoqDemo_ConsoleUI;

public class Application(IPersonProcessor personProcessor) : IApplication
{
	public void Run()
	{
		IdentifyNextStep();
	}

	private void IdentifyNextStep()
	{
		var selectedAction = "";

		do
		{
			selectedAction = GetActionChoice();

			Console.WriteLine();

			switch (selectedAction)
			{
				case "1":
					DisplayPeople(personProcessor.LoadPeople());
					break;
				case "2":
					AddPerson();
					break;
				case "3":
					Console.WriteLine("Thanks for using this application");
					break;
				default:
					Console.WriteLine("That was an invalid choice. Hit enter and try again.");
					break;
			}

			Console.WriteLine("Hit return to continue...");
			Console.ReadLine();
		} while (selectedAction != "3");
	}

	private void AddPerson()
	{
		Console.Write("What is the person's first name: ");
		var firstName = Console.ReadLine();
		Console.Write("What is the person's last name: ");
		var lastName = Console.ReadLine();
		Console.Write("What is the person's height: ");
		var height = Console.ReadLine();

		var person = personProcessor.CreatePerson(firstName, lastName, height);
		personProcessor.SavePerson(person);
	}

	private void DisplayPeople(List<PersonModel> people)
	{
		foreach (var p in people)
			Console.WriteLine(p.FullName);
	}

	private string GetActionChoice()
	{
		var output = "";

		Console.Clear();
		Console.WriteLine("Menu Options".ToUpper());
		Console.WriteLine("1 - Load People");
		Console.WriteLine("2 - Create and Save Person");
		Console.WriteLine("3 - Exit");
		Console.Write("What would you like to choose: ");
		output = Console.ReadLine();

		return output;
	}
}
