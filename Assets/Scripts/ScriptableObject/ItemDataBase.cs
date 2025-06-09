using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(fileName = "ItemDataBase", menuName = "ScriptableObjects/ItemDataBase")]
public class ItemDataBase : ScriptableObject
{
    public ItemData[] items;
}
