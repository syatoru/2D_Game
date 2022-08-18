using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_Move_1 : MonoBehaviour
{
    [Header("�ړ����x")] public float DefaultSpeed;
    [Header("��ʊO�ł��s������")] public bool nonVisibleAct;
    public GameObject cubeA;
    public GameObject cubeB;
    #region//�v���C�x�[�g�ϐ�
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
        Debug.Log("���� : " + dis);
    }

    private void FixedUpdate()
    {
        //��ʓ�
        if (sr.isVisible || nonVisibleAct)
        {
            if(dis < 1.5f)
            {
                Debug.Log("������1�ȉ�");
                Bullet_Create.EnemyAttack = true;
                Freeze();
            }
            else
            {
                // �X�s�[�h�����ɖ߂�
                Speed = DefaultSpeed;
                //�s������
                PlayerPosition = playerObject.transform.position;
                EnemyPosition = transform.position;

                EnemyPosition.x += (PlayerPosition.x - EnemyPosition.x) * Speed;
                EnemyPosition.y += (PlayerPosition.y - EnemyPosition.y) * Speed;
                transform.position = EnemyPosition;

            }
        }
        //��ʊO
        else
        {
            rb.Sleep();
        }
    }
    void OnTriggerEnter2D(Collider2D col)
    {
        // �Ԃ������I�u�W�F�N�g���v���C���[�̒e��������
        if (col.gameObject.tag == "PlayerBullet")
        {
            // �GHP���U���͕����炷
            Enemy_Status.HP -= Player_Status.AT;
            Debug.Log("�U�������c��HP" + Enemy_Status.HP);
        }
    }

    void Freeze()
    {
        Speed = 0;
        rb.Sleep();
    }

}
