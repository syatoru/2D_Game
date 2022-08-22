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
        // �Ԃ������I�u�W�F�N�g��Wall��������
        if (col.gameObject.tag == "Wall")
        {
            Destroy(this.gameObject);
        }
        // ���̃I�u�W�F�N�g�̃^�O���v���C���[�̒e�łԂ������I�u�W�F�N�g���G��������
        if (this.gameObject.tag == "PlayerBullet" && col.gameObject.tag == "Enemy")
        {
            BulletPA = BulletPA + GameData.Player_PA;
            Destroy(this.gameObject);
        }
        // ���̃I�u�W�F�N�g�̃^�O���G�̒e�ł��Ԃ������I�u�W�F�N�g���v���[���[�ł����G���Ԃ���Ȃ�������
        if (this.gameObject.tag == "EnemyBullet" && col.gameObject.tag == "PlayerCollisionPoint" && Player_Move.isInvincibleTime == false)
        {
            BulletPA = BulletPA + Bullet_Create.EnemyPA;
            Destroy(this.gameObject);
        }
    }

}
