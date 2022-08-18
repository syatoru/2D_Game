using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet_Create : MonoBehaviour
{
    public GameObject Bullet;
    public GameObject AttackPoint;
    public GameObject Target;
    public static bool PlayerAttack;
    public static bool EnemyAttack;
    public float speed;
    public float deleteTime;

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 AttackPointPos = AttackPoint.transform.position;

        if (PlayerAttack == true && this.gameObject.tag == "PlayerAttackPoint")
        {
            
            // クリックした座標の取得（スクリーン座標からワールド座標に変換）
            Vector3 mouseWorldPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);

            // 向きたい方向を計算
            Vector3 dir = (mouseWorldPos - AttackPointPos);

            Vector3 shotForward = Vector3.Scale(dir, new Vector3(1, 1, 0)).normalized;


            GameObject clone = Create(mouseWorldPos);
            clone.gameObject.tag = "PlayerBullet";
            clone.transform.rotation = Quaternion.FromToRotation(Vector3.up, shotForward);
            PlayerAttack = false;
            Destroy(clone, deleteTime);
        }
        if(EnemyAttack == true && this.gameObject.tag == "EnemyAttackPoint")
        {
            Vector3 TargetPos = Target.transform.position;
            
            // 向きたい方向を計算
            Vector3 dir = (TargetPos - AttackPointPos);
            // 向きたい方向に回転
            //AttackPoint.transform.rotation = Quaternion.FromToRotation(Vector3.up, dir);

            GameObject clone = Create(TargetPos);
            clone.gameObject.tag = "EnemyBullet";
            clone.transform.rotation = Quaternion.FromToRotation(Vector3.up, dir);
            EnemyAttack = false;
            Destroy(clone, deleteTime);
        }
        
    }

    GameObject Create(Vector3 Pos)
    {
        // 弾（ゲームオブジェクト）の生成
        GameObject clone = Instantiate(Bullet, transform.position, Quaternion.identity);

        // 向きの生成（Z成分の除去と正規化）
        Vector3 shotForward = Vector3.Scale((Pos - transform.position), new Vector3(1, 1, 0)).normalized;

        // 弾に速度を与える
        clone.GetComponent<Rigidbody2D>().velocity = shotForward * speed;
        return clone;
    }
}
