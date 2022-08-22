using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageButton : MonoBehaviour
{

    public GameObject DamageText;

    public void OnClick()
    {
        //                      発生位置(本来なら敵のtransform.position)                            発生させたいテキスト
        Instantiate(DamageText, new Vector3(0, 0, 0), transform.rotation).GetComponent<TextMesh>().text = "1";
    }
}