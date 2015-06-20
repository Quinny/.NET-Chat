using System;
using Fleck;

namespace CSChat
{
	public class ChatClient
	{
		private string _name = String.Empty;
		private bool _registered = false;
		private IWebSocketConnection _connection;

		public ChatClient(IWebSocketConnection c)
		{
			_connection = c;
		}

		public void Send(string message)
		{
			_connection.Send (message);
		}

		public void Register(string n)
		{
			_name = n;
			_registered = true;
		}

		public bool Registered()
		{
			return _registered;
		}

		public string Name()
		{
			return _name;
		}
	}
}

