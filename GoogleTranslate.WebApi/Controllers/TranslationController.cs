using GoogleTranslate.WebApi.DTOs;
using GoogleTranslate.WebApi.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GoogleTranslate.WebApi.Controllers
{
    [ApiController]
    [Route("/translate")]
    public class TranslationController : ControllerBase
    {
        private readonly ITranslationServices _translationServices;
        public TranslationController(ITranslationServices translationServices)
        {
            _translationServices = translationServices;
        }

        [HttpPost]
        public async Task<IActionResult> Translate([FromBody] TranslationRequestDTO translationRequestDTO)
        {
            var result = await _translationServices.Translate(translationRequestDTO);
            return Ok(result);
        }
    }
}
