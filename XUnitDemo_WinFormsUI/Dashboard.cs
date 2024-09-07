namespace XUnitDemo_WinFormsUI;

public partial class Dashboard : Form
{
	private List<PersonModel> people;

	public Dashboard()
	{
		InitializeComponent();

		RebindDropdown();
	}

	private void RebindDropdown()
	{
		people = DataAccess.GetAllPeople();
		usersDropdown.DataSource = null;
		usersDropdown.DataSource = people;
		usersDropdown.DisplayMember = "FullName";
	}

	private void addPersonButton_Click(object sender, EventArgs e)
	{
		DataAccess.AddNewPerson(
			new PersonModel { FirstName = firstNameText.Text, LastName = lastNameText.Text }
		);

		firstNameText.Text = "";
		lastNameText.Text = "";

		RebindDropdown();
	}

	private void addButton_Click(object sender, EventArgs e)
	{
		resultsText.Text = Calculator
			.Add((double)firstNumberValue.Value, (double)secondNumberValue.Value)
			.ToString();
		firstNumberValue.Value = 0;
		secondNumberValue.Value = 0;
	}

	private void subtractButton_Click(object sender, EventArgs e)
	{
		resultsText.Text = Calculator
			.Subtract((double)firstNumberValue.Value, (double)secondNumberValue.Value)
			.ToString();
		firstNumberValue.Value = 0;
		secondNumberValue.Value = 0;
	}

	private void multiplyButton_Click(object sender, EventArgs e)
	{
		resultsText.Text = Calculator
			.Multiply((double)firstNumberValue.Value, (double)secondNumberValue.Value)
			.ToString();
		firstNumberValue.Value = 0;
		secondNumberValue.Value = 0;
	}

	private void divideButton_Click(object sender, EventArgs e)
	{
		resultsText.Text = Calculator
			.Divide((double)firstNumberValue.Value, (double)secondNumberValue.Value)
			.ToString();
		firstNumberValue.Value = 0;
		secondNumberValue.Value = 0;
	}
}
