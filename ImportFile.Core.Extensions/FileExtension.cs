using Microsoft.AspNetCore.Http;

namespace ImportFile.Core.Extensions
{
    public static class FileExtension
    {
        private const string _Directory = "C:\\ProjetC#\\ASP .NET\\ImportFile\\ImportFile";
        private const string Error = "Impossile de poursuivre l'opreation d'upload du fichier";
        private static readonly List<string> _extensions = new List<string>() { ".xls", ".xlsx" };

        public static bool CheckFileExist(string filePath) 
        {
          return  File.Exists(Path.Combine(_Directory, filePath)) ? true : false;         
        }
        private static async Task MoveFileToDirecrory(IFormFile file, string exactpath)
        {
            using (var stream = new FileStream(exactpath, FileMode.Create))
            {
                await file.CopyToAsync(stream);
            }
        }

        public static async Task<string> WriteFile(IFormFile file)
        {
            var extension = "." + file.FileName.Split('.')[file.FileName.Split('.').Length - 1];
            if (_extensions.Contains(extension))
            {
                var filepath = Path.Combine(_Directory, "Data");

                if (!Directory.Exists(filepath))
                {
                    Directory.CreateDirectory(filepath);
                }

                var exactpath = Path.Combine(_Directory, "Data", file.FileName);

                if (!FileExtension.CheckFileExist(exactpath))
                {
                    await FileExtension.MoveFileToDirecrory(file, exactpath);
                }

                else return FileException.ThrowException(Error, "Le fichier sélectionné a deja été uploadé");
                
                return $"{Path.Combine(Directory.GetCurrentDirectory(), "Data", file.FileName)}";
            }
            else return FileException.ThrowException(Error, "Le format du fichier n'est pas valide");
        }

        public static bool CompareFileContent(string firstPathFile ,string[] path2)
        {

            return true;
        }
    }
}