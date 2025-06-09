using Content.Client.UserInterface.Controls;
using Content.Client.UserInterface.Systems.EscapeMenu;
using Robust.Client.UserInterface.Controls;
using Robust.Client.UserInterface.XAML;
using Robust.Shared.Log;
using Robust.Shared.Toolshed.Commands.GameTiming;
using Serilog;


namespace Content.Client._Floof.Bees;


public sealed partial class ApiaryWindow : FancyWindow
{

    private ISawmill _sawmill = default!;

    public ApiaryWindow()
    {
        RobustXamlLoader.Load(this);
        IoCManager.InjectDependencies(this);
        _sawmill = IoCManager.Resolve<ILogManager>().GetSawmill("AHELP");
        this.FindControl<Button>("BeeButton").OnPressed += _ => _sawmill.Log(LogLevel.Info, $"Unable to find player for NetUserId FUCK when sending discord COCK.");
    }
}
