using Newtonsoft.Json;
using Storage_FrontEnd_ASPNetCore.Services.Interfaces;
using StorageModels.Models;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Json;

namespace Storage_FrontEnd_ASPNetCore.Services
{
    public class StorageClient : IStorageClient
    {
        private const string API_BASE_PATH = @"http://localhost:25616/Storage";
        private const string CALCULATE_PATH = @"Calculate";
        private const string GETMOCKRESULTITEMS_PATH = @"GetMockResultItems";

        public IEnumerable<ResultItem> Calculate(Item itemMovement)
        {
            if (itemMovement is null) throw new ArgumentNullException(nameof(itemMovement));

            return MakeRequest(HttpMethod.Post, CALCULATE_PATH, itemMovement);
        }

        public IEnumerable<ResultItem> GetMockResultItems()
        {
            return MakeRequest<IEnumerable<ResultItem>>(HttpMethod.Get, GETMOCKRESULTITEMS_PATH);
        }

        private static IEnumerable<ResultItem> MakeRequest<T>(HttpMethod httpMethod, string route, T parameter = null) where T: class
        {
            using (var client = new HttpClient())
            {
                HttpRequestMessage requestMessage = new HttpRequestMessage(httpMethod, $"{API_BASE_PATH}/{route}");

                if (parameter != null)
                    requestMessage.Content = JsonContent.Create(parameter);   // This is where your content gets added to the request body

                HttpResponseMessage clientResponse = client.SendAsync(requestMessage).Result;
                string apiResponse = clientResponse.Content.ReadAsStringAsync().Result;

                IEnumerable<ResultItem> response;
                // Attempt to deserialise the reponse to the desired type, otherwise throw an exception with the response from the api.
                if (apiResponse != "")
                    response = JsonConvert.DeserializeObject<IEnumerable<ResultItem>>(apiResponse);
                else
                    throw new Exception($"An error ocurred while calling the API. It responded with the following message: {clientResponse.StatusCode} {clientResponse.ReasonPhrase}");

                return response;
            }
        }
    }
}
