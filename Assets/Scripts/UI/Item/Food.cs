using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName ="Items",menuName = "Ž©ìƒf[ƒ^/food")]
public class Food : Item
{
    [SerializeField]
    private int hpChange;
    public int HpChange { get => hpChange; }

    [SerializeField]
    private int mpChange;

    public int MpChange { get => mpChange; }

    public void Eat(Player player)
    {
        player.ChangeHp(hpChange);
    }
}
