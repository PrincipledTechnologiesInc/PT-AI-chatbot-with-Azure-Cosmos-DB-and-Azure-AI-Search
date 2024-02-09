﻿using VectorSearchAiAssistant.Service.Models.Chat;
using VectorSearchAiAssistant.Service.Models.Search;

namespace VectorSearchAiAssistant.Service.Interfaces;

public interface ICosmosDbService
{
    bool IsInitialized { get; }

    /// <summary>
    /// Gets a list of all current chat sessions.
    /// </summary>
    /// <returns>List of distinct chat session items.</returns>
    Task<List<Session>> GetSessionsAsync();

    /// <summary>
    /// Gets a list of all current chat messages for a specified session identifier.
    /// </summary>
    /// <param name="sessionId">Chat session identifier used to filter messsages.</param>
    /// <returns>List of chat message items for the specified session.</returns>
    Task<List<Message>> GetSessionMessagesAsync(string sessionId);

    /// <summary>
    /// Performs a point read to retrieve a single chat session item.
    /// </summary>
    /// <returns>The chat session item.</returns>
    Task<Session> GetSessionAsync(string id);

    /// <summary>
    /// Creates a new chat session.
    /// </summary>
    /// <param name="session">Chat session item to create.</param>
    /// <returns>Newly created chat session item.</returns>
    Task<Session> InsertSessionAsync(Session session);

    /// <summary>
    /// Creates a new chat message.
    /// </summary>
    /// <param name="message">Chat message item to create.</param>
    /// <returns>Newly created chat message item.</returns>
    Task<Message> InsertMessageAsync(Message message);

    /// <summary>
    /// Updates an existing chat message.
    /// </summary>
    /// <param name="message">Chat message item to update.</param>
    /// <returns>Revised chat message item.</returns>
    Task<Message> UpdateMessageAsync(Message message);

    /// <summary>
    /// Updates a message's rating through a patch operation.
    /// </summary>
    /// <param name="id">The message id.</param>
    /// <param name="sessionId">The message's partition key (session id).</param>
    /// <param name="rating">The rating to replace.</param>
    /// <returns>Revised chat message item.</returns>
    Task<Message> UpdateMessageRatingAsync(string id, string sessionId, bool? rating);

    /// <summary>
    /// Updates an existing chat session.
    /// </summary>
    /// <param name="session">Chat session item to update.</param>
    /// <returns>Revised created chat session item.</returns>
    Task<Session> UpdateSessionAsync(Session session);

    /// <summary>
    /// Updates a session's name through a patch operation.
    /// </summary>
    /// <param name="id">The session id.</param>
    /// <param name="name">The session's new name.</param>
    /// <returns>Revised chat session item.</returns>
    Task<Session> UpdateSessionNameAsync(string id, string name);

    /// <summary>
    /// Batch create or update chat messages and session.
    /// </summary>
    /// <param name="messages">Chat message and session items to create or replace.</param>
    Task UpsertSessionBatchAsync(params dynamic[] messages);

    /// <summary>
    /// Batch deletes an existing chat session and all related messages.
    /// </summary>
    /// <param name="sessionId">Chat session identifier used to flag messages and sessions for deletion.</param>
    Task DeleteSessionAndMessagesAsync(string sessionId);

    /// <summary>
    /// Inserts a property into the properties container.
    /// </summary>
    /// <param name="property">Property item to create.</param>
    /// <returns>Newly created property item.</returns>
    Task<Property> InsertPropertyAsync(Property property);

    /// <summary>

    /// <summary>
    /// Deletes a property by its Id and category (its partition key).
    /// </summary>
    /// <param name="id">The Id of the property to delete.</param>
    /// <param name="name">The category Id of the property to delete.</param>
    /// <returns></returns>
    Task DeletePropertyAsync(string id, string name);

    /// <summary>
    /// Reads all documents retrieved by Vector Search.
    /// </summary>
    /// <param name="vectorDocuments">List string of JSON documents from vector search results</param>
    Task<string> GetVectorSearchDocumentsAsync(List<DocumentVector> vectorDocuments);

    Task<CompletionPrompt> GetCompletionPrompt(string sessionId, string completionPromptId);
}