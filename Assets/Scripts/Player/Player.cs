using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Player : MonoBehaviour,IDropHandler,IPointerClickHandler
{
    private List<Item> items = new List<Item>();

    [SerializeField]
    private int atk;

    [SerializeField]
    private int maxHp;

    private int hp;

    private Hand hand;

    private void Start()
    {
        hp = 70;

        hand = FindObjectOfType<Hand>();
    }

    public void ChangeHp(int delta)
    {
        int testHp = MyHp + delta;
        if (testHp < 0) MyHp = 0;
        else if (testHp > maxHp) MyHp = maxHp;
        else MyHp = testHp;

        Debug.Log("現在のHPは" + MyHp + "です");
    }

    public int MyHp
    {
        get
        {
            return hp;
        }
        private set
        {
            hp = value;
        }
    }

    public int MyAtk
    {
        get
        {
            int itemAtk = 0;

            foreach (Item item in MyItems)
            {
                Armor armor = item as Armor;

                if (armor != null) itemAtk += (int)armor.MyAtk;
            }

            return atk + itemAtk;
        }

    }

    public List<Item> MyItems { get => items; private set => items = value; }


    public void SetItem(Item item)
    {
        if(item!=null)MyItems.Add(item);
    }

    public void RemoveItem(Item item)
    {
        if (item != null) MyItems.Remove(item);
    }

    public void OnDrop(PointerEventData eventData)
    {
        Item gotItem = hand.GetGrabbingItem();

        Food food = gotItem as Food;
        // ゲットしたアイテムがFoodなら食べる
        if (food != null) food.Eat(this);

        // Foodじゃないならhandに返す
        else hand.SetGrabbingItem(gotItem);
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        Debug.Log("攻撃力は" + MyAtk + "です");
        Debug.Log("所持アイテムは" + MyItems.Count + "です");
    }
}
