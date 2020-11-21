using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SceneManager : MonoBehaviour
{
    [SerializeField] public Player scenePlayer;
    [SerializeField] public Enemy sceneEnemy;
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

    private void InitializeScene()
    {
        PositionGrid grid = GameObject.FindWithTag("SceneManager").GetComponent(typeof(PositionGrid)) as PositionGrid;
        grid.AssignTransformPositionsToTiles();
        Instantiate(scenePlayer, charPosition, Quaternion.identity);
        Instantiate(sceneEnemy, enemyPosition, Quaternion.identity);
        grid.AssignOwnershipOfTiles();
    }

    // Start is called before the first frame update
    void Start()
    { 
        Debug.Log("Starting");
        InitializeScene();
    }
}