using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "AIController", menuName = "InputController/AIController")]

public class AIController : InputController
{
    //Overrides the RetrieveJumpInput and returns true (always jumping)
    public override bool RetrieveJumpInput()
    {
        return true;
    }

    //Overrides the RetrieveMoveInput and returns 1f (always moving to the right)
    public override float RetrieveMoveInput()
    {
        return 1f;
    }

    public override bool RetrieveJumpHoldInput()
    {
        return false;
    }
}
