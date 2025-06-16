using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CreacionAppApuntesSV.Repositories
{
    internal class FilesRepositories
    {
        private string filePath = FileSystem.AppDataDirectory + "/archivo1.txt";

        public async Task<bool> GenerarArchivo(string texto)
        {
            try
            {
                await File.WriteAllTextAsync(filePath, texto);
                if (File.Exists(filePath))
                {
                    return true;

                }
                return false;
            }

            catch (Exception)
            {
                return false;

            }
        }



        public async Task<string> DevuelveInformacionArchivo()
        {
            try
            {

                if (File.Exists(filePath))
                {
                    string texto = await File.ReadAllTextAsync(filePath);
                    return texto;
                }
                return "No existe el archivo.";
            }

            catch (Exception)
            {
                throw;
            }

        }
    }
}
