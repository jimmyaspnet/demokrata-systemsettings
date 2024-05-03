// <copyright file="JsonSerializerOptions.cs" company="DonDoctor">
//     Copyright (c) 2022 All Rights Reserved
// </copyright>
// <author>Jimmy Rodriguez Avila</author>
namespace Demokrata.SystemSettings.IntegrationTest.Configuration;

using System;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

/// <summary>
/// The integration helper class
/// </summary>
public static class IntegrationTestHelper
{
    /// <summary>
    /// The json options
    /// </summary>
    private static JsonSerializerOptions jsonOptions;

    /// <summary>
    /// Gets the json options.
    /// </summary>
    /// <value>
    /// The json options.
    /// </value>
    public static JsonSerializerOptions JsonOptions
    {
        get
        {
            if (jsonOptions == null)
            {
                jsonOptions = new JsonSerializerOptions
                {
                    PropertyNameCaseInsensitive = true,
                    PropertyNamingPolicy = JsonNamingPolicy.CamelCase
                };

                jsonOptions.Converters.Add(new JsonStringEnumConverter());
            }

            return jsonOptions;
        }
    }

    /// <summary>
    /// Gets the content of the request.
    /// </summary>
    /// <param name="obj">The object.</param>
    /// <returns>a string</returns>
    public static StringContent GetRequestContent(object obj) =>
        new(JsonSerializer.Serialize(obj, JsonOptions), Encoding.UTF8, "application/json");

    /// <summary>
    /// Gets the content of the response.
    /// </summary>
    /// <typeparam name="T">The generic type</typeparam>
    /// <param name="response">The response.</param>
    /// <returns>a task</returns>
    public static async Task<T> GetResponseContent<T>(HttpResponseMessage response)
    {
        var stringResponse = await response.Content.ReadAsStringAsync();

        if (stringResponse is null)
        {
            stringResponse = "{}";
        }

        var result = JsonSerializer.Deserialize<T>(stringResponse, JsonOptions);

        if (result is null)
        {
            throw new Exception("GetResponseContent null");
        }

        return result;
    }
}