using ImportFile.Core.Extensions;
using ImportFile.Infracstructure.Persistence;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.OpenApi.Expressions;
using Swashbuckle.AspNetCore.Annotations;
using System.Net.Mime;
using static ImportFile.Core.Extensions.FileExtension;

namespace ImportFile.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ImportFileController : ControllerBase
    {
        private readonly ILogger<ImportFileController> _logger;
        private readonly GameDbContext _context;

        public ImportFileController(ILogger<ImportFileController> logger, GameDbContext context)
        {
            _logger = logger;
            _context = context;
        }

        [HttpPost]
        [Route("api/UploadExcelFile")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(string), StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> UploadExcelFile(IFormFile file, CancellationToken cancellationtoken)
        {
            var result = await FileExtension.WriteFile(file);
            return Ok(result);
        }

        [HttpPost]
        [Route("api/ImportWithoutIFormData")]
        [SwaggerOperation("CheckValidExtension", "Importation de fichier via le path du fichier")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(string), StatusCodes.Status400BadRequest)]
        public IActionResult ImportWithoutIFormData(IFormFile filePath)
        {
            var extension = "." + filePath.FileName.Split('.')[filePath.FileName.Split('.').Length - 1];
            var name = filePath.FileName;
            var parent = $"{Directory.GetParent(name)} \\Data";
            return Ok(extension);
        }

        [HttpPost]
        [Route("api/ImportWithSaveInDataBase")]
        [SwaggerOperation("CheckValidExtension", "Importation de fichier  puis enregistrements des données")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(string), StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> ImportWithSaveInDataBase(IFormFile file)
        {
            await FileExtension.SaveDataExcelFile(file, _logger, _context);
            return Ok();
        }
        [HttpGet]
        [Route("api/GetAllGame")]
        [SwaggerOperation("Liste de tous les jeux ","Recuperation de la liste de tous les jeux")]
        public JsonResult GetAllGame()
        {
            var result =_context.Games.ToList();
            return new JsonResult(Ok(result));
        }
    }
}
