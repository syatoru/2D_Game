using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageButton : MonoBehaviour
{

    public GameObject DamageText;

    public void OnClick()
    {
        //                      �����ʒu(�{���Ȃ�G��transform.position)                            �������������e�L�X�g
        Instantiate(DamageText, new Vector3(0, 0, 0), transform.rotation).GetComponent<TextMesh>().text = "1";
    }
}