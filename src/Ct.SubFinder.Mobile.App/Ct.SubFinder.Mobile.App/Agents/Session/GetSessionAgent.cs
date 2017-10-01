using Ct.App.Infrastructure.Infrastructure;
using Ct.App.Infrastructure.Interfaces;
using Ct.SubFinder.Mobile.App.Core;
using System;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;

namespace Ct.SubFinder.Mobile.App.Agents.Session
{
    public class GetSessionAgent : ServiceAgent<AppState>
    {

        //http://ec2-34-206-64-42.compute-1.amazonaws.com/api/session/new
        private HttpClient _client;
        public GetSessionAgent(IPerformanceTrace performanceTrace, HttpClient client) : base(performanceTrace)
        {
            _client = client ?? throw new ArgumentNullException("client");
            // New code:
            //_client.BaseAddress = new Uri("http://ec2-34-206-64-42.compute-1.amazonaws.com/");
            //_client.DefaultRequestHeaders.Accept.Clear();
            //_client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            // Xamarin example
            _client.MaxResponseContentBufferSize = 256000;
        }
        protected override AppState ExecuteService(AppState state)
        {

            var s = SendRequest();
            state.Session = new Domain.Session { Credential = new Domain.Credential { Token = Guid.NewGuid().ToString("n") } };

            return state;
        }

        private async Task<string> SendRequest()
        {
            string session = null;
            //var uri = new Uri(string.Format("http://ec2-34-206-64-42.compute-1.amazonaws.com/api/session/new", string.Empty));
            //HttpResponseMessage response =  _client.GetAsync(uri).Result;
            //if (response.IsSuccessStatusCode)
            //{
            //    session = await response.Content.ReadAsStringAsync();
            //}
            //return session;

            var uri = new Uri(string.Format("http://ec2-34-206-64-42.compute-1.amazonaws.com/api/session/new", string.Empty));
            try {
                var client = new HttpClient();

                session = await client.GetStringAsync(uri);
                return session;
            }
            catch(Exception ex)
            {

            }
            return session;
        }
    }
}
