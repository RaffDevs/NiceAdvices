using System.Net.Http.Json;
using System.Web;
using Microsoft.Extensions.Configuration;
using NiceAdvices.Core.Entities;
using NiceAdvices.Infrastructure.Models.DTOs;

namespace NiceAdvices.Infrastructure.Services;

public class TranslatorService
{
    private readonly IHttpClientFactory _httpClientFactory;
    private readonly IConfiguration _configuration;

    public TranslatorService(IHttpClientFactory httpClientFactory, IConfiguration configuration)
    {
        _httpClientFactory = httpClientFactory;
        _configuration = configuration;
    }

    public async Task<Advice?> Translate(string adviceText)
    {
        var client = _httpClientFactory.CreateClient("Translator");
        client.DefaultRequestHeaders.Add("Ocp-Apim-Subscription-Key", _configuration["Translator:Key"]);
        client.DefaultRequestHeaders.Add("Ocp-Apim-Subscription-Region", _configuration["Translator:Region"]);
        
        var uriBuilder = new UriBuilder(client.BaseAddress)
        {
            Path = "translate"
        };
        
        var query = HttpUtility.ParseQueryString(uriBuilder.Query);
        query["api-version"] = "3.0";
        query["from"] = "en";
        query["to"] = "pt-br";
        uriBuilder.Query = query.ToString();
        var uri = uriBuilder.Uri;
        var body = new List<TranslatorRequestDTO>
        {
            new() { Text = adviceText}
        };
        
        var request = await client.PostAsJsonAsync(uri, body);

        if (request.IsSuccessStatusCode)
        {
            var content = await request.Content.ReadFromJsonAsync<List<TranslatorResponseDTO>>();
            var translations = content.SelectMany<TranslatorResponseDTO, TranslatorDTO>(x => x.Translations);
            return new Advice { Text = translations.First().Text };
        }

        throw new Exception("Translation Error");
    }
}