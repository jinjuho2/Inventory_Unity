using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[CreateAssetMenu(fileName = "New Item", menuName = "Item/ItemData")]
public class ItemData : ScriptableObject
{
    public string _name;
    public int id;
    public int type;
    public string description;
    public bool isEquipped;
    public Sprite icon;
    public int attack;
    public int defense;
    public int health;
    public int critical;
}
