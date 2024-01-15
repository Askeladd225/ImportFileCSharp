using ImportFile.Core.Extensions;
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
    }
}
