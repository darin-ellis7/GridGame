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
    public Sprite[] move;
    private const float moveAnimationTime = 0.02f;
    
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
        spriteRenderer.sprite = idle[0];
        yield return new WaitForSeconds(3);

        for(int i = 0; i < idle.Length; i++)
        {
            spriteRenderer.sprite = idle[i];
            yield return new WaitForSeconds(0.07f);
        }
        for(int i = idle.Length - 1; i >= 0; i--)
        {
            spriteRenderer.sprite = idle[i];
            yield return new WaitForSeconds(0.07f);
        }
        StartCoroutine(Idle());
    }

    IEnumerator MoveOut()
    {
        for(int i = 0; i < move.Length; i++)
        {
            spriteRenderer.sprite = move[i];
            yield return new WaitForSeconds(moveAnimationTime);
        }
        UpdateSprite();
        StartCoroutine(MoveIn());
    }
    
    IEnumerator MoveIn()
    {
        for(int i = move.Length - 1; i > 0; i--)
        {
            spriteRenderer.sprite = move[i];
            yield return new WaitForSeconds(moveAnimationTime);
        }
        StartCoroutine(Idle());
    }

    private void PlayMovementAnimation()
    {
        StopAllCoroutines();
        StartCoroutine(MoveOut());
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
            if(this.grid.MoveUp(this))
            {
                PlayMovementAnimation();
            }
        }
        if(Input.GetKeyDown("a"))
        {
            if(this.grid.MoveLeft(this))
            {
                PlayMovementAnimation();
            }
        }
        if(Input.GetKeyDown("s"))
        {
            if(this.grid.MoveDown(this))
            {
                PlayMovementAnimation();
            }
        }
        if(Input.GetKeyDown("d"))
        {
            if(this.grid.MoveRight(this))
            {
                PlayMovementAnimation();
            }
        }

    }
}