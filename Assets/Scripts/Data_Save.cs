using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Data_Save : MonoBehaviour
{
    public int Player_LV;
    // Start is called before the first frame update
    void Start()
    {

    }
    // íœ‚Ìˆ—
    void OnDestroy()
    {

    }

    // Update is called once per frame
    void Update()
    {
    }
    
    void LEVELUP()
    {
        Player_LV += 1;
        Debug.Log(Player_LV);
    }
}
