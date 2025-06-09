using JetBrains.Annotations;
using Robust.Client.UserInterface;
using Content.Shared._Floof.Bees;
using Robust.Client.UserInterface.Controls;
using Robust.Shared.Network;


namespace Content.Client._Floof.Bees
{
    /// <summary>
    /// Initializes a <see cref="ApiaryWindow"/> and updates it when new server messages are received.
    /// </summary>
    [UsedImplicitly]
    public sealed class ApiaryBoundUserInterface : BoundUserInterface
    {
        [ViewVariables]
        private ApiaryWindow? _window;

        public ApiaryBoundUserInterface(EntityUid owner, Enum uiKey) : base(owner, uiKey) { }

        protected override void Open()
        {
            base.Open();

            // Setup window layout/elements
            _window = this.CreateWindow<ApiaryWindow>();
            _window.Title = EntMan.GetComponent<MetaDataComponent>(Owner).EntityName;
            _window.OnBeeButton += Send;
        }

        public void Send()
        {
            SendMessage(new BeeMessage());
        }
    }
}
