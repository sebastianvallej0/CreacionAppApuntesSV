using System.Threading.Tasks;
using CreacionAppApuntesSV.Repositories;

namespace CreacionAppApuntesSV
{
    public partial class MainPage : ContentPage
    {
       
        private FilesRepositories _filesRepository;
        public MainPage()
        {
            _filesRepository=new FilesRepositories();
            InitializeComponent();
        }
        private async Task CargarInformacionArchivo()
        {
            string texto = await _filesRepository.DevuelveInformacionArchivo();
            LableArchivo.Text= texto;
        }
        private void BtnGuardarArchivo_Clicked(object sender, EventArgs e)
        {

        }
        
    }

}
