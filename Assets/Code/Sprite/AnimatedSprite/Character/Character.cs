using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character : MonoBehaviour
{
    //public int[,] position = new int[1,1];
    public SpriteRenderer spriteRenderer;
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

    public Sprite[] idle;
    
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

    void Awake()
    {
        
    }

    IEnumerator Idle()
    {
        int i;
        i = 0;
        while (i < idle.Length)
        {
            spriteRenderer.sprite = idle[i];
            i++;
            yield return new WaitForSeconds(0.07f);
            yield return 0;
                
        }
        StartCoroutine(Idle());
    }

    // Start is called before the first frame update
    void Start()
    {
        gameObject.tag = "Player";
        this.grid = GameObject.FindWithTag("SceneManager").GetComponent(typeof(PositionGrid)) as PositionGrid;
        this.grid.AddCharacterToTile(this.position, this);
        UpdateSprite();
        StartCoroutine(Idle());
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