using HealthcareTranslationAPI.Models;
using Microsoft.AspNetCore.Mvc;
using OpenAI;
using OpenAI.API;
using OpenAI.API.Completions;
using System.Text.Json;

namespace HealthcareTranslationAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TranslationController : ControllerBase
    {

        private readonly string openAiApiKey = "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";
        private readonly string googleApiKey = "AIzaSyAnQXGHdFq-VgACnVEqXzLgSYAI-AGaEGU";

        [HttpPost("speech-to-text")]
        public async Task<IActionResult> SpeechToText([FromBody] AudioRequest request)
        {
            using var httpClient = new HttpClient();
            var url = $"https://speech.googleapis.com/v1/speech:recognize?key={googleApiKey}";

            var content = new StringContent(JsonSerializer.Serialize(new
            {
                config = new { encoding = "LINEAR16", languageCode = request.Language },
                audio = new { content = request.AudioBase64 }
            }), System.Text.Encoding.UTF8, "application/json");

            var response = await httpClient.PostAsync(url, content);
            var result = await response.Content.ReadAsStringAsync();
            return Ok(result);
        }

        [HttpPost("translate")]
        public async Task<IActionResult> TranslateText([FromBody] TranslateRequest request)
        {
            //var api = new OpenAIAPI(openAiApiKey);
            //var result = await api.Completions.CreateCompletionAsync(new CompletionRequest
            //{
            //    Prompt = $"Translate '{request.Text}' from {request.SourceLanguage} to {request.TargetLanguage}.",
            //    Model = "text-davinci-003",
            //    MaxTokens = 100
            //});

            //return Ok(new { TranslatedText = result.Completions[0].Text.Trim() });
            var api = new OpenAIAPI(openAiApiKey);
            var result = await api.Completions.CreateCompletionAsync(new CompletionRequest
            {
                Prompt = $"Translate '{request.Text}' from {request.SourceLanguage} to {request.TargetLanguage}.",
                Model = "gpt-3.5-turbo",
                MaxTokens = 50
            });
            return Ok(new { TranslatedText = result.Completions[0].Text.Trim() });

        }

    }
}

