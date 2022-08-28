using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyManager : MonoBehaviour
{
    public static bool TabActive;
    public static bool slotActive;
    GameObject slotGrid;
    GameObject handObj;
    //gameObject.SetActive(KeyManager.TabActive);
    // 初期値
    private void Start()
    {
        TabActive = false;
        slotActive = false; // アイテムドラッグ中はtrue
        slotGrid = GameObject.FindWithTag("SlotGrid");
        handObj = GameObject.FindWithTag("Hand");
    }

    // Update is called once per frame
    void Update()
    {
        if (slotActive == false)
        {
            slotGrid.SetActive(TabActive);
            if (Input.GetKeyDown(KeyCode.Tab))
            {
                Debug.Log("タブ押された");
                if (TabActive == false)
                    TabActive = true;
                else if (TabActive == true)
                    TabActive = false;
            }
        }
    }
}
