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
            if(grid.MoveUp(this))
            {
                PlayMovementAnimation();
            }
        }
        if(Input.GetKeyDown("a"))
        {
            if(grid.MoveLeft(this))
            {
                PlayMovementAnimation();
            }
        }
        if(Input.GetKeyDown("s"))
        {
            if(grid.MoveDown(this))
            {
                PlayMovementAnimation();
            }
        }
        if(Input.GetKeyDown("d"))
        {
            if(grid.MoveRight(this))
            {
                PlayMovementAnimation();
            }
        }

    }
}