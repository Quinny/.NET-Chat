dotNET Chat
--------------------------

dotNET chat is a chat server built in .NET using websockets, which allows for clients of all different kinds to be easily created.

Also in this repo is an implementation of a javascript client, as well as a python one for testing purposes.

Building
------------------
First clone the repo recursively as it uses the Fleck websocket library

```
git clone https://github.com/Quinny/dotNET-Chat --recursive
```

Then build the solution

If you are using Visual Studio or something that supports .sln files, then simply open the solution and press f5, otherwise:


On windows:
```
msbuild CSChat.sln
```

For unix you will have to install xbuild, probably through monodevelop: ```xbuild CSChat.sln```

The executable will be produced in ```CSChat/RunServer/bin/Debug/RunServer.exe```

The files for the webserver are located in ```Web```.  Currently they are not served in the chat server (soon to come), so you will have to handle that part on your own.
