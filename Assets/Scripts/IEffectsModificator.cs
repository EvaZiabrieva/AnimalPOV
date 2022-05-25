using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace AnimalPOV
{
    public interface IEffectsModificator 
    {
        float SpeedModificator { get; }
        float JumpModificator { get; }
    }
}
