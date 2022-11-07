using MAUI_StackLayout_HeightCalc_Bug.Models;
using System.Reflection;
using System.Text.Json;

namespace MAUI_StackLayout_HeightCalc_Bug;

public partial class MainPage : ContentPage
{
	int count = 0;

	public MainPage()
	{
		InitializeComponent();

        try
        {
            var a = Assembly.GetExecutingAssembly();
            using var stream = a.GetManifestResourceStream("MAUI_StackLayout_HeightCalc_Bug.Models.rankings.json");
            var result = JsonSerializer.DeserializeAsync<List<RankingResult>>(stream,
                new JsonSerializerOptions
                {
                    NumberHandling = System.Text.Json.Serialization.JsonNumberHandling.AllowReadingFromString | System.Text.Json.Serialization.JsonNumberHandling.WriteAsString

                }
                ).Result;

            PlayersListView.ItemsSource = result;
        }
        catch(Exception ex) {
            Console.WriteLine(ex.Message);
        }
    }

	
}

