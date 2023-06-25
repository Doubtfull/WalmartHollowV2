using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//InputController cannot be instantiated due to abstract class
public abstract class InputController : ScriptableObject //Allows us to create instances (a copy this template) of the controllers to then use in the inspector
{
    public abstract float RetrieveMoveInput();
    public abstract bool RetrieveJumpInput();
    public abstract bool RetrieveJumpHoldInput();
}
