using GoogleTranslate.WebApi.Services;
using GoogleTranslate.WebApi.Services.Interfaces;
using Xunit;
using JollyQuotes.KanyeRest;
using System.Threading.Tasks;
using GoogleTranslate.WebApi.DTOs;
using Xunit.Abstractions;
using Xunit.Sdk;

namespace GoogleTranslate.Tests
{
    public class TranslationTests
    {
        private readonly ITranslationServices _translationServices;
        private readonly IKanyeRestService _kanyeRestService;
        private readonly ITestOutputHelper _output;
        public TranslationTests(ITestOutputHelper output)
        {
            _translationServices = new TranslationServices();
            _kanyeRestService = new KanyeRestService();
            _output = output;
        }

        [Fact]
        public async Task Test_Translation_EN_FR()
        {
            int start = 0;
            int end = 5;
            var quotes = (await _kanyeRestService.GetAllQuotes()).GetRange(start, end);
            foreach(var q in quotes)
            {
                TranslationRequestDTO t = new TranslationRequestDTO()
                {
                    Source = "en",
                    Target = "fr",
                    Text = q.Quote
                };
                TranslationResponseDTO r = await _translationServices.Translate(t);
                _output.WriteLine(q.Quote + " - " + r.Translations[0] + "\n");
                Assert.True(r.Translations.Count > 0);
            }
        }

        [Fact]
        public async Task Test_Translation_EN_DE()
        {
            int start = 0;
            int end = 5;
            var quotes = (await _kanyeRestService.GetAllQuotes()).GetRange(start, end);
            foreach (var q in quotes)
            {
                TranslationRequestDTO t = new TranslationRequestDTO()
                {
                    Source = "en",
                    Target = "de",
                    Text = q.Quote
                };
                TranslationResponseDTO r = await _translationServices.Translate(t);
                _output.WriteLine(q.Quote + " - " + r.Translations[0] + "\n");
                Assert.True(r.Translations.Count > 0);
            }
        }
    }

}
