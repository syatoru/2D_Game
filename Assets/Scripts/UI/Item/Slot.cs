using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class Slot : MonoBehaviour,IBeginDragHandler,IDragHandler,IDropHandler,IEndDragHandler
{
    private Item item;

    [SerializeField]
    protected Image itemImage;

    private GameObject draggingObj;

    [SerializeField]
    private GameObject itemImageObj;

    private Transform canvasTransform;

    private Hand hand;

    private int num;
    public int MyNumber { get => num; set => num = value; }
    public Item MyItem { get => item; protected set => item = value; }

    protected virtual void Start()
    {
        canvasTransform = FindObjectOfType<Canvas>().transform;

        hand = FindObjectOfType<Hand>();

        if (MyItem == null) itemImage.color = new Color(0, 0, 0, 0);
    }

    public void OnBeginDrag(PointerEventData eventData)
    {
        if (MyItem == null) return;
        // アイテムのイメージを複製
        draggingObj = Instantiate(itemImageObj, canvasTransform);

        // 複製を最前面に配置
        draggingObj.transform.SetAsLastSibling();

        // 複製元の色を暗くする
        itemImage.color = Color.gray;

        // 仲介人にアイテムを渡す
        hand.SetGrabbingItem(MyItem);

        KeyManager.slotActive = true;
    }

    public void OnDrag(PointerEventData eventData)
    {
        if (MyItem == null) return;
        // 複製がポインターを追従するようにする
        draggingObj.transform.position
            = eventData.position + new Vector2(20,20);
    }

    public virtual void SetItem(Item item)
    {
        MyItem = item;
        if (item != null)
        {
            itemImage.color = new Color(1, 1, 1, 1);
            itemImage.sprite = item.MyItemImage;
            if(GameData.items != null)
                for (int j = 0; j < GameData.items.Length; j++)
                {
                
                    if (item.MyItemImage.name == GameData.items[j].MyItemImage.name)
                    {
                       SlotGrid.Inventory[num] = (byte)j;
                    }
                }
        }
        else
        {
            SlotGrid.Inventory[num] = 255;
            itemImage.color = new Color(0, 0, 0, 0);
        }
    }

    public void OnDrop(PointerEventData eventData)
    {
        //仲介人がアイテムを持っていなかったら早期リターン
        if (!hand.IsHavingItem()) return;

        //仲介人からアイテムを受け取る
        Item gotItem = hand.GetGrabbingItem();

        //もともと持っていたアイテムを仲介人に渡す
        hand.SetGrabbingItem(MyItem);

        SetItem(gotItem);
    }

    //OnDropが先に呼ばれる
    public void OnEndDrag(PointerEventData eventData)
    {
        Destroy(draggingObj);
        //仲介人からアイテムを受け取る
        Item gotItem = hand.GetGrabbingItem();
        SetItem(gotItem);
        Debug.Log("保存しました");
        for (int i = 0; i < SlotGrid.slotNumber; i++)
        {
            Debug.Log(SlotGrid.Inventory[i]);
            GameData.bag[i] = SlotGrid.Inventory[i];
        }
        KeyManager.slotActive = false;
    }
}
