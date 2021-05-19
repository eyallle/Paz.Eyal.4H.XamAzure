using Newtonsoft.Json;
using Paz.Eyal._4H.XamAzure.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace Paz.Eyal._4H.XamAzure
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
        }
    }
    private async void Button_Clicked(object sender, EventArgs e)
    {
        List<Studente> elenco = new List<Studente>();
        // elenco.Add(new Studente { Nome = "Eyal", Cognome = "Paz" });
        // elenco.Add(new Studente { Nome = "Zio", Cognome = "Benny" });
        // elenco.Add(new Studente { Nome = "Nonna", Cognome = "Paz" });
        try
        {
            HttpClient client = new HttpClient();
            string response = await client.GetStringAsync("https://flr.azurewebsites.net/studenti");
           elenco = JsonConvert.DeserializeObject<List<Studente>>(response);
        }
        catch (Exception err)
        {
            await DisplayAlert("Ocio!!", err.Message, "Ok");
        }
        lvStudenti.ItemsSource = elenco;
    }
}
