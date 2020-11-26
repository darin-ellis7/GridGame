using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character : MonoBehaviour
{
    [SerializeField] private int GridPositionX = 0;
    [SerializeField] private int GridPositionY = 0;
    public SpriteRenderer spriteRenderer;
    protected PositionGrid grid;
    public Sprite[] idle;
    private GridCoordinates position;
    public Sprite[] move;
    private const float moveAnimationTime = 0.02f;
    public GridCoordinates Position
    { 
        get
        {
            return position;
        } 
        set 
        {
            position = value;
            transform.position = grid.GetTileVector3(value);
        }
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

    protected void PlayMovementAnimation()
    {
        StopAllCoroutines();
        StartCoroutine(MoveOut());
    }

    void Awake()
    {
        grid = GameObject.FindWithTag("SceneManager").GetComponent(typeof(PositionGrid)) as PositionGrid;
        Position = new GridCoordinates(GridPositionX, GridPositionY);
        grid.AddCharacterToTile(Position, this);
        StartCoroutine(Idle());
    }
}
