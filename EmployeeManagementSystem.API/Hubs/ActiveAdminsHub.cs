using Microsoft.AspNetCore.SignalR;

namespace EmployeeManagementSystem.API.Hubs;

public class ActiveAdminsHub(IDictionary<string, Guid> activeAdmins) : Hub
{
    public async Task JoinChat(string id)
    {
        if (!activeAdmins.ContainsKey(id))
            if (activeAdmins.TryAdd(Context.ConnectionId, Guid.Parse(id)))
                await Clients.All.SendAsync("UpdateActiveAdmins", activeAdmins.Count);
    }

    private async Task Leave()
    {
        if (activeAdmins.Remove(Context.ConnectionId, out _))
            await Clients.All.SendAsync("UpdateActiveAdmins", activeAdmins.Count);
    }

    public override async Task OnDisconnectedAsync(Exception exception)
    {
        await Leave();
        await base.OnDisconnectedAsync(exception);
    }
}