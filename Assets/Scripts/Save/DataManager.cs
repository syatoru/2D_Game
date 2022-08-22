using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DataManager : MonoBehaviour
{
    public static DataManager instance = null;
    //クラスの参照
    public Save saveClass;
    public Read readClass;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(this.gameObject);
        }
        else
        {
            Destroy(this.gameObject);
        }
        Read();
        Save();
        Read();
        Debug.Log("Player_LV:" + GameData.Player_LV);
        Debug.Log("Player_LP:" + GameData.Player_LP);
        Debug.Log("Player_EXP:" + GameData.Player_EXP);
        Debug.Log("Player_NEXT_EXP:" + GameData.Player_NEXT_EXP);
        Debug.Log("Player_HP_Max:" + GameData.Player_HP_Max);
        Debug.Log("Player_MP_Max:" + GameData.Player_MP_Max);
        Debug.Log("Player_SP:" + GameData.Player_SP);
        Debug.Log("Player_PA:" + GameData.Player_PA);
        Debug.Log("Player_MA:" + GameData.Player_MA);
        Debug.Log("Player_DF:" + GameData.Player_DF);
        Debug.Log("Player_RT:" + GameData.Player_RT);
        Debug.Log("Player_SPEED:" + GameData.Player_SPEED);

        Debug.Log("Player_HP_Now:" + GameData.Player_HP_Now);
        Debug.Log("Player_MP_Now:" + GameData.Player_MP_Now);

    }

    // ゲーム終了時
    private void OnApplicationQuit()
    {
        Debug.Log("OnApplicationQuit");
        Save();
        Read();

    }

    public void Read()
    {
        //読み込む
        readClass.enabled = true;
        Debug.Log("読み込みがおわりました");
    }

    public void Save()
    {
        //セーブする
        saveClass.enabled = true;
        Debug.Log("セーブができました");
    }

    public void FirstSet()
    {
        Debug.Log("初期設定");
        GameData.Player_LV = 0;
        GameData.Player_LP = 10;
        GameData.Player_EXP = 0;
        GameData.Player_NEXT_EXP = 0 * (0 + 1) * (0 + 2) * (0 + 3) + 1000;
        GameData.Player_HP_Max = 100;
        GameData.Player_MP_Max = 100;
        GameData.Player_SP = 100;
        GameData.Player_PA = 10;
        GameData.Player_MA = 10;
        GameData.Player_DF = 1;
        GameData.Player_RT = 0;
        GameData.Player_SPEED = 7;

        GameData.Player_HP_Now = GameData.Player_HP_Max;
        GameData.Player_MP_Now = GameData.Player_MP_Max;
        Save();
        Read();
    }
}