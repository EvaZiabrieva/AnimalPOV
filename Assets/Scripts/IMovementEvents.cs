using System;

namespace AnimalPOV
{
    public interface IMovementEvents
    {
        event Action Idle;
        event Action Run;
        event Action Jump;
    }
}
