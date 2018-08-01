using System.Collections.Generic;
using System.Threading.Tasks;
using Flurl;
using Flurl.Http;
using Newtonsoft.Json;

namespace Banking.Web.Services
{
    /// <summary>
    /// The service base.
    /// </summary>
    public class ServiceBase
    {
        /// <summary>
        /// The service URL.
        /// </summary>
        private string serviceUrl;

        /// <summary>
        /// Initializes a new instance of the <see cref="ServiceBase"/> class.
        /// </summary>
        /// <param name="serviceUrl">The service URL.</param>
        public ServiceBase(string serviceUrl)
        {
            this.serviceUrl = serviceUrl;
        }

        /// <summary>
        /// Gets the post response.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="uri">The URI.</param>
        /// <param name="apiEndpoint">The API endpoint.</param>
        /// <param name="parameters">The parameters.</param>
        /// <returns></returns>
        protected async Task<T> GetPOSTResponseAsync<T>(string apiEndpoint, Dictionary<string, string> parameters)
            where T : new()
        {
            string result = await $"{this.serviceUrl}{apiEndpoint}"
                .WithHeader("Accept", "application/json")
                .PostJsonAsync(parameters).ReceiveString();

            return JsonConvert.DeserializeObject<T>(result);
        }

        /// <summary>
        /// Gets the post response.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="uri">The URI.</param>
        /// <param name="apiEndpoint">The API endpoint.</param>
        /// <param name="parameters">The parameters.</param>
        /// <returns></returns>
        protected Task<string> GetPOSTResponseStringAsync(string apiEndpoint, Dictionary<string, string> parameters)
        {
            return $"{this.serviceUrl}{apiEndpoint}"
                .WithHeader("Accept", "application/json")
                .PostJsonAsync(parameters)
                .ReceiveString();
        }

        /// <summary>
        /// Gets the get response.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="apiEndpoint">The API endpoint.</param>
        /// <param name="parameters">The parameters.</param>
        /// <param name="authorizationHeader">The authorization header.</param>
        /// <returns></returns>
        protected async Task<T> GetGETResponseAsync<T>(string apiEndpoint, Dictionary<string, string> parameters, string authorizationHeader = null)
            where T : new()
        {
            var request = $"{this.serviceUrl}{apiEndpoint}"
                .SetQueryParams(parameters)
                .WithHeader("Accept", "application/json");

            if(!string.IsNullOrEmpty(authorizationHeader))
            {
                request = request.WithHeader("Authorization", authorizationHeader);
            }

            string result = await request.GetAsync().ReceiveString();
            return JsonConvert.DeserializeObject<T>(result);
        }

        protected Task<string> GetGETResponseStringAsync(string apiEndpoint, Dictionary<string, string> parameters, string authorizationHeader = null)
        {
            var request = $"{this.serviceUrl}{apiEndpoint}"
                .SetQueryParams(parameters)
                .WithHeader("Accept", "application/json");

            if(!string.IsNullOrEmpty(authorizationHeader))
            {
                request = request.WithHeader("Authorization", authorizationHeader);
            }

            return request.GetAsync().ReceiveString();
        }
    }
}