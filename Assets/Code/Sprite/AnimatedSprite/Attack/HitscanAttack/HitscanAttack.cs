using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HitscanAttack : Attack
{
    

    //spawn self in character container so it ca nreference the owning character
    private Character FindTarget()
    {
        Character target;
        bool targetFound = false;
        GridCoordinates searchLocation = attacker.Position;
        searchLocation.X++;

        while(grid.TileExists(searchLocation) && !targetFound)
        {
            if(grid.IsTilePopulated(searchLocation))
            {
                targetFound = true;
            }
            else
            {
                searchLocation.X++;
            }
        }

        if(targetFound)
        {
            target = grid.GetCharacterOnTile(searchLocation);
        }
        else
        {
            target = null;
        }

        return target;
    }

    IEnumerator ProcessAttack()
    {
        Character target = FindTarget();
        if(target != null)
        {
            // something something damage something
        }
        Destroy(gameObject);
    }

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(ProcessAttack());
    }

    // protected IEnumerator Wait()
    // {
    //     yield return new WaitForSeconds(5f);
    // }

    // Update is called once per frame
    void Update()
    {
        
    }
}