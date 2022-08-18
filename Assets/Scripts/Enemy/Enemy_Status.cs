using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_Status : MonoBehaviour
{
    public int EnemyId;
    private int[] EnemyHpTable = {0,100,300,400};
    private int[] EnemyAtTable = {0,10,30,40};
    public static float HP;
    public static float AT;
    public static float CT;

    // Start is called before the first frame update
    void Start()
    {
        HP = EnemyHpTable[EnemyId];
        AT = EnemyAtTable[EnemyId];
    }

    // Update is called once per frame
    void Update()
    {
        if (HP <= 0)
        {
            Player_Status.EXP += 3000;
            Destroy(this.gameObject);
        }
    }
}
