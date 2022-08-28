using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Player_Slot : Slot
{
    private Player player;

    public Player MyPlayer { get => player; private set => player = value; }

    // Start is called before the first frame update
    protected override void Start()
    {
        base.Start();
        MyPlayer = FindObjectOfType<Player>();
    }

    public override void SetItem(Item item)
    {
        MyPlayer.RemoveItem(MyItem);
        MyPlayer.SetItem(item);

        MyItem = item;

        if (item != null)
        {
            itemImage.color = new Color(1, 1, 1, 1);
            itemImage.sprite = item.MyItemImage;
        }
        else
        {
            itemImage.color = new Color(0, 0, 0, 0);
        }
    }
}
