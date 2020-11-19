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
        grid = GameObject.FindWithTag("SceneManager").GetComponent(typeof(PositionGrid)) as PositionGrid;
        Position = new GridCoordinates(GridPositionX, GridPositionY);
        grid.AddCharacterToTile(Position, this);
        StartCoroutine(Idle());
    }
}