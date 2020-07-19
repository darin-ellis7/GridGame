using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character : MonoBehaviour
{
    //public int[,] position = new int[1,1];
    private GridCoordinates position;
    public GridCoordinates Position
    {
       get;
       set;
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown("w"))
        {
            //this.MoveUp();
        }
    }
}