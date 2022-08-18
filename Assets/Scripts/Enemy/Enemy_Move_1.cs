using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_Move_1 : MonoBehaviour
{
    [Header("移動速度")] public float DefaultSpeed;
    [Header("画面外でも行動する")] public bool nonVisibleAct;
    public GameObject cubeA;
    public GameObject cubeB;
    #region//プライベート変数
    private Rigidbody2D rb = null;
    private SpriteRenderer sr = null;
    private GameObject playerObject;
    private Vector3 PlayerPosition;
    private Vector3 EnemyPosition;
    private float dis;
    private float Speed;
    #endregion

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        sr = GetComponent<SpriteRenderer>();
        playerObject = GameObject.FindWithTag("Player");

        PlayerPosition = playerObject.transform.position;
        EnemyPosition = transform.position;

    }

    void Update()
    {
        Vector3 posA = cubeA.transform.position;
        Vector3 posB = cubeB.transform.position;
        dis = Vector3.Distance(posA, posB);
        Debug.Log("距離 : " + dis);
    }

    private void FixedUpdate()
    {
        //画面内
        if (sr.isVisible || nonVisibleAct)
        {
            if(dis < 1.5f)
            {
                Debug.Log("距離が1以下");
                Bullet_Create.EnemyAttack = true;
                Freeze();
            }
            else
            {
                // スピードを元に戻す
                Speed = DefaultSpeed;
                //行動する
                PlayerPosition = playerObject.transform.position;
                EnemyPosition = transform.position;

                EnemyPosition.x += (PlayerPosition.x - EnemyPosition.x) * Speed;
                EnemyPosition.y += (PlayerPosition.y - EnemyPosition.y) * Speed;
                transform.position = EnemyPosition;

            }
        }
        //画面外
        else
        {
            rb.Sleep();
        }
    }
    void OnTriggerEnter2D(Collider2D col)
    {
        // ぶつかったオブジェクトがプレイヤーの弾だったら
        if (col.gameObject.tag == "PlayerBullet")
        {
            // 敵HPを攻撃力分減らす
            Enemy_Status.HP -= Player_Status.AT;
            Debug.Log("攻撃命中残りHP" + Enemy_Status.HP);
        }
    }

    void Freeze()
    {
        Speed = 0;
        rb.Sleep();
    }

}
