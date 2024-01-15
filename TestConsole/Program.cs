using ImportFile.Core.Extensions;
using Microsoft.AspNetCore.Http;

namespace TestConsole
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var _Directory = "C:\\ProjetC#\\ASP .NET\\ImportFile\\ImportFile\\Data\\bussiness plan (2).xls";
            var fileInfo = new FileInfo(_Directory);
            Console.WriteLine(Directory.GetCurrentDirectory());
            if (FileExtension.CheckFileExist(_Directory))
            {
                Console.WriteLine("Le fichier existe deja");
            }
            else
            {
                Console.WriteLine("Le fichier n'existe pas");
            }
        }
    }
}