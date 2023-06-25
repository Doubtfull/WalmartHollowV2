using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Creates a scriptable object, the file name, and the folder it can be found in
[CreateAssetMenu(fileName = "PlayerController", menuName = "InputController/PlayerController")]
public class PlayerController : InputController
{
    //Overrrides the RetrieveJumpInput function to check if the jump button was pressed
    public override bool RetrieveJumpInput()
    {
        return Input.GetButtonDown("Jump");
    }

    //Overrrides the RetrieveMoveInput function to check if the player is trying to move
    public override float RetrieveMoveInput()
    {
        return Input.GetAxisRaw("Horizontal");
    }

    public override bool RetrieveJumpHoldInput()
    {
        return Input.GetButton("Jump");
    }
}
