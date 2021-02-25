using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HitscanAttack : Attack
{
    private PositionGrid grid;

    //spawn self in character container so it ca nreference the owning character

    void Awake()
    {
        
    }

    // Start is called before the first frame update
    void Start()
    {
        grid = GameObject.FindWithTag("SceneManager").GetComponent(typeof(PositionGrid)) as PositionGrid;
        
    }

    private void SearchRight()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
}