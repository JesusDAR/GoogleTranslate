using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GoogleTranslate.WebApi.DTOs
{
    public class TranslationRequestDTO
    {
        public string Source { get; set; }
        public string Target { get; set; }
        public string Text { get; set; }
    }
}
