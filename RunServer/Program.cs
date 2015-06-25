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
			wh.WaitOne();
		}
	}
}
