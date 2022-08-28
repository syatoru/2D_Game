using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName ="Items",menuName ="Ž©ìƒf[ƒ^/item")]
public class Item : ScriptableObject
{
    [SerializeField]
    private string itemName;
    [SerializeField]
    private Sprite itemImage;
    public string MyItemName { get => itemName;}
    public Sprite MyItemImage { get => itemImage; }
}
