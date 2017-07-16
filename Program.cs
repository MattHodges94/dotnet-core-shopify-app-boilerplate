using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using RestSharp;
using RestSharp.Authenticators;


namespace shopify_app
{
    
    public class Program
    {
        
        public static void Main(string[] args)
        {

            var host = new WebHostBuilder()
                .UseKestrel()
                .UseContentRoot(Directory.GetCurrentDirectory())
                .UseIISIntegration()
                .UseStartup<Startup>()
                .Build();

            host.Run();

            
        }

        public static String GetCustomer(long id){
            
            var client = new RestClient();
            client.BaseUrl = new Uri("Enter shopify store url herre"); 
            client.Authenticator = new HttpBasicAuthenticator("Enter API key here", "Enter API password here");
            var request = new RestRequest(); 
            request.Resource = System.String.Format("/admin/customers/{0}.json", id);
            var response = client.ExecuteAsync(request);
            return response.Result.Content;


        }

        public static String GetCustomers(){
            var client = new RestClient();
            client.BaseUrl = new Uri("Enter shopify store url herre"); 
            client.Authenticator = new HttpBasicAuthenticator("Enter API key here", "Enter API password here");
            var request = new RestRequest(); 
            request.Resource = System.String.Format("/admin/customers.json");
            var response = client.ExecuteAsync(request);
            return response.Result.Content;
        }

    }

    public static class RestClientExtensions
{
    public static async Task<RestResponse> ExecuteAsync(this RestClient client, RestRequest request)
    {
        TaskCompletionSource<IRestResponse> taskCompletion = new TaskCompletionSource<IRestResponse>();
        RestRequestAsyncHandle handle = client.ExecuteAsync(request, r => taskCompletion.SetResult(r));
        return (RestResponse)(await taskCompletion.Task);

    }
}
}
