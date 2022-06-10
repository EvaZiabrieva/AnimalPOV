namespace AnimalPOV
{
    public interface IMovementInputProvider
    {
        float GetForwardMovement();
        bool IsTryJump();
        float GetRotation();
    }
}
