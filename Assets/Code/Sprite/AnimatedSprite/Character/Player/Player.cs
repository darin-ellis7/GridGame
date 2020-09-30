using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : Character
{
    //Acquire Player input
    void Update()
    {
        if(Input.GetKeyDown("w"))
        {
            this.grid.MoveUp(this);
            UpdateSprite();
        }
        if(Input.GetKeyDown("a"))
        {
            this.grid.MoveLeft(this);
            UpdateSprite();
        }
        if(Input.GetKeyDown("s"))
        {
            this.grid.MoveDown(this);
            UpdateSprite();
        }
        if(Input.GetKeyDown("d"))
        {
            this.grid.MoveRight(this);
            UpdateSprite();
        }

    }
}