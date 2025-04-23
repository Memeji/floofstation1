using Robust.Shared.Containers;


namespace Content.Server.FloofStation.Bees;


public sealed class ApiarySystem : EntitySystem
{
    public override void Initialize()
    {
        base.Initialize();

        SubscribeLocalEvent<ApiaryComponent, ComponentStartup>(SubscribeUpdateUiState);
        SubscribeLocalEvent<ApiaryComponent, EntInsertedIntoContainerMessage>(SubscribeUpdateUiState);
        SubscribeLocalEvent<ApiaryComponent, EntRemovedFromContainerMessage>(SubscribeUpdateUiState);
        SubscribeLocalEvent<ApiaryComponent, BoundUIOpenedEvent>(SubscribeUpdateUiState);

    }

    public void SubscribeUpdateUiState<T>(Entity<ApiaryComponent> ent, ref T ev)
    {

    }
}
