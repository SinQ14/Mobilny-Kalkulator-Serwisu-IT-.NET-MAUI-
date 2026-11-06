namespace kupamaui
{
    public partial class MainPage : ContentPage
    {
        int count = 0;

        public MainPage()
        {
            InitializeComponent();
        }
        private void btnOblicz(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(klient.Text) || string.IsNullOrWhiteSpace(urzadzenie.Text))
            {
                lblPodsumowanie.TextColor = Colors.Red;
                lblPodsumowanie.Text = "Wypelnij dane klienta i urzadzenia";
                return;
            }
            double cena = 0;

            if (diagnostyka.IsChecked)
            {
                cena = 100;
            }
            else if (system.IsChecked)
            {
                cena = 150;
            }
            else if (plyta.IsChecked)
            {
                cena = 250;
            }

            if (backup.IsChecked)
            {
                cena += 80;
            }

            if (pasta.IsChecked)
            {
                cena += 40;
            }

            if (expres.IsToggled)
            {
                cena = cena * 1.5;
            }
            if(!string.IsNullOrWhiteSpace(kodd.Text)) { 
                string kod = kodd.Text.Trim().ToUpper();

                if (kod == "TECHNIK10")
                {
                    cena = cena * 0.9;
                }
            }
            lblPodsumowanie.TextColor = Colors.Black;

            lblPodsumowanie.Text = "Do zaplaty: " + cena.ToString("F2") + " zl";

        }
        private void btnWyczysc(object sender, EventArgs e)
        {
            klient.Text = "";
            urzadzenie.Text = "";
            diagnostyka.IsChecked = true;
            system.IsChecked = false;
            plyta.IsChecked = false;
            backup.IsChecked = false;
            pasta.IsChecked = false;
            expres.IsToggled = false;
            kodd.Text = "";

            lblPodsumowanie.TextColor = Colors.Black;
            lblPodsumowanie.Text = "Wprowadź dane i kliknij Oblicz...";
        }
        private async void btnZatwierdz(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(klient.Text) || string.IsNullOrWhiteSpace(urzadzenie.Text))
            {
                await DisplayAlertAsync("Blad","Wypelnij dane klienta i urzadzenia!","OK");
                return;
            }
            await DisplayAlertAsync("Zlecenie przyjete","Zlecenie serwisowe zostalo przyjete!","OK");
        }

    }
}
