using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : Character
{
    //Basic AI logic
    IEnumerator BasicAiMovement()
    {
        yield return new WaitForSeconds(2);
        grid.MoveUp(this);
        yield return new WaitForSeconds(2);     
        grid.MoveLeft(this);
        yield return new WaitForSeconds(2);
        grid.MoveDown(this);
        yield return new WaitForSeconds(2);
        grid.MoveRight(this);
        StartCoroutine(BasicAiMovement());
    }
    //Kick off the movement using Start() after Awake() finishes initialization
    void Start()
    {
        StartCoroutine(BasicAiMovement());
    }
    void Update()
    {
        
    }
}