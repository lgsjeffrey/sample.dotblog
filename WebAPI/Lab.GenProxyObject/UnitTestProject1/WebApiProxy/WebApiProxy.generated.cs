//------------------------------------------------------------------------------
//<auto-generated>
//  This file is auto-generated by WebApiProxy
//  Project site: http://github.com/faniereynders/webapiproxy
//  
//  Any changes to this file will be overwritten
//</auto-generated>
//------------------------------------------------------------------------------

using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using System.Net.Http.Formatting;
using System.Linq;
using System.Net;
using System.Web;
using WebApi.Proxies.Models;

#region Proxies
namespace WebApi.Proxies
{
	/// <summary>
	/// Client configuration.
	/// </summary>
	public static partial class Configuration
	{
		/// <summary>
		/// Web Api Base Address.
		/// </summary>
		public static string MyWebApiProxyBaseAddress = "http://localhost:56364/";
	}
}
#endregion

#region Models
namespace WebApi.Proxies.Models
{
	public class WebApiProxyResponseException : Exception
	{
		public HttpStatusCode StatusCode { get; private set; }
		public string Content { get; private set; }

		public WebApiProxyResponseException(HttpStatusCode statusCode, string content) : base("A " + statusCode + " (" + (int)statusCode + ") http exception occured. See Content for response body.")
		{
			StatusCode = statusCode;
			Content = content;
		}
	}


	
}
#endregion

#region Interfaces
namespace WebApi.Proxies.Interfaces
{
	public interface IClientBase : IDisposable
	{
		HttpClient HttpClient { get; }
	}

	
	public partial interface IValuesClient : IClientBase
	{	


		/// <returns></returns>
		Task<HttpResponseMessage> GetAsync();

		/// <returns></returns>
		List<String> Get();

		/// <param name="id"></param>

		/// <returns></returns>
		Task<HttpResponseMessage> GetAsync(Int32 id);

		/// <param name="id"></param>
		/// <returns></returns>
		String Get(Int32 id);


		/// <returns></returns>
		Task<HttpResponseMessage> PostAsync(String value);

		/// <returns></returns>
		void Post(String value);

		/// <param name="id"></param>

		/// <returns></returns>
		Task<HttpResponseMessage> PutAsync(Int32 id,String value);

		/// <param name="id"></param>
		/// <returns></returns>
		void Put(Int32 id,String value);

		/// <param name="id"></param>

		/// <returns></returns>
		Task<HttpResponseMessage> DeleteAsync(Int32 id);

		/// <param name="id"></param>
		/// <returns></returns>
		void Delete(Int32 id);
				
	}

}
#endregion

#region Clients
namespace WebApi.Proxies.Clients
{
	/// <summary>
	/// Client base class.
	/// </summary>
	public abstract partial class ClientBase : IDisposable
	{
		/// <summary>
		/// Gests the HttpClient.
		/// </summary>
		public HttpClient HttpClient { get; protected set; }

		/// <summary>
		/// Initializes a new instance of the <see cref="ClientBase"/> class.
		/// </summary>
		protected ClientBase()
		{
			HttpClient = new HttpClient()
			{
				BaseAddress = new Uri(Configuration.MyWebApiProxyBaseAddress)
			};
		}
		
		/// <summary>
		/// Ensures that response has a valid (200 - OK) status code
		/// </summary>
		public virtual void EnsureSuccess(HttpResponseMessage response)
		{			
			if (response.IsSuccessStatusCode)				
				return;
													
			var content = response.Content.ReadAsStringAsync().Result;
			throw new WebApiProxyResponseException(response.StatusCode, content);			
		}

		/// <summary>
		/// Initializes a new instance of the <see cref="ClientBase"/> class.
		/// </summary>
		/// <param name="handler">The handler.</param>
		/// <param name="disposeHandler">if set to <c>true</c> [dispose handler].</param>
		protected ClientBase(HttpMessageHandler handler, bool disposeHandler = true)
		{
			HttpClient = new HttpClient(handler, disposeHandler)
			{
				BaseAddress = new Uri(Configuration.MyWebApiProxyBaseAddress)
			};
		}

		/// <summary>
		/// Encode the input parameter as a string
		/// </summary>
		protected string EncodeParam<T>(T value) 
		{
			return System.Net.WebUtility.UrlEncode(value.ToString());
		}
		
		/// <summary>
		/// Encode the input parameter as a string
		/// </summary>
		protected string EncodeParam(DateTime value) 
		{
			return System.Net.WebUtility.UrlEncode(value.ToString("s"));
		}
		
		/// <summary>
		/// Encode the input parameter as a string
		/// </summary>
		protected string EncodeParam(DateTimeOffset value)
		{
			return System.Net.WebUtility.UrlEncode(value.ToString("s"));
		}
		
		/// <summary>
		/// Releases the unmanaged resources and disposes of the managed resources.       
		/// </summary>
		protected virtual void Dispose(bool disposing)
		{
			if (disposing && HttpClient != null)
			{
				HttpClient.Dispose();
				HttpClient = null;
			}
		}
		
		/// <summary>
		/// Releases the unmanaged resources and disposes of the managed resources.       
		/// </summary>
		public void Dispose()
		{
			Dispose(true);
			GC.SuppressFinalize(this);
		}
		
		/// <summary>
		/// Destructor
		/// </summary>
		~ClientBase() 
		{
			Dispose(false);
		}
	}

