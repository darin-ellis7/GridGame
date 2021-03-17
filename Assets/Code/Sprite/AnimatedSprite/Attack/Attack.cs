using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attack : MonoBehaviour
{
    public SpriteRenderer spriteRenderer;
    [SerializeField] private Transform attackContainer;
    public uint damage;
    public Character attacker;
    protected PositionGrid grid;

    void Awake()
    {
        grid = GameObject.FindWithTag("SceneManager").GetComponent(typeof(PositionGrid)) as PositionGrid;
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