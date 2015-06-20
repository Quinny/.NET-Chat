using System;
using CSChat;

namespace ChatTester
{
	class MainClass
	{
		public static void Main (string[] args)
		{
			var c = new ChatServer();
			c.Serve();
			Console.ReadLine();
		}
	}
}
