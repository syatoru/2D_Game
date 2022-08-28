using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Enemy_Move_1 : MonoBehaviour
{
    public List<EnemyData> enemyDatabase;
    [Header("画面外でも行動する")] public bool nonVisibleAct;
    public GameObject Player;
    public GameObject Enemy;
    public GameObject DamageText;
    #region//プライベート変数
    private Rigidbody2D rb = null;
    private SpriteRenderer sr = null;
    private GameObject playerObject;
    private Vector3 PlayerPosition;
    private Vector3 EnemyPosition;
    private float dis;

    // 敵ステータス
    private int Pattern;
    private float HP;
    private float DF;
    private float PA;
    private float EXP;
    private float Speed;
    private float Speed_Now;

    private bool isAct;

    #endregion

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        sr = GetComponent<SpriteRenderer>();
        playerObject = GameObject.FindWithTag("Player");

        PlayerPosition = playerObject.transform.position;
        EnemyPosition = transform.position;

        EnemyData data = enemyDatabase[0];

        Pattern = data.EnemyPattern;
        HP = data.EnemyHP;
        DF = data.EnemyDF;
        PA = data.EnemyPA;
        EXP = data.EnemyEXP;
        Speed = data.EnemySpeed;
        Speed_Now = Speed;
    }

    void Update()
    {
        // 敵とプレイヤーとの距離
        Vector3 Player_pos = Player.transform.position;
        Vector3 Enemy_pos = Enemy.transform.position;
        dis = Vector3.Distance(Player_pos, Enemy_pos);

        // HPが0になったら
        if (HP <= 0)
        {
            GameData.Player_EXP += EXP;
            Destroy(this.gameObject);
        }
    }

    private void FixedUpdate()
    {
        //画面内
        if (sr.isVisible || nonVisibleAct)
        {
            // スピードを元に戻す
            Speed_Now = Speed;
            // 行動する条件
            ConditionsAct(Pattern);

            // 敵の行動
            if (isAct == true)
            {
                // 行動がtrueだった時にする処理
                IsActTrue(Pattern);
            }
            else
            {
                // 行動がfalseだった時にする処理
                IsActFalse(Pattern);
            }
        }
        //画面外
        else
        {
            ConditionsNonVisibleAct(Pattern);
        }
    }

    // 弾がぶつかったら
    void OnTriggerEnter2D(Collider2D col)
    {
        // ぶつかったオブジェクトがプレイヤーの弾だったら
        if (col.gameObject.tag == "PlayerBullet")
        {
            float rnd = Random.Range(0.85f, 1.0f);
            // (プレイヤーの攻撃力 + 弾の攻撃力) / (敵の防御力 / 50 + 2) * (0.85～1.0)
            float Attack = (float)Mathf.Round((col.GetComponent<Bullet>().BulletPA) / (DF / 50 + 2) * rnd);

            // 敵HPを攻撃力分減らす
            HP -= Attack;
            Debug.Log("ダメージ" + Attack);
            // ダメージテキスト表示
            Instantiate(DamageText, this.transform.position, transform.rotation).GetComponent<TextMesh>().text = Attack.ToString();
            Debug.Log("攻撃命中残りHP" + HP);
        }
    }

    // 行動条件
    void ConditionsAct(int Pattern)
    {
        switch (Pattern)
        {
            case 1:
                // プレイヤーと敵との距離が4.0fより近かったら行動
                if (dis < 4.0f)
                {
                    isAct = true;
                }
                else
                {
                    isAct = false;
                }
                break;

            // 定数に一致しなかったら何もしない
            default:
                break;
        }
    }

    // 攻撃している時
    void IsActTrue(int Pattern)
    {
        switch (Pattern)
        {
            case 1:
                Bullet_Create.EnemyPA = PA;
                Bullet_Create.EnemyAttack = true;
                Freeze();
                break;
            default:
                break;
        }
    }
    // 攻撃していないとき
    void IsActFalse(int Pattern)
    {
        switch (Pattern)
        {
            case 1:
                PlayerPosition = playerObject.transform.position;
                EnemyPosition = transform.position;

                EnemyPosition.x += (PlayerPosition.x - EnemyPosition.x) * Speed_Now;
                EnemyPosition.y += (PlayerPosition.y - EnemyPosition.y) * Speed_Now;
                transform.position = EnemyPosition;
                break;
            default:
                break;
        }
    }
    //　画面外の行動
    void ConditionsNonVisibleAct(int Pattern)
    {
        switch (Pattern) {
            case 1:
                rb.Sleep();
                break;
            default:
                break;
        }

    }
    // 行動を止める
    void Freeze()
    {
        Speed_Now = 0;
        rb.Sleep();
    }

}
