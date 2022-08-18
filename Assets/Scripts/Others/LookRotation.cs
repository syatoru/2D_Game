using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LookRotation : MonoBehaviour
{
    public Transform arrowTrans; // 動かすオブジェクトのトランスフォーム
    public Transform ballTrans; // ターゲットのオブジェクトのトランスフォーム

    private void Update()
    {
        // 向きたい方向を計算
        Vector3 dir = (ballTrans.position - arrowTrans.position);

        // ここで向きたい方向に回転させてます
        arrowTrans.rotation = Quaternion.FromToRotation(Vector3.up, dir);
    }

}
