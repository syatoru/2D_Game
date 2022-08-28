using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemObject : MonoBehaviour
{
    private Item Item { get; set; }
    public void OnMakeObject(Item item)
    {
        Item = item;
    }
}
