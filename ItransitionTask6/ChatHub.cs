using System.Collections.Concurrent;
using Microsoft.AspNetCore.SignalR;

namespace ItransitionTask6;

public class ChatHub : Hub
{
    public const string HubUrl = "/chatHub";
    
    private static ConcurrentDictionary<string, string> Users = new ConcurrentDictionary<string, string>();

    public async Task SendPrivateMessage(string user, string message, string receiver)
    {
        var receivers = Users
            .Where(x => x.Value == receiver)
            .Select(x => x.Key);
        
        await Clients.Clients(receivers).SendAsync("ReceivePrivateMessage", user, message);
    }

    public override Task OnConnectedAsync()
    {
        string username = Context.GetHttpContext()?.Request.Query["username"];
        Users.TryAdd(Context.ConnectionId, username);
        return base.OnConnectedAsync();
    }
    
    public override Task OnDisconnectedAsync(Exception exception)
    {
        Users.TryRemove(Context.ConnectionId, out var value);
        return base.OnDisconnectedAsync(exception);
    }
}