using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SceneManager : MonoBehaviour
{
    [SerializeField] private Player testCharacter;
    [SerializeField] private Enemy testEnemy;
    private Vector3 charPosition = new Vector3(1, 1);
    private Vector3 enemyPosition = new Vector3(5, 1);

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
        Instantiate(testCharacter, charPosition, Quaternion.identity);
        //testCharacter.UpdateSprite();
        Instantiate(testEnemy, enemyPosition, Quaternion.identity);
        //testEnemy.UpdateSprite();
        //testEnemy.Position = new GridCoordinates(5, 1);
    }
}