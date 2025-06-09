using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public PlayerStats Stats { get { return stats; } }
    private PlayerStats stats;




    private void Awake()
    {
        Init();
    }

    private void Update()
    {
        
    }

    private void Init()
    {
        stats = GetComponent<PlayerStats>();
        stats.Init("¡¯¡÷»£", 1, 1, 1, 1);
    }


}
