﻿using VectorSearchAiAssistant.SemanticKernel.Text;
using VectorSearchAiAssistant.Service.Interfaces;

namespace VectorSearchAiAssistant.Service.Services
{
    public class InMemorySystemPromptService : ISystemPromptService
    {
        readonly Dictionary<string, string> _prompts = new Dictionary<string, string>()
        {
            { "RetailAssistant.Default", @"
                You are an intelligent assistant for the Cosmic Works Rental Company. 
                You are designed to provide helpful answers to user questions about 
                property information provided in JSON format below.

                Instructions:
                - Only answer questions related to the information provided below,
                - Don't reference any property data not provided below.
                - If you're unsure of an answer, you can say ""I don't know"" or ""I'm not sure"" and recommend users search themselves.

                Text of relevant information:".NormalizeLineEndings()
            },
            {
                "RetailAssistant.Limited", @"
                You are an AI assistant that helps people find information.
                Provide concise answers that are polite and professional.".NormalizeLineEndings()
            },
            { "Summarizer.TwoWords", @"
                Summarize this prompt in one or two words to use as a label in a button on a web page. Output words only.".NormalizeLineEndings()
            }
        };

        public async Task<string> GetPrompt(string promptName, bool forceRefresh = false)
        {
            if (!_prompts.ContainsKey(promptName))
                throw new ArgumentException($"The prompt {promptName} is not supported.");

            return _prompts[promptName];
        }
    }
}
