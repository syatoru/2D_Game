using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Status : MonoBehaviour
{
    public static float HP;
    public static float SP;
    public static float AT;
    public static float EXP;
    public static float TotalExp;
    private float NextExp;
    private static int LEVEL;

    private void Start()
    {
        HP = 100;
        SP = 100;
        AT = 10;
        EXP = 0;
        TotalExp = 0;
        LEVEL = 0;
        NextExp = LEVEL * (LEVEL + 1) * (LEVEL + 2) * (LEVEL + 3) + 3000;
    }

    private void Update()
    {
        if(EXP > NextExp)
        {
            LevelUp();
        }
    }
    void LevelUp()
    {
        LEVEL += 1;
        EXP -= NextExp;
        NextExp = LEVEL * (LEVEL + 1) * (LEVEL + 2) * (LEVEL + 3) + 3000;
        Debug.Log("レベルアップ");
        Debug.Log("現在のレベル" + LEVEL);
        Debug.Log("次に必要な経験値" + NextExp);
    }
}
