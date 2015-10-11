using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
//using System.Web;
using System.Threading.Tasks;
namespace ApiCommunicator.Base
{
    public abstract class APIWrapperBase : IDisposable
    {
        private readonly string _baseUrl;
        private Lazy<HttpClient> _lazyClient;

        protected APIWrapperBase(string baseUrl)
        {
            _baseUrl = baseUrl.Trim('/');
            _lazyClient = new Lazy<HttpClient>(() => new HttpClient());
        }

        protected HttpClient Client()
        {
            if (_lazyClient == null)
            {
                throw new ObjectDisposedException("HttpClient has been disposed");
            }

            return _lazyClient.Value;
        }

        protected async Task<JToken> Execute<T>(string urlSegment)
        {
            JToken result = null;
            using (var client = new HttpClient()) {
                var response = await Client().GetAsync(_baseUrl + urlSegment).ConfigureAwait(false);
                response.EnsureSuccessStatusCode();
                await response.Content.ReadAsStringAsync().ContinueWith((Task<string> x) =>
                { if (x.IsFaulted)
                        throw x.Exception;
                    result = JsonConvert.DeserializeObject<JToken>(x.Result);
                        });
            }
            return result;
            /*var result = Client().GetStringAsync(_baseUrl + urlSegment);
            var retObj = JObject.Parse(result).SelectToken("records").ToObject<List<T>>();
            return retObj.FirstOrDefault();*/
            //return JsonConvert.DeserializeObject<T>(Client().DownloadString(_baseUrl + urlSegment));
        }

        /*protected List<T> ExecuteAndReturnList<T>(string urlSegment)
        {
            var result = Client().DownloadString(_baseUrl + urlSegment);

            return (JObject.Parse(result).SelectToken("records").ToObject<List<T>>());
        }

        protected List<T> ExecuteAndReturnListFromFile<T>(string FileName)
        {

            return JsonConvert.DeserializeObject<List<T>>(File.ReadAllText(FileName));
        }
        */
        ~APIWrapperBase()
        {
            Dispose(false);
        }

        public void Dispose()
        {
            Dispose(false);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (_lazyClient != null)
            {
                if (disposing)
                {
                    if (_lazyClient.IsValueCreated)
                    {
                        _lazyClient.Value.Dispose();
                        _lazyClient = null;
                    }
                }

                // There are no unmanaged resources to release, but
                // if we add them, they need to be released here.
            }
        }
    }
}