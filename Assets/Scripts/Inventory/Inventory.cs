using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class Inventory : ScriptableObject
{
    public Item currentItem;
    public List<Item> items = new List<Item>();

    public void InitInventory()
    {
        items.Clear();
    }

    public void AddItem(Item itemToAdd){
            items.Add(itemToAdd);
            currentItem = itemToAdd;
    }

    public bool checkContains(Item itemContents){
        return (items.Contains(itemContents));  
    }
}
