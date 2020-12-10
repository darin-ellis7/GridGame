using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : Character
{
    //Acquire Player input - every key has equal priority
    void Update()
    {
        if(Input.GetKeyDown("w"))
        {
            if(grid.MoveUpValid(this))
            {
                PlayMovementAnimation(grid.MoveUp);
            }
        }
        if(Input.GetKeyDown("a"))
        {
            if(grid.MoveLeftValid(this))
            {
                PlayMovementAnimation(grid.MoveLeft);
            }
        }
        if(Input.GetKeyDown("s"))
        {
            if(grid.MoveDownValid(this))
            {
                PlayMovementAnimation(grid.MoveDown);
            }
        }
        if(Input.GetKeyDown("d"))
        {
            if(grid.MoveRightValid(this))
            {
                PlayMovementAnimation(grid.MoveRight);
            }
        }

    }
}