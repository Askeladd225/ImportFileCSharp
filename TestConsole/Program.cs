using ImportFile.Core.Extensions;
namespace TestConsole
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var _Directory = "C:\\ProjetC#\\ASP .NET\\ImportFile\\ImportFile\\Data\\Nouveau Document texte.txt";
            FileExtension fileExtension = new FileExtension();
            if (fileExtension.CheckFileExist(_Directory))
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