	/// <summary>
	/// Helper class to access all clients at once
	/// </summary>
	public partial class WebApiClients
	{
		public ValuesClient Values { get; private set; }
		
        protected IEnumerable<Interfaces.IClientBase> Clients
        {
            get
            {
				yield return Values;
            }
        }

		public WebApiClients(Uri baseAddress = null)
		{
            if (baseAddress != null)
                Configuration.MyWebApiProxyBaseAddress = baseAddress.AbsoluteUri;

			Values = new ValuesClient();
		}

        public void SetAuthentication(AuthenticationHeaderValue auth)
        {
            foreach (var client in Clients)
                client.HttpClient.DefaultRequestHeaders.Authorization = auth;
        }
		
        protected virtual void Dispose(bool disposing)
        {
            if (disposing)
            {
                foreach (var client in Clients)
                    client.Dispose();
            }
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

		~WebApiClients() 
		{
            Dispose(false);
		}
	}

	/// <summary>
	/// 
	/// </summary>
	public partial class ValuesClient : ClientBase, Interfaces.IValuesClient
	{		

		/// <summary>
		/// 
		/// </summary>
		public ValuesClient() : base()
		{
		}

		/// <summary>
		/// 
		/// </summary>
		public ValuesClient(HttpMessageHandler handler, bool disposeHandler = true) : base(handler, disposeHandler)
		{
		}

		#region Methods

		/// <summary>
		/// 
		/// </summary>
		/// <returns></returns>
		protected virtual async Task<HttpResponseMessage> GetAsyncMsg()
		{
			return await HttpClient.GetAsync("api/Values");
		}

		/// <summary>
		/// 
		/// </summary>
		/// <returns></returns>
		public virtual async Task<HttpResponseMessage> GetAsync()
		{
			return await HttpClient.GetAsync("api/Values");
		}

		/// <summary>
		/// 
		/// </summary>
		public virtual List<String> Get()
		{
			var result = Task.Run(() => GetAsyncMsg()).Result;		 
			 
			EnsureSuccess(result);
			 			 
			return result.Content.ReadAsAsync<List<String>>().Result;
			 		}

		/// <summary>
		/// 
		/// </summary>
		/// <param name="id"></param>
		/// <returns></returns>
		protected virtual async Task<HttpResponseMessage> GetAsyncMsg(Int32 id)
		{
			return await HttpClient.GetAsync("api/Values/" + id);
		}

		/// <summary>
		/// 
		/// </summary>
		/// <param name="id"></param>
		/// <returns></returns>
		public virtual async Task<HttpResponseMessage> GetAsync(Int32 id)
		{
			return await HttpClient.GetAsync("api/Values/" + id);
		}

		/// <summary>
		/// 
		/// </summary>
		/// <param name="id"></param>
		public virtual String Get(Int32 id)
		{
			var result = Task.Run(() => GetAsyncMsg(id)).Result;		 
			 
			EnsureSuccess(result);
			 			 
			return result.Content.ReadAsAsync<String>().Result;
			 		}

		/// <summary>
		/// 
		/// </summary>
		/// <param name="value"></param>
		/// <returns></returns>
		protected virtual async Task<HttpResponseMessage> PostAsyncMsg(String value)
		{
			return await HttpClient.PostAsJsonAsync<String>("api/Values", value);
		}

		/// <summary>
		/// 
		/// </summary>
		/// <returns></returns>
		public virtual async Task<HttpResponseMessage> PostAsync(String value)
		{
			return await HttpClient.PostAsJsonAsync<String>("api/Values", value);
		}

		/// <summary>
		/// 
		/// </summary>
		public virtual void Post(String value)
		{
			var result = Task.Run(() => PostAsyncMsg(value)).Result;		 
			 
			EnsureSuccess(result);
		}

		/// <summary>
		/// 
		/// </summary>
		/// <param name="id"></param>
		/// <param name="value"></param>
		/// <returns></returns>
		protected virtual async Task<HttpResponseMessage> PutAsyncMsg(Int32 id,String value)
		{
			return await HttpClient.PutAsJsonAsync<String>("api/Values/" + id, value);
		}

		/// <summary>
		/// 
		/// </summary>
		/// <param name="id"></param>
		/// <returns></returns>
		public virtual async Task<HttpResponseMessage> PutAsync(Int32 id,String value)
		{
			return await HttpClient.PutAsJsonAsync<String>("api/Values/" + id, value);
		}

		/// <summary>
		/// 
		/// </summary>
		/// <param name="id"></param>
		public virtual void Put(Int32 id,String value)
		{
			var result = Task.Run(() => PutAsyncMsg(id, value)).Result;		 
			 
			EnsureSuccess(result);
		}

		/// <summary>
		/// 
		/// </summary>
		/// <param name="id"></param>
		/// <returns></returns>
		protected virtual async Task<HttpResponseMessage> DeleteAsyncMsg(Int32 id)
		{
			return await HttpClient.DeleteAsync("api/Values/" + id);
		}

		/// <summary>
		/// 
		/// </summary>
		/// <param name="id"></param>
		/// <returns></returns>
		public virtual async Task<HttpResponseMessage> DeleteAsync(Int32 id)
		{
			return await HttpClient.DeleteAsync("api/Values/" + id);
		}

		/// <summary>
		/// 
		/// </summary>
		/// <param name="id"></param>
		public virtual void Delete(Int32 id)
		{
			var result = Task.Run(() => DeleteAsyncMsg(id)).Result;		 
			 
			EnsureSuccess(result);
		}

		#endregion
	}
}
#endregion
