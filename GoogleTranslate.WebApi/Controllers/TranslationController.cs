using GoogleTranslate.WebApi.DTOs;
using GoogleTranslate.WebApi.Services.Interfaces;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GoogleTranslate.WebApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [EnableCors("CorsPolicy")]
    public class TranslationController : ControllerBase
    {
        private readonly ITranslationServices _translationServices;
        public TranslationController(ITranslationServices translationServices)
        {
            _translationServices = translationServices;
        }
        /// <summary>
        /// Performs the translation of a given text
        /// </summary>
        /// /// <remarks>
        /// Sample request:
        ///
        ///     POST /Todo
        ///     {
        ///        "source": "en",
        ///        "target": "de",
        ///        "text": "Hello World"
        ///     }
        ///
        /// </remarks>
        [HttpPost]
        public async Task<IActionResult> Translate([FromBody] TranslationRequestDTO translationRequestDTO)
        {
            var result = await _translationServices.Translate(translationRequestDTO);
            return Ok(result);
        }
    }
}
