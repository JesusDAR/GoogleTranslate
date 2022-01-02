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
            TranslationResponseDTO translationResponseDTO = new() 
            { 
                Translations = new List<string>(),
                Error = new ErrorDTO()
            };
            List<List<object>> parameter = new List<List<object>> { new List<object> { translationRequestDTO.Text, translationRequestDTO.Source, translationRequestDTO.Target, true }, new List<object> { 1 } };
            string escaped_parameter = JsonSerializer.Serialize(parameter);

            List<List<List<object>>> rpc = new List<List<List<object>>> { new List<List<object>> { new List<object> {"MkEWBc",escaped_parameter,null,"generic"} } };
            string espaced_rpc = JsonSerializer.Serialize(rpc);
            string encoded = Uri.EscapeDataString(espaced_rpc);
            string freq_initial = $"f.req={encoded}&";

            RestClient client = new RestClient(Constants.Url);
            //client.Proxy = new WebProxy("111.68.26.237", 8080);
            //client.Proxy.Credentials = CredentialCache.DefaultCredentials;
            //client.Timeout = 50000;
            
            client.UserAgent = Constants.UserAgent;
            RestRequest request = new RestRequest(Constants.Resource, Method.POST);
            request.AddHeader("Content-Type", Constants.ContentType);
            request.AddHeader("Accept-Encoding", Constants.Encoding);
            request.AddHeader("Referer", Constants.Url);
            request.AddParameter("f.req", freq_initial, ParameterType.RequestBody);

            
            List<string> translations = new List<string>();
            IRestResponse response = await client.ExecuteAsync(request);
            try
            {
                string content = response.Content;
                string access = JsonSerializer.Deserialize<List<object>>(
                            JsonSerializer.Deserialize<List<object>>(
                                JsonSerializer.Deserialize<List<List<object>>>(
                                    content.Remove(0, 4).Replace("\n", ""))[0][2].ToString())[1].ToString())[0].ToString();
                accessTranslations(access, translations);
                translations = translations.Distinct().ToList();
            }
            catch (Exception e)
            {
                translationResponseDTO.Error.Code = response.StatusCode;
                translationResponseDTO.Error.Message = response.ErrorMessage + " - " + e.Message;
            }
            translationResponseDTO.Translations = translations;
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
