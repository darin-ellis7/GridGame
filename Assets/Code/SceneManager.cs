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
        Instantiate(scenePlayer, charPosition, Quaternion.identity);
        Instantiate(sceneEnemy, enemyPosition, Quaternion.identity);
    }

    void Awake()
    { 
        InitializeScene();
    }
}