# JavaScript based message bus with SignalR transport demo
## Finnish MS Techdays 2013

This project demonstrates creating a browser based message store & forward.

Technologies used:

- [Typescript](http://www.typescriptlang.org) for easy JavaScript module creation.
- [SignalR](http://signalr.net) [hubs](https://github.com/SignalR/SignalR/wiki/Hubs) for moving messages from browser to server, and for acknowledging messages received at server.

To run the demo, open project in Visual Studio and run it. Open developer tools console to view additional JavaScript console.log() output.

-----
### What should I look for?
Meaningful code can be found from

- Scripts/JSBus: Bus implementation
- Scripts/sampleUsage.js: Demonstrates how to use the bus

-----
Copyright 2013 Tero Teelahti.
