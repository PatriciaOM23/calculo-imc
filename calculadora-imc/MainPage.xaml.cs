using System.Globalization;

namespace calculadora_imc
{
    public partial class MainPage : ContentPage
    {

        public MainPage()
        {
            InitializeComponent();
        }

        private async void Calculate_Imc(object sender, EventArgs e)
        {


            if (!double.TryParse(pesoEntry.Text, out double peso) ||
            !double.TryParse(alturaEntry.Text, out double altura) ||
            peso <= 0 || altura <= 0)
            {
                await DisplayAlert("Error", "Introduce un peso y una altura válidos", "Ok");
                return;
            }

            double imc = peso / (altura * altura);
            resultLabel.Text = $"Tu IMC es: {imc.ToString("F2")}";

            string categoria;

            if (imc < 18.5)
            {
                categoria = "DELGADO";
                imcImage.Source = "delgado.png";
            }
            else if (imc < 25)
            {
                categoria = "NORMAL";
                imcImage.Source = "normal.png";
            }
            else if (imc < 30)
            {
                categoria = "SOBREPESO";
                imcImage.Source = "sobrepeso.png";
            }
            else
            {
                categoria = "OBESIDAD";
                imcImage.Source = "obesidad.png";
            }

            categoryLabel.Text = $"Categoría: {categoria}";
            imcImage.IsVisible = true;
        }
    }

}
