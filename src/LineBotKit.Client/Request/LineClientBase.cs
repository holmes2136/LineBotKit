using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;

namespace LineBotKit.Client.Request
{
    public abstract class LineClientBase : IDisposable
    {
        internal readonly HttpClient HttpClient;
        internal readonly JsonSerializer Serializer = new JsonSerializer();

        protected LineClientBase(string channelAccessToken)
        {
            HttpClient = new HttpClient { };
            HttpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", channelAccessToken);
            HttpClient.DefaultRequestHeaders.Add("Keep-Alive", "true");
        }

        private bool _disposedValue;


        protected virtual void Dispose(bool disposing)
        {
            if (!_disposedValue)
            {
                if (disposing)
                {
                    HttpClient?.Dispose();
                }

                _disposedValue = true;
            }
        }

        ~LineClientBase()
        {
            Dispose(false);
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        public void CheckDisposed()
        {
            if (_disposedValue)
            {
                throw new ObjectDisposedException(typeof(LineClientBase).FullName);
            }
        }
    }
}
