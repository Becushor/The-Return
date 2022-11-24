using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public Location currentLocation;

    public List<Item> inventory = new List<Item>();

    void Start()
    {
        
    }

    void Update()
    {
        
    }

    //ChangeLocation method moves the player to the "connectionNoun" location
    public bool ChangeLocation(GameController controller, string connectionNoun)
    {
        Connection connection = currentLocation.GetConnection(connectionNoun);
        if (connection != null)
        {
            if (connection.connectionEnabled)
            {
                currentLocation = connection.location;
                return true;
            }
        }
        return false;
    }

    internal bool CanTalkToItem(GameController controller, Item item)
    {
        return item.playerCanTalkTo;
    }

    internal bool CanUseItem(GameController controller, Item item)
    {
        if (item.targetItem == null)
            return true;

        if (HasItem(item.targetItem))
            return true;

        if (currentLocation.HasItem(item.targetItem))
            return true;

        return false;
    }

    private bool HasItem(Item itemToCheck)
    {
        foreach (Item item in inventory)
        {
            if (item == itemToCheck)
                return true;
        }
        return false;
    }
}
