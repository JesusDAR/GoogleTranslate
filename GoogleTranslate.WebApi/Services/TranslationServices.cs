using GoogleTranslate.WebApi.DTOs;
using GoogleTranslate.WebApi.Services.Interfaces;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using System.Text.Json;

namespace GoogleTranslate.WebApi.Services
{
    public class TranslationServices : ITranslationServices
    {
        public async Task<TranslationResponseDTO> Translate(TranslationRequestDTO translationRequestDTO)
        {
            List<List<object>> parameter = new List<List<object>> { new List<object> { translationRequestDTO.Text, translationRequestDTO.Source, translationRequestDTO.Target, true }, new List<object> { 1 } };
            string escaped_parameter = JsonSerializer.Serialize(parameter);

            List<List<List<string>>> rpc = new List<List<List<string>>> { new List<List<string>> { new List<string> { "MkEWBc", escaped_parameter, null, "generic" } } };
            string espaced_rpc = JsonSerializer.Serialize(rpc);
            string encoded = Uri.EscapeDataString(espaced_rpc);
            string freq_initial = $"f.req={encoded}&";

            var client = new RestClient(Constants.Url);
            client.UserAgent = Constants.UserAgent;
            var request = new RestRequest(Constants.Resource, Method.POST);
            request.AddHeader("Content-Type", Constants.ContentType);
            request.AddHeader("Accept-Encoding", Constants.Encoding);
            request.AddHeader("Referer", Constants.Url);
            request.AddParameter("f.req", freq_initial, ParameterType.RequestBody);
            IRestResponse response = await client.ExecuteAsync(request);

            string content = response.Content;
            List<string> translations = new List<string>();
            string access = JsonSerializer.Deserialize<List<object>>(
                                JsonSerializer.Deserialize<List<object>>(
                                    JsonSerializer.Deserialize<List<List<object>>>(
                                        content.Remove(0, 4).Replace("\n", ""))[0][2].ToString())[1].ToString())[0].ToString();
            accessTranslations(access, translations);
            translations = translations.Distinct().ToList();

            TranslationResponseDTO translationResponseDTO = new TranslationResponseDTO
            {
                Translations = translations
            };
            return translationResponseDTO;
    }

        private void accessTranslations(string access, List<string> translations)
        {
            List<object> list = JsonSerializer.Deserialize<List<object>>(access);
            if (list.Any(s => (s != null) && ((JsonElement)s).ValueKind.ToString().Equals("String")))
                translations.Add(list.Where(s => (s != null) && ((JsonElement)s).ValueKind.ToString().Equals("String")).First().ToString());
            if (list.Any(s => (s != null) && ((JsonElement)s).ValueKind.ToString().Equals("Array")))
            {
                IEnumerable<string> nextList = list.Where(s => (s != null) && ((JsonElement)s).ValueKind.ToString().Equals("Array")).Select(s => s.ToString());
                foreach(string next in nextList)
                { 
                    accessTranslations(next, translations);
                }
            }
        }
    }
}
