using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_hit : MonoBehaviour
{
    // �����蔻��ɓ���������
    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.tag == "EnemyBullet" && Player_Move.isInvincibleTime == false)
        {
            Debug.Log("������܂���");
            GameData.Player_HP_Now -= (float)Mathf.Round(col.GetComponent<Bullet>().BulletPA / (GameData.Player_DF / 50 + 2)) ;
            Debug.Log(GameData.Player_HP_Now);
        }
    }
}
