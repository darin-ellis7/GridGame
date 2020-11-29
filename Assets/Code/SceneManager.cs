using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SceneManager : MonoBehaviour
{
    [SerializeField] private Player scenePlayer;
    [SerializeField] private Enemy sceneEnemy;
    private Vector3 charPosition = new Vector3(1, 1);
    private Vector3 enemyPosition = new Vector3(5, 1);

    private void InitializeScene()
    {
        PositionGrid grid = GameObject.FindWithTag("SceneManager").GetComponent(typeof(PositionGrid)) as PositionGrid;
        grid.AssignTransformPositionsToTiles();
        Instantiate(scenePlayer, charPosition, Quaternion.identity);
        Instantiate(sceneEnemy, enemyPosition, Quaternion.identity);
        grid.AssignMovementAllowanceOfTiles();
    }

    void Awake()
    { 
        InitializeScene();
    }
}