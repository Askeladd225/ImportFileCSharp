using ExcelDataReader;
using ImportFile.Infracstructure.Persistence;
using ImportFile.WebApi.Core.Domain;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using OfficeOpenXml;
using System.Text;

namespace ImportFile.Core.Extensions
{
    public static class FileExtension
    {
        private const string _Directory = "C:\\ProjetC#\\ASP .NET\\ImportFileCsharp\\ImportFile";
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

        public static async Task<bool> SaveDataExcelFile(IFormFile file,ILogger logger,GameDbContext context )
        {
            Encoding.RegisterProvider(CodePagesEncodingProvider.Instance);
            var filePath = await FileExtension.WriteFile(file);
            using(var stream =File.Open(filePath,FileMode.Open,FileAccess.Read) )
            {
                using(var reader =ExcelReaderFactory.CreateReader(stream))
                {
                    do
                    {
                        while (reader.Read())
                        {
                            Game game = new Game();
                            game.Code = reader.GetValue(0).ToString();
                            game.Name = reader.GetValue(1).ToString();
                            game.Plateforme = reader.GetValue(2).ToString();
                            game.Genre = reader.GetValue(3).ToString();
                            context.Add(game);
                            await context.SaveChangesAsync();
                        }
                    }
                    while (reader.NextResult());
                }
            }
            return true;
        }
        public static bool CompareFileContent(string firstPathFile ,string[] path2)
        {

            return true;
        }
    }
}