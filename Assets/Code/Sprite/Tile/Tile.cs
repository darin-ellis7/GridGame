using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tile : MonoBehaviour
{
    private Character standing;
    public Character Standing
    {
        get;
        set;
    }

    public Tile(Vector3 position)
    {
        this.transform.position = position;
    }

    public void ClearStanding()
    {
        standing = null;
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}