using Content.Shared.FixedPoint;
using Content.Shared.Chemistry.Components;
using Content.Shared.Chemistry.Reagent;
using Content.Shared.FloofStation.Traits;
using Robust.Shared.Serialization.TypeSerializers.Implementations.Custom.Prototype.List;
using Robust.Shared.Prototypes;
using Robust.Shared.Serialization.TypeSerializers.Implementations.Custom;
using Robust.Shared.GameStates;

namespace Content.Server._Floof.Traits;

[RegisterComponent, Access(typeof(LewdTraitSystem))]
public sealed partial class CumProducerComponent : Component
{
    [DataField("solutionname")]
    public string SolutionName = "penis";

    [DataField]
    public ProtoId<ReagentPrototype> ReagentId = "Cum";

    [DataField]
    public FixedPoint2 MaxVolume = FixedPoint2.New(25);

    [ViewVariables]
    public Entity<SolutionComponent>? Solution = null;

    [DataField]
    public FixedPoint2 QuantityPerUpdate = 5;

    [DataField]
    public float HungerUsage = 10f;

    [DataField]
    public TimeSpan GrowthDelay = TimeSpan.FromSeconds(10);

    [DataField(customTypeSerializer: typeof(TimeOffsetSerializer))]
    public TimeSpan NextGrowth = TimeSpan.FromSeconds(0);
}
