using Content.Client.UserInterface.Controls;
using Robust.Client.UserInterface.XAML;


namespace Content.Client.Floofstation.Bees;


public sealed partial class ApiaryWindow : FancyWindow
{
    public ApiaryWindow()
    {
        RobustXamlLoader.Load(this);
        IoCManager.InjectDependencies(this);

    }
}
