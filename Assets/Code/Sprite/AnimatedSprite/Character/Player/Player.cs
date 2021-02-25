using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : Character
{
    public Sprite[] basicAttack;
    IEnumerator BasicAttack()
    {
        spriteRenderer.sprite = basicAttack[0];

        for(int i = 0; i < basicAttack.Length; i++)
        {
            spriteRenderer.sprite = basicAttack[i];
            yield return new WaitForSeconds(0.07f);
        }
        StartCoroutine(Idle());
    }

    protected void PerformBasicAttack()
    {
        StopAllCoroutines();
        StartCoroutine(BasicAttack());
    }

    //Acquire Player input - every key has equal priority
    void Update()
    {
        if(Input.GetKeyDown("up"))
        {
            if(grid.MoveUpValid(this))
            {
                PlayMovementAnimation(grid.MoveUp);
            }
        }
        if(Input.GetKeyDown("left"))
        {
            if(grid.MoveLeftValid(this))
            {
                PlayMovementAnimation(grid.MoveLeft);
            }
        }
        if(Input.GetKeyDown("down"))
        {
            if(grid.MoveDownValid(this))
            {
                PlayMovementAnimation(grid.MoveDown);
            }
        }
        if(Input.GetKeyDown("right"))
        {
            if(grid.MoveRightValid(this))
            {
                PlayMovementAnimation(grid.MoveRight);
            }
        }
        if(Input.GetKeyDown("w"))
        {
            PerformBasicAttack();
        }

    }
}