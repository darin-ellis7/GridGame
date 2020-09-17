using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character : MonoBehaviour
{
    //public int[,] position = new int[1,1];
    private GridCoordinates position;
    public GridCoordinates Position
    { 
        get
        {
            return position;
        } 
        set 
        {
            position = value;
        }
    }
    
    private PositionGrid grid;

    public Character(GridCoordinates startingPosition, PositionGrid positionGrid)
    {
        position = startingPosition;
        grid = positionGrid;
    }

    private void UpdateSprite()
    {
        Debug.Log ("x:" + this.transform.position.x + " y:" + this.transform.position.y);
        this.transform.position = this.grid.GetTileVector3(this.position);
        Debug.Log ("x:" + this.transform.position.x + " y:" + this.transform.position.y);
    }

    void Awake()
    {
        
    }

    // Start is called before the first frame update
    void Start()
    {
        //GameObject characterObject = new GameObject("characterObject", typeof(SpriteRenderer));
        this.grid = GameObject.FindWithTag("SceneManager").GetComponent(typeof(PositionGrid)) as PositionGrid;
        this.grid.AddCharacterToTile(this.position, this);
        UpdateSprite();
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown("w"))
        {
            Debug.Log ("w");
            this.grid.MoveUp(this);
            UpdateSprite();
        }
        if(Input.GetKeyDown("a"))
        {
            Debug.Log ("a");
            this.grid.MoveLeft(this);
            UpdateSprite();
        }
        if(Input.GetKeyDown("s"))
        {
            Debug.Log ("s");
            this.grid.MoveDown(this);
            UpdateSprite();
        }
        if(Input.GetKeyDown("d"))
        {
            Debug.Log ("d");
            this.grid.MoveRight(this);
            UpdateSprite();
        }

    }
}