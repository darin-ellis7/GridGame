using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tile : MonoBehaviour
{
    public enum MovementAllowance
    {
        Friend,
        Foe,
        All,
        None
    }
    public Character Standing
    { get; set; }
    public MovementAllowance MovementTagAllowed
    { get; set; }
    

    //Allow a character's movement onto this tile if it matches the allowed tag
    //OR if this tile's MovementAllowance is set to All
    //But do not allow any movement if the Tile's MovementAllowance is None
    public bool IsCharacterMoveAllowed(Character movingCharacter)
    {
        return (((MovementTagAllowed == movingCharacter.MovementTag) 
             || (MovementTagAllowed == MovementAllowance.All))
             && (MovementTagAllowed != MovementAllowance.None));
    }

    public void ClearStanding()
    {
        Standing = null;
    }
}
