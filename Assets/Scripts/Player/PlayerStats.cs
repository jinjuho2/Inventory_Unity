using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerStats : MonoBehaviour
{
    public string _name;
    public int attack;
    public int defense;
    public int health;
    public int critical;

    public void Init(string name, int attack, int defense, int health, int critical)
    {
        _name = name;
        this.attack = attack;
        this.defense = defense;
        this.health = health;
        this.critical = critical;
    }
    
}
