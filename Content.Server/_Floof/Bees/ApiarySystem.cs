using Content.Server.Advertise.Components;
using Content.Server.Power.EntitySystems;
using Content.Shared._Floof.Bees;
using Content.Shared.Throwing;
using Content.Shared.VendingMachines;
using Robust.Shared.Containers;
using System;
using System.Numerics;


namespace Content.Server._Floof.Bees;


public sealed class ApiarySystem : EntitySystem
{
    private ISawmill _sawmill = default!;
    public override void Initialize()
    {
        base.Initialize();
        _sawmill = IoCManager.Resolve<ILogManager>().GetSawmill("BEEE");
        SubscribeLocalEvent<ApiaryComponent, ComponentStartup>(SubscribeUpdateUiState);
        SubscribeLocalEvent<ApiaryComponent, EntInsertedIntoContainerMessage>(SubscribeUpdateUiState);
        SubscribeLocalEvent<ApiaryComponent, EntRemovedFromContainerMessage>(SubscribeUpdateUiState);
        SubscribeLocalEvent<ApiaryComponent, BoundUIOpenedEvent>(SubscribeUpdateUiState);
        SubscribeLocalEvent<ApiaryComponent, BeeMessage>(OnBeeMessage);

    }

    public void SubscribeUpdateUiState<T>(Entity<ApiaryComponent> ent, ref T ev)
    {
    }

    public void OnBeeMessage<BeeMessage>(Entity<ApiaryComponent> ent, ref BeeMessage msg)
    {
        _sawmill.Log(LogLevel.Info, "buzz");

        TryCreateBee(ent);

    }

    public void TryCreateBee(EntityUid uid, ApiaryComponent? apiComponent = null)
    {
        if (!Resolve(uid, ref apiComponent))
            return;

        if (apiComponent.Ejecting || !this.IsPowered(uid, EntityManager))
        {
            return;
        }

        // Start Ejecting and prevent spam.
        apiComponent.Ejecting = true; //Creating Bee
        apiComponent.NextBeeToEject = "MobBee"; //Next Bee to Eject.
    }

    private void EjectBee(EntityUid uid, ApiaryComponent? apiComponent = null)
    {
        if (!Resolve(uid, ref apiComponent))
            return;

        var ent = Spawn(apiComponent.NextBeeToEject, Transform(uid).Coordinates);

        apiComponent.NextBeeToEject = null;
    }

    public override void Update(float frameTime)
    {
        base.Update(frameTime);

        var query = EntityQueryEnumerator<ApiaryComponent>();
        while (query.MoveNext(out var uid, out var comp))
        {
            if (comp.Ejecting)
            {
                comp.EjectAccumulator += frameTime;
                if (comp.EjectAccumulator >= comp.EjectDelay)
                {
                    comp.EjectAccumulator = 0f;
                    comp.Ejecting = false;

                    EjectBee(uid, comp);
                }
            }
        }
    }
}
