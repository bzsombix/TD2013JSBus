namespace JSBus.Hubs
{
    using System;
    using System.ComponentModel;
    using System.Globalization;
    using System.Threading;
    using System.Threading.Tasks;

    using Microsoft.AspNet.SignalR;
    using Microsoft.AspNet.SignalR.Hubs;

    [HubName("test")]
    public class JSBusTestHub : Hub
    {
        private readonly JSBusTestBusinessLogic bl = new JSBusTestBusinessLogic();

        public Task Execute(TestCommand command)
        {
            // TODO: Should check whether this command has already been received 
            // TODO: Store the message in a message store
            // Acknowledge caller that we have this message persisted
            this.Clients.Caller.ack(command.Id);

            // In reality should find the correct handler for given command name and give the 
            // command to that class
            return Task.Factory.StartNew(
                () =>
                    { this.bl.Test(command, this.Clients.Caller); });
        }
    }

    public class JSBusTestBusinessLogic
    {
        private readonly Random randomWait = new Random();

        public async void Test(TestCommand command, dynamic client)
        {
            // Wait a random time, max 5 s
            int delay = this.randomWait.Next(5000);

            await Task.Delay(delay);

            // Notify listener about success
            var reply = new TestEvent
            {
                Id = command.Id,
                Name = "TestEvent",
                Answer = "Executed with delay " + delay.ToString(CultureInfo.CurrentCulture)
            };

            client.onEvent(reply); 
        }
    }

    public class TestCommand : ICommand
    {
        public string Id { get; set; }

        public string Name { get; set; }
    }

    public class TestEvent : ICommand
    {
        public string Id { get; set; }

        public string Name { get; set; }

        public string Answer { get; set; }        
    }

    public interface ICommand
    {
        string Id { get; set; }
        string Name { get; set; }
    }
}