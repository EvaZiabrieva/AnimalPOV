namespace AnimalPOV
{
    public interface IInputProvider
    {
        float GetForwardMovement();
        bool IsTryJump();
        float GetRotation();
    }
}
