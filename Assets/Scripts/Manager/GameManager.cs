using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public Player player;
    public ItemDataBase itemDataBase;
    public static GameManager Instance;
    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
            return;
        }

        Instance = this;
        DontDestroyOnLoad(gameObject);
    }

    private void Start()
    {
        for (int i = 0; i < itemDataBase.items.Length; i++)
        {
            itemDataBase.items[i].isEquipped = false;
        }
    }

    public void UpdateStat(ItemData item)
    {
        if(item.isEquipped)
        {
            player.Stats.attack += item.attack;
            player.Stats.defense += item.defense;
            player.Stats.health += item.health;
            player.Stats.critical += item.critical;
        }
        else
        {
            player.Stats.attack -= item.attack;
            player.Stats.defense -= item.defense;
            player.Stats.health -= item.health;
            player.Stats.critical -= item.critical;
        }

    }

}
