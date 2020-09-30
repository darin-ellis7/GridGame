using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SceneManager : MonoBehaviour
{
    [SerializeField] private Character testCharacter;
    private Vector3 charPosition = new Vector3(1, 1);

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
        Debug.Log("Starting");
        // PositionGrid testGrid = new PositionGrid();
        Instantiate(testCharacter, charPosition, Quaternion.identity);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}