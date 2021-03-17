using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HitscanAttack : Attack
{
    

    //spawn self in character container so it ca nreference the owning character

    

    // Start is called before the first frame update
    void Start()
    {
        yield WaitForSeconds(1f);
        
    }

    // protected IEnumerator Wait()
    // {
    //     yield return new WaitForSeconds(5f);
    // }

    private void SearchRight()
    {

    }

    // Update is called once per frame
    void Update()
    {
        Destroy(this);
    }
}