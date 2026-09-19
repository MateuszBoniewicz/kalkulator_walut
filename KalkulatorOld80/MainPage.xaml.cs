using KalkulatorOld80;
using System.Xml.Linq;

namespace KalkulatorOld80
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
        }

        private async void btnOProgramie_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushModalAsync(new OProgramiePage());
        }
        private async void btnPomoc_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushModalAsync(new PomocPage());
        }
        private async void Grid_Loaded(object sender, EventArgs e)
        {
            var listonosz = new HttpClient();
            string dane;
            try
            {
                dane = await listonosz.GetStringAsync(DaneKonfiguracyjne.adresLastA);
            }
            catch (Exception ex)
            {
                await DisplayAlert("Błąd", "Nie można pobrać danych z NBP: " + ex.Message, "OK");
                return;
            }

            if (dane == null || dane == "")
            {
                //komunikat o błędzie
                return;
            }

            var daneXml = XDocument.Parse(dane);
            var tylkoElementyPozycja = daneXml.Descendants("pozycja");
            //var jednaWalutaXml = tylkoElementyPozycja.FirstOrDefault();

            //obiekt waluty klasy PozycjaTabeliA
            //var obiektWaluty = new PozycjaTabeliA
            //{
            // kod_waluty =jednaWalutaXml.Element("kod_waluty").Value,
            // kurs_sredni = jednaWalutaXml.Element("kurs_sredni").Value,
            //nazwa_waluty = jednaWalutaXml.Element("nazwa_waluty").Value,
            //  przelicznik = jednaWalutaXml.Element("przelicznik").Value,
            //};
            var listaWalut = new List<PozycjaTabeliA>();
            //listaWalut.Add(obiektWaluty);
            //biblioteka Linq
            listaWalut = (from item in tylkoElementyPozycja
                          select new PozycjaTabeliA
                          {
                              //tu dla każdego "item-a" ==> obiekt klasy PozycjaTabeliA
                              kod_waluty = item.Element("kod_waluty").Value,
                              kurs_sredni = item.Element("kurs_sredni").Value,
                              nazwa_waluty = item.Element("nazwa_waluty").Value,
                              przelicznik = item.Element("przelicznik").Value,
                          }
                ).ToList();
            var plny = new PozycjaTabeliA
            {
                kod_waluty = "PLN",
                kurs_sredni = "1,0000",
                nazwa_waluty = "polski złoty",
                przelicznik = "1"
            };

            lbxZWaluty.ItemsSource = listaWalut;
            lbxNaWalute.ItemsSource = listaWalut;
            lbxZWaluty.SelectedItem = lbxNaWalute.SelectedItem = listaWalut[0];
        }

        private void Grid_Loaded_1(object sender, EventArgs e)
        {

        }

        private void txtKwota_TextChanged(object sender, TextChangedEventArgs e)
        {
            Przelicz();
        }
        private void przeliczKwoty(object sender, SelectionChangedEventArgs e)
        {
            Przelicz();
        }
        private void Przelicz()
        {
            decimal kwota, kurs, kursNa;

            var daneZWaluty = lbxZWaluty.SelectedItem as PozycjaTabeliA;
            var daneNaWalute = lbxNaWalute.SelectedItem as PozycjaTabeliA;

            string wynik = "";

            if (daneZWaluty != null && daneNaWalute != null)
            {// użytkownik  ne wbyrał waluty
                if (decimal.TryParse(txtKwota.Text, out kwota))
                    if (decimal.TryParse(daneZWaluty.kurs_sredni, out kurs))
                    {
                        kwota = kwota * kurs;
                        if (decimal.TryParse(daneNaWalute.kurs_sredni, out kursNa))
                        {
                            if (kurs != 0)
                            {
                                wynik = $"{kwota / kursNa:N2}";
                            }
                        }
                    }
            }
            else
            {//nic nie wybrał
                wynik = "Jakie waluty?";
            }
            tbPrzeliczona.Text = wynik;
        }


    }
}