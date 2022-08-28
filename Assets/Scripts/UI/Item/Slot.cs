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
        // �A�C�e���̃C���[�W�𕡐�
        draggingObj = Instantiate(itemImageObj, canvasTransform);

        // �������őO�ʂɔz�u
        draggingObj.transform.SetAsLastSibling();

        // �������̐F���Â�����
        itemImage.color = Color.gray;

        // ����l�ɃA�C�e����n��
        hand.SetGrabbingItem(MyItem);

        KeyManager.slotActive = true;
    }

    public void OnDrag(PointerEventData eventData)
    {
        if (MyItem == null) return;
        // �������|�C���^�[��Ǐ]����悤�ɂ���
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
        //����l���A�C�e���������Ă��Ȃ������瑁�����^�[��
        if (!hand.IsHavingItem()) return;

        //����l����A�C�e�����󂯎��
        Item gotItem = hand.GetGrabbingItem();

        //���Ƃ��Ǝ����Ă����A�C�e���𒇉�l�ɓn��
        hand.SetGrabbingItem(MyItem);

        SetItem(gotItem);
    }

    //OnDrop����ɌĂ΂��
    public void OnEndDrag(PointerEventData eventData)
    {
        Destroy(draggingObj);
        //����l����A�C�e�����󂯎��
        Item gotItem = hand.GetGrabbingItem();
        SetItem(gotItem);
        Debug.Log("�ۑ����܂���");
        for (int i = 0; i < SlotGrid.slotNumber; i++)
        {
            Debug.Log(SlotGrid.Inventory[i]);
            GameData.bag[i] = SlotGrid.Inventory[i];
        }
        KeyManager.slotActive = false;
    }
}
