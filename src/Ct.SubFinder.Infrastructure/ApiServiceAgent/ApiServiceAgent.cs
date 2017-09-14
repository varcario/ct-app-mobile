
using Ct.SubFinder.Domain;
using Ct.SubFinder.Infrastructure.Messages;
using System;
using System.Net.Http;
using System.Runtime.Serialization.Json;
using System.Threading.Tasks;

namespace Ct.SubFinder.Infrastructure.ApiServiceAgent
{
    public class ApiServiceAgent : IApiServiceAgent<ApiRequest, ApiResponse> 
    {
        static HttpClient client = new HttpClient();

        public Content<ApiRequest, ApiResponse> Invoke(Content<ApiRequest, ApiResponse> content)
        {
            switch (content?.Request?.Method)
            {
                case ApiMethod.DELETE:
                    Delete(content);
                    break;
                case ApiMethod.GET:
                    Get(content);
                    break;
                case ApiMethod.PATCH:
                    Patch(content);
                    break;
                case ApiMethod.POST:
                    Post(content);
                    break;
                case ApiMethod.PUT:
                    Put(content);
                    break;
                default:
                    break;
            }

            return content;
        }

        private Content<ApiRequest, ApiResponse> Delete(Content<ApiRequest, ApiResponse> content)
        {
            throw new System.NotImplementedException();
        }

        private async Task<Content<ApiRequest, ApiResponse>> Get(Content<ApiRequest, ApiResponse> content)
        {
            var uri = new Uri(string.Format(content.Request.Url, string.Empty));
            var response = await client.GetAsync(uri);
            if (response.IsSuccessStatusCode)
            {
                content.Response = new ApiResponse
                {
                    Body = await response.Content.ReadAsStringAsync()
                };
            }
            return content;
        }

        private Content<ApiRequest, ApiResponse> Patch(Content<ApiRequest, ApiResponse> content)
        {
            throw new System.NotImplementedException();
        }

        private Content<ApiRequest, ApiResponse> Post(Content<ApiRequest, ApiResponse> content)
        {
            throw new System.NotImplementedException();
        }

        private Content<ApiRequest, ApiResponse> Put(Content<ApiRequest, ApiResponse> content)
        {
            throw new System.NotImplementedException();
        }
    }
}
