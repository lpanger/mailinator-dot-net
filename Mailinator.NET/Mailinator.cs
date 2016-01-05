using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace Mailinator.NET
{
    public class Mailinator
    {
        private readonly Uri _apiUrl = new Uri("http://api.mailinator.com/");

        private readonly string _getEmailEndpoint = "api/email?";
        private readonly string _deleteEmailEndpoint = "api/delete?";
        private readonly string _getInboxEndpoint = "api/inbox?";

        private string _parms;

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="token">You can find/change your access token on your account settings pane.</param>
        /// <param name="privateDomain">Query your private domain repository instead of the public repository. Optional, defaults to false</param>
        public Mailinator(string token, bool privateDomain = false)
        {
            _parms = string.Format("token={0}&", token);

            if (privateDomain)
            {
                _parms += "private_domain=true&";
            }
        }

        /// <summary>
        /// Returns all ??? for a given email address
        /// </summary>
        /// <param name="emailAddress"></param>
        /// <returns></returns>
        public async Task<IEnumerable<Email>> GetEmailsAsync(string emailAddress)
        {
            _parms += string.Format("to={0}", emailAddress);

            using (var client = new HttpClient())
            {
                client.BaseAddress = _apiUrl;

                var response = await client.GetAsync(_getInboxEndpoint + _parms);
                if (response.IsSuccessStatusCode)
                {
                    var body = await response.Content.ReadAsStringAsync();
                    return JsonConvert.DeserializeObject<IEnumerable<Email>>(body);
                }

                throw new EmailNotFoundException(string.Format("Unable to find emails to {0}.", emailAddress));
            }
        }

        /// <summary>
        /// Gets single email
        /// </summary>
        /// <param name="msgId">Id of email</param>
        /// <returns>Email details</returns>
        public async Task<Email> GetEmailAsync(string msgId)
        {
            _parms += string.Format("msgid={0}", msgId);
            
            using (var client = new HttpClient())
            {
                client.BaseAddress = _apiUrl;

                var response = await client.GetAsync(_getEmailEndpoint + _parms);
                if (response.IsSuccessStatusCode)
                {
                    var body = await response.Content.ReadAsStringAsync();
                    return JsonConvert.DeserializeObject<Email>(body);
                }

                throw new EmailNotFoundException(string.Format("Unable to find email with msgid = {0}.", msgId));
            }
        }

        /// <summary>
        /// Deletes a single email
        /// </summary>
        /// <param name="msgId">Id of email</param>
        /// <returns>Success or not</returns>
        public async Task<bool> DeleteEmailAsync(string msgId)
        {
            _parms += string.Format("msgid={0}", msgId);
            
            using (var client = new HttpClient())
            {
                client.BaseAddress = _apiUrl;

                var response = await client.GetAsync(_deleteEmailEndpoint + _parms);
                return response.IsSuccessStatusCode; 
            }
        }
    }
}
