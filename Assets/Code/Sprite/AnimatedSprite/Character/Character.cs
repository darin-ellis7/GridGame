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
    private PositionGrid grid;

    public Character(GridCoordinates startingPosition, PositionGrid positionGrid)
    {
        position = startingPosition;
        grid = positionGrid;
    }

    private void UpdateSprite()
    {
        this.transform.position = this.grid.GetTileVector3(this.position);
    }

    // Start is called before the first frame update
    void Start()
    {
        grid.AddCharacterToTile(this.position, this);
        UpdateSprite();
    }

    // Update is called once per frame
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