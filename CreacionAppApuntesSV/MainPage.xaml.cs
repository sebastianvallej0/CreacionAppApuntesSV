using CreacionAppApuntesSV.Repositories;

namespace CreacionAppApuntesSV;

public partial class MainPage : ContentPage
{
    private FilesRepositories _filesRepository;

    public MainPage()
    {
        InitializeComponent();
        _filesRepository = new FilesRepositories();
        CargarInformacionArchivo();
    }

    private async void CargarInformacionArchivo()
    {
        var texto = await _filesRepository.DevuelveInformacionArchivo();
        LabelArchivo.Text = texto;
    }

    private async void BtnGuardarArchivo_Clicked(object sender, EventArgs e)
    {
        var texto = TxtArchivo.Text;
        if (!string.IsNullOrWhiteSpace(texto))
        {
            bool guardo = await _filesRepository.GenerarArchivo(texto);
            if (guardo)
            {
                await DisplayAlert("Éxito", "Archivo guardado", "OK");
                CargarInformacionArchivo();
            }
            else
            {
                await DisplayAlert("Error", "No se pudo guardar", "OK");
            }
        }
    }
}
