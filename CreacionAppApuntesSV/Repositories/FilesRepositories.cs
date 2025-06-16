using System;
using System.IO;
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
                return File.Exists(filePath);
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
                    return await File.ReadAllTextAsync(filePath);
                }
                return "No existe el archivo.";
            }
            catch (Exception)
            {
                return "Error al leer el archivo.";
            }
        }
    }
}
