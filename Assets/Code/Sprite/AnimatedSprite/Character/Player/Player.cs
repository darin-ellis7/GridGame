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
            grid.MoveUp(this);
        }

        if(Input.GetKeyDown("a"))
        {
            grid.MoveLeft(this);
        }

        if(Input.GetKeyDown("s"))
        {
            grid.MoveDown(this);
        }

        if(Input.GetKeyDown("d"))
        {
            grid.MoveRight(this);
        }
    }
}