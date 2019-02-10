using Microsoft.ServiceFabric.Actors;
using Microsoft.ServiceFabric.Actors.Client;
using System;

namespace UserActor.Interfaces
{
    public static class UserActorResolver
    {
        public static IUserActor Resolve(string userId)
        {
            return ActorProxy.Create<IUserActor>(
                new ActorId(userId),
                new Uri("fabric:/ECommerce/UserActorService"));
        }
    }
}
