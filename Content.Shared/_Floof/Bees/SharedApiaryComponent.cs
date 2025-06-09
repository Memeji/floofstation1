using Robust.Shared.Serialization;


namespace Content.Shared.FloofStation.Bees;


public abstract partial class SharedApiaryComponent : Component
{
    [Serializable, NetSerializable]
    public enum ApiaryUiKey
    {
        Key
    }
}
