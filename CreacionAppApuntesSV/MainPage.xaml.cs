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
        string texto = await _filesRepository.DevuelveInformacionArchivo();
        LabelArchivo.Text = texto;
    }

    private async void BtnGuardarArchivo_Clicked(object sender, EventArgs e)
    {
        string texto = TxtArchivo.Text;
        if (!string.IsNullOrWhiteSpace(texto))
        {
            bool resultado = await _filesRepository.GenerarArchivo(texto);
            if (resultado)
            {
                await DisplayAlert("Éxito", "El archivo fue guardado.", "OK");
                CargarInformacionArchivo();
            }
            else
            {
                await DisplayAlert("Error", "No se pudo guardar el archivo.", "OK");
            }
        }
    }
}
