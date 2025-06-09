using Robust.Shared.Network;
using Robust.Shared.Serialization;


namespace Content.Shared._Floof.Bees;

[Serializable, NetSerializable]
public sealed class BeeMessage : BoundUserInterfaceMessage
{

    public BeeMessage()
    {
    }
}
