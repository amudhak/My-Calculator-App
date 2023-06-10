using System.Data;
namespace CalculatorApp;

public partial class MainPage : ContentPage
{
	private string current;
	private bool b;

	public MainPage()
	{
		InitializeComponent();
	}

	void OnClearClicked(object sender, EventArgs e)
	{
		label1.Text = "";
		current = "";
		b = true;
    }

    void OnClicked(object sender, EventArgs e)
	{
		if (b == true)
		{
            current += (sender as Button).Text;
            label1.Text = current;
			if (current.Length >= 8)
			{
				b = false;
			}
        }
		
    }

	void calculate(object sender, EventArgs e)
	{
        String formattedCalculation = current.ToString().Replace("x", "*");

        try
		{
            label1.Text = new DataTable().Compute(formattedCalculation, null).ToString();
            current = label1.Text;
        }
		catch (Exception)
		{
            label1.Text = "";
            current = "";
			b = true;
		}
	}
}