using System.Net.Http.Json;
using Microsoft.Extensions.Configuration;
using NiceAdvices.Core.Entities;
using NiceAdvices.Infrastructure.Models.DTOs;
using NiceAdvices.Infrastructure.Models.Extensions;

namespace NiceAdvices.Infrastructure.Services;

public class AdviceService
{
    private readonly IHttpClientFactory _clientFactory;

    public AdviceService(IHttpClientFactory clientFactory)
    {
        _clientFactory = clientFactory;
    }

    public async Task<Advice?> GetRandomAdvice()
    {
        var client = _clientFactory.CreateClient("Advices");
        var request = await client.GetAsync("advice");
        request.EnsureSuccessStatusCode();
        var content = await request.Content.ReadFromJsonAsync<AdviceServiceDTO>();
        return content.ToEntity();
    }
}