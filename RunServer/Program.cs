using System;
using CSChat;
using System.Threading;

namespace RunServer
{
	class MainClass
	{
		public static void Main (string[] args)
		{
			var s = new ChatServer();
			var wh = new AutoResetEvent(false);
			s.Serve();

			var ws = new WebServer (r => {
				return "hello world";
			}, "http://localhost:8000/");
			ws.Serve();
			wh.WaitOne();
		}
	}
}
