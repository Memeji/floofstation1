namespace Content.Server._Floof.Bees;


[RegisterComponent]
[Access(typeof(ApiarySystem))]
public sealed partial class ApiaryComponent : Component
{

    public bool Ejecting; //Is makign Bee?
    public float EjectAccumulator = 0f; //Timer for making Bee.
    public float EjectDelay = 0.6f; //Delay before making Bee

    public string? NextBeeToEject;

}
