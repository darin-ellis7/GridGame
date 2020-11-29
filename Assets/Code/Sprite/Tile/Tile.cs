using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tile : MonoBehaviour
{
    public enum MovementAllowance
    {
        Players,
        Enemies,
        All,
        None
    }
    private Character standing;
    public Character Standing
    {
        get
        {
            return standing;
        }
        set
        {
            standing = value;
        }
    }
    private MovementAllowance movementTagAllowed;
    public MovementAllowance MovementTagAllowed
    {
        get
        {
            return movementTagAllowed;
        }
        set
        {
            movementTagAllowed = value;
        }
    }

    //Allow a character's movement onto this tile if it matches the allowed tag
    //OR if this tile's MovementAllowance is set to All
    public bool IsCharacterMoveAllowed(Character movingCharacter)
    {
        return ((MovementTagAllowed == movingCharacter.MovementTag) 
             || (MovementTagAllowed == MovementAllowance.All));
    }

    public void ClearStanding()
    {
        standing = null;
    }
}