using Content.Shared._Floof.Bees;
using Robust.Shared.Containers;


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
    }
}
