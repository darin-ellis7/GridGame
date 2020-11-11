using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character : MonoBehaviour
{
    [SerializeField] private int GridPositionX = 0;
    [SerializeField] private int GridPositionY = 0;
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
    
    protected PositionGrid grid;

    public void UpdateSprite()
    {
        transform.position = grid.GetTileVector3(Position);
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
    void Awake()
    {
        Position = new GridCoordinates(GridPositionX, GridPositionY);
        grid = GameObject.FindWithTag("SceneManager").GetComponent(typeof(PositionGrid)) as PositionGrid;
        grid.AddCharacterToTile(Position, this);
        UpdateSprite();
        StartCoroutine(Idle());
    }
}