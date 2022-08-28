using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LookRotation : MonoBehaviour
{
    Camera targetCamera;

    private void Start()
    {
        targetCamera = Camera.main;
    }

    private void Update()
    {
        // マウスのワールド座標取得
        Vector2 mousePos = Input.mousePosition;
        Debug.Log(mousePos);
        // オブジェクトのワールド座標取得
        Vector2 targetWorldPos = this.transform.position;
        // ワールドのスクリーン座標に変換
        Vector2 targetScreenPos = targetCamera.WorldToScreenPoint(targetWorldPos);
        // 向きたい方向を計算
        Vector2 dir = (mousePos - targetScreenPos);

        // ここで向きたい方向に回転させてます
        this.transform.rotation = Quaternion.FromToRotation(Vector2.up, dir);
    }

}
