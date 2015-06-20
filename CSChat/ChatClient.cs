using System;
using System.Web;
using System.Drawing;
using Fleck;

namespace CSChat
{
	public class ChatClient
	{
		public string Name { get; private set;}
		public bool Registered { get; private set;}
		private Color _color;
		public string ColoredName{
			get {
				return String.Format("<span style=\"color:{0}\";>{1}</span>",
					_color.ToHex(), Name);
			}
		}

		private IWebSocketConnection _connection;

		public ChatClient(IWebSocketConnection c)
		{
			_connection = c;
		}

		public void Send(string from, string message)
		{
			_connection.Send (from + ": " + HttpUtility.HtmlEncode(message));
		}

		public void Register(string n)
		{
			Name = HttpUtility.HtmlEncode(n);
			Registered = true;
			_color = ColorGenerator.GetColor();
		}
	}
}