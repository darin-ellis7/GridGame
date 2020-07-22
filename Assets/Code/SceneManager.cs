using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SceneManager : MonoBehaviour
{
    void Awake()
    {
        Debug.Log ("Awake");
    }

    void OnEnable ()
    {
        Debug.Log ("OnEnable");
    }

    void Main ()
    {
        Debug.Log ("Main");
    }

    // Start is called before the first frame update
    void Start()
    {
        GridCoordinates staringPosition = new GridCoordinates(1,1);
        PositionGrid battleGrid = gameObject.AddComponent(typeof(PositionGrid)) as PositionGrid;
        Character mainChar = new Character(staringPosition, battleGrid);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}