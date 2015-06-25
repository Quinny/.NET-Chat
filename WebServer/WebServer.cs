using System;
using System.Net;
using System.Threading;
using System.Text;

namespace CSChat
{
	public class WebServer
	{
		private HttpListener _listener = new HttpListener();
		public delegate string ResponseHandler(HttpListenerRequest r);

		private ResponseHandler _handler;

		public WebServer (ResponseHandler h, params string[] prefixes)
		{
			foreach (var p in prefixes)
				_listener.Prefixes.Add(p);
			_handler = h;
			_listener.Start();
		}

		public void Serve()
		{
			Console.WriteLine("Webserver started at: " + String.Join(",",_listener.Prefixes));
			ThreadPool.QueueUserWorkItem(_ => {
				while (_listener.IsListening) {
					ThreadPool.QueueUserWorkItem(s => {
						var context = s as HttpListenerContext;
						try {
							var response = _handler(context.Request);
							var buff = Encoding.UTF8.GetBytes(response);
							context.Response.ContentLength64 = buff.Length;
							using (var os = context.Response.OutputStream)
								os.Write(buff, 0, buff.Length);
						} catch {
						}
						;
					}, _listener.GetContext());
				}
			});
		}

		public void Stop()
		{
			_listener.Stop();
			_listener.Close();
		}
	}
}

