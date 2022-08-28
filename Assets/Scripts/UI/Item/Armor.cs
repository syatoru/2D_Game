using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Items",menuName = "Ž©ìƒf[ƒ^/armor")]
public class Armor : Item
{
    [SerializeField]
    private int ArmorID;
    public int MyArmorID { get => ArmorID; }

    [SerializeField]
    private float atk;
    public float MyAtk { get => atk; }
    [SerializeField]
    private float crt;
    public float MyCrt { get => crt; }

    [SerializeField]
    private float clt;
    public float MyClt { get => clt; }

    [SerializeField]
    private GameObject Bullet;

    public GameObject MyBullet { get => Bullet; }

}
