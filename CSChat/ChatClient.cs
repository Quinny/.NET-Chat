using System;
using System.Web;
using System.Drawing;
using System.Web.Script.Serialization;
using Fleck;

namespace CSChat
{
	public class ChatClient
	{
		public string Name { get; private set;}
		public bool Registered { get; private set;}
		private Color _color;
		public string Color {
			get { return _color.ToHex(); }
		}

		private IWebSocketConnection _connection;

		public ChatClient(IWebSocketConnection c)
		{
			_connection = c;
		}

		public void Send(ChatClient from, string message)
		{
			var toSend = new ChatMessage ()
			{
				from = from.Name,
				color = from.Color,
				message = message
			};
			_connection.Send(new JavaScriptSerializer().Serialize(toSend));
		}

		public void Register(string n)
		{
			Name = HttpUtility.HtmlEncode(n);
			Registered = true;
			_color = ColorGenerator.GetColor();
		}
	}
}