# CambiumTestTask

How to run:
1. Download
2. Open in Visual Studio
3. Run 'Start without debugging' or Ctrl + F5, this should start up both client and server

Tech:
* .Net Web API - Server
* Blazor WASM - Client

Features:
* Size of Mars surface aka 'Grid' can be set dynamically and changed as long as no rovers deployed
* Rovers can be deployed both manually and through instructions file
* Rovers can be moved both by manually selecting an action and by predefined ections when loaded using instructions file

TODO / To Improve:
* Out of bounds operation check - currently, is done on the client, but can be moved to server to calculate out of bounds before doing an operation
* Collision check - currently, there's no collision check
