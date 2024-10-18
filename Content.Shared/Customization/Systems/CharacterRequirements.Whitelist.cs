using Content.Shared.CCVar;
using Content.Shared.Preferences;
using Content.Shared.Roles;
using JetBrains.Annotations;
using Robust.Shared.Configuration;
using Robust.Shared.Prototypes;
using Robust.Shared.Serialization;
using Robust.Shared.Utility;

namespace Content.Shared.Customization.Systems;


/// <summary>
///     Requires the player to be whitelisted if whitelists are enabled
/// </summary>
[UsedImplicitly]
[Serializable, NetSerializable]
public sealed partial class CharacterWhitelistRequirement : CharacterRequirement
{
    public override bool IsValid(
        JobPrototype job,
        HumanoidCharacterProfile profile,
        Dictionary<string, TimeSpan> playTimes,
        bool whitelisted, IPrototype prototype,
        IEntityManager entityManager,
        IPrototypeManager prototypeManager,
        IConfigurationManager configManager,
        out FormattedMessage? reason, int depth = 0)
    {
        reason = FormattedMessage.FromMarkup(Loc.GetString("character-whitelist-requirement", ("inverted", Inverted)));
        return !configManager.GetCVar(CCVars.WhitelistEnabled) || whitelisted;
    }
}

/// <summary>
///     Checks if the player is whitelisted for the job, if it is whitelisted.
/// </summary>
[UsedImplicitly]
[Serializable, NetSerializable]
public sealed partial class CharacterJobWhitelistRequirement : CharacterRequirement
{
    [DataField]
    public List<string> _jobWhitelists = new();

    public override bool IsValid(
        JobPrototype job,
        HumanoidCharacterProfile profile,
        Dictionary<string, TimeSpan> playTimes,
        bool whitelisted,
        IPrototype prototype,
        IEntityManager entityManager,
        IPrototypeManager prototypeManager,
        IConfigurationManager configManager,
        out FormattedMessage? reason, int depth = 0)
    {
        reason = null;

        // Disable the requirement if the job whitelists are disabled
        if (!configManager.GetCVar(CCVars.GameRoleWhitelist))
        {
            reason = null;
            return !Inverted; //whitelisted = true;
        }

        if (job.Whitelisted && !_jobWhitelists.Contains(job.ID))
        {
            reason = Inverted ? null : FormattedMessage.FromUnformatted(Loc.GetString("role-not-whitelisted"));
            return false;
        }

        reason = null;
        return true;
    }
}
