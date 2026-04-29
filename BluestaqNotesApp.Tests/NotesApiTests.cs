using System.Net.Http.Json;
using Microsoft.AspNetCore.Mvc.Testing;
using Xunit;
using BluestaqNotesApp;

namespace BluestaqNotesApp.Tests;

public class NotesApiTests : IClassFixture<WebApplicationFactory<Program>>
{
    private readonly HttpClient _client;

    public NotesApiTests(WebApplicationFactory<Program> factory)
    {
        _client = factory.CreateClient();
    }

    [Fact]
    public async Task CreateNote_ReturnsCreated()
    {
        var response = await _client.PostAsJsonAsync("/api/notes", new
        {
            content = "test note"
        });

        Assert.True(response.IsSuccessStatusCode);
    }
}