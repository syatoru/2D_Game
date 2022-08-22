using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float BulletPA;
    public float BulletCT;
    public float BulletSPEED;
    public float BulletDeleteTime;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void OnTriggerEnter2D(Collider2D col)
    {
        // ぶつかったオブジェクトがWallだったら
        if (col.gameObject.tag == "Wall")
        {
            Destroy(this.gameObject);
        }
        // このオブジェクトのタグがプレイヤーの弾でぶつかったオブジェクトが敵だったら
        if (this.gameObject.tag == "PlayerBullet" && col.gameObject.tag == "Enemy")
        {
            BulletPA = BulletPA + GameData.Player_PA;
            Destroy(this.gameObject);
        }
        // このオブジェクトのタグが敵の弾でかつぶつかったオブジェクトがプレーヤーでかつ無敵時間じゃなかったら
        if (this.gameObject.tag == "EnemyBullet" && col.gameObject.tag == "PlayerCollisionPoint" && Player_Move.isInvincibleTime == false)
        {
            BulletPA = BulletPA + Bullet_Create.EnemyPA;
            Destroy(this.gameObject);
        }
    }

}
