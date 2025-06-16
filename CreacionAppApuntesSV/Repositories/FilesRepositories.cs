using System;
using System.IO;
using System.Threading.Tasks;

namespace CreacionAppApuntesSV.Repositories
{
    internal class FilesRepositories
    {
        private string filePath = Path.Combine(FileSystem.AppDataDirectory, "archivo1.txt");

        public async Task<bool> GenerarArchivo(string texto)
        {
            try
            {
                await File.WriteAllTextAsync(filePath, texto);
                return File.Exists(filePath);
            }
            catch
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
            catch (Exception ex)
            {
                return $"Error al leer archivo: {ex.Message}";
            }
        }
    }
}
IReadOnlyCollection de errores en files repositories