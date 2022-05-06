namespace AnimalPOV
{
    public interface IMovementParameters
    {
        float MovementSpeed { get; }
        float RotationSpeed { get; }
        float JumpForce { get; }
        float MaxAngle { get; }
    }
}
