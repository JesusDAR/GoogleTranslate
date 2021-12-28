using GoogleTranslate.WebApi.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GoogleTranslate.WebApi.Services.Interfaces
{
    public interface ITranslationServices
    {
        public Task<TranslationResponseDTO> Translate(TranslationRequestDTO translationRequestDTO);
    }
}
    