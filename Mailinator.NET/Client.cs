using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace Mailinator
{
    public class Client
    {
        private readonly string _token;
        private readonly bool _privateDomain;

        private const string BaseUrl = "https://api.mailinator.com";
        private const string InboxEndpoint = "/api/inbox?";
        private const string EmailEndpoint = "/api/email?";
        private const string DeleteEndpoint = "/api/delete?";
        
        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="token">You can find/change your access token on your account settings pane.</param>
        /// <param name="privateDomain">Query your private domain repository instead of the public repository. Optional, defaults to false</param>
        public Client(string token, bool privateDomain = false)
        {
            _token = token;
            _privateDomain = privateDomain;
        }

        /// <summary>
        /// Get inbox for a given email address
        /// </summary>
        /// <param name="emailAddress"></param>
        /// <returns>Collection of Email metadata</returns>
        public async Task<Inbox> GetInboxAsync(string emailAddress)
        {
            var parameters = string.Format("{0}token={1}&private_domain={2}&to={3}", InboxEndpoint, _token,
                _privateDomain, emailAddress);

            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(BaseUrl);

                var result =
                    await client.GetAsync(parameters);

                return JsonConvert.DeserializeObject<Inbox>(await result.Content.ReadAsStringAsync());
            }
        }

        /// <summary>
        /// Get a single email
        /// </summary>
        /// <param name="msgId"></param>
        /// <returns>Email matching given Id</returns>
        public async Task<Email> GetEmailAsync(string msgId)
        {
            var parameters = string.Format("{0}token={1}&private_domain={2}&msgid={3}", EmailEndpoint, _token,
                _privateDomain, msgId);

            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(BaseUrl);

                var result = await client.GetAsync(parameters);

                var envelope = JsonConvert.DeserializeObject<EmailEnvelope>(await result.Content.ReadAsStringAsync());

                return envelope.Data;
            }
        }

        /// <summary>
        /// Deletes a single email
        /// </summary>
        /// <param name="msgId"></param>
        /// <returns>Successful or not</returns>
        public async Task<bool> DeleteEmailAsync(string msgId)
        {
            var parameters = string.Format("{0}token={1}&private_domain={2}&msgid={3}", DeleteEndpoint, _token,
                _privateDomain, msgId);

            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(BaseUrl);

                var result = await client.GetAsync(parameters);

                return result.IsSuccessStatusCode;
            }
        }
    }
}
