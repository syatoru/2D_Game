using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class CT_Change : MonoBehaviour
{
    public Image UIobj;
    public bool roop;
    public float countTime = 5.0f;
    // Update is called once per frame
    void Update()
    {
        if (roop)
        {
            UIobj.fillAmount -= 1.0f / countTime * Time.deltaTime;
        }
        else
        {
            UIobj.fillAmount += 1.0f / countTime * Time.deltaTime;
        }
    }
}
