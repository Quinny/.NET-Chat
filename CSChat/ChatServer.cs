using System;
using System.Collections.Generic;
using Fleck;

namespace CSChat
{
	public class ChatServer
	{
		WebSocketServer _ws = new WebSocketServer("ws://0.0.0.0:8181");
		Dictionary<IWebSocketConnection, ChatClient> _clients = new Dictionary<IWebSocketConnection, ChatClient> ();
		private void DelegateMessage(IWebSocketConnection sender ,string message)
		{
			if (_clients[sender].Registered) {
				BroadCast(_clients[sender].ColoredName, message);
			} else {
				if (message.StartsWith("//registerName:")) {
					_clients[sender].Register(message.Split(':') [1]);
					BroadCast ("server", _clients [sender].Name + " connected!");
				}
			}
		}

		private void BroadCast(string from, string message)
		{
			foreach (var client in _clients)
				client.Value.Send(from, message);
		}

		private void AddClient(IWebSocketConnection socket)
		{
			_clients.Add(socket, new ChatClient (socket));
		}

		public void Serve ()
		{
			_ws.Start(socket => {
				socket.OnOpen += () => {
					AddClient(socket);
				};
				socket.OnMessage += message => {
					DelegateMessage(socket, message);
				};
				socket.OnClose += () => {
					if (_clients[socket].Registered)
						BroadCast("server", _clients[socket].Name + " disconnected");
					_clients.Remove(socket);
				};
			});
		}
	}
}