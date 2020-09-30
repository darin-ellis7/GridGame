using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character : MonoBehaviour
{
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

    protected void UpdateSprite()
    {
        this.transform.position = this.grid.GetTileVector3(this.position);
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
}