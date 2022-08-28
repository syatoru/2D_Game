using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SlotGrid : MonoBehaviour
{
    [SerializeField]
    GameObject slotPrefab;
    public static int slotNumber = 21;

    [SerializeField]
    private Item[] allItems;

    [SerializeField]
    private List<Slot> allSlots;

    //  slotGridに入っている添え字に番号をそれ以外には255
    public static byte[] Inventory = new byte[21];

    private void Start()
    {
        SlotSet();
    }

    public void SlotSet()
    {
        allSlots = new List<Slot>();
        for (int i = 0; i < slotNumber; i++)
        {
            GameObject slotObj = Instantiate(slotPrefab, this.transform);

            Slot slot = slotObj.GetComponent<Slot>();
            slot.MyNumber = i;
            allSlots.Add(slot);
            Inventory[i] = GameData.bag[i];

            // アイテムすべてを調べてバッグの中にあったらアイテムをスロットに追加
            for (int j = 0; j < allItems.Length; j++)
            {
                if (GameData.bag[i] == j)
                {
                    Inventory[i] = (byte)j;
                    slot.SetItem(allItems[j]);
                }
            }
        }
        for (int i = 0; i < slotNumber; i++) Debug.Log(Inventory[i]);
    }


    public bool AddItem(Item item)
    {
        foreach(var slot in allSlots)
        {
            if (slot.MyItem == null)
            {
                slot.SetItem(item);
                return true;
            }
        }
        return false;
    }
}
