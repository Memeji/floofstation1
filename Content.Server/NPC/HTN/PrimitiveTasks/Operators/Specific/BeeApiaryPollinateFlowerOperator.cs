using System.Threading;
using System.Threading.Tasks;
using Content.Server.Botany.Components;
using Content.Server.NPC.Pathfinding;
using Content.Shared.Emag.Components;
using Content.Shared.Interaction;
using Content.Shared.Silicons.Bots;
using Robust.Shared.Prototypes;
using Serilog;


namespace Content.Server.NPC.HTN.PrimitiveTasks.Operators.Specific;

public sealed partial class BeeApiaryPollinateFlowerOperator : HTNOperator
{
    [Dependency] private readonly IEntityManager _entManager = default!;
    [Dependency] private readonly IPrototypeManager _prototypeManager = default!;

    private EntityLookupSystem _lookup = default!;


    public override void Initialize(IEntitySystemManager sysManager)
    {
        base.Initialize(sysManager);

        _lookup = sysManager.GetEntitySystem<EntityLookupSystem>();
    }

    public override async Task<(bool Valid, Dictionary<string, object>? Effects)> Plan(NPCBlackboard blackboard,
        CancellationToken cancelToken)
    {

        return (true, null);
    }
}
