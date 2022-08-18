using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_Move_1 : MonoBehaviour
{
    [Header("�ړ����x")] public float speed;
    [Header("��ʊO�ł��s������")] public bool nonVisibleAct;
    #region//�v���C�x�[�g�ϐ�
    private Rigidbody2D rb = null;
    private SpriteRenderer sr = null;
    private GameObject playerObject;
    private Vector3 PlayerPosition;
    private Vector3 EnemyPosition;
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
    }

    private void FixedUpdate()
    {
        //��ʓ�
        if (sr.isVisible || nonVisibleAct)
        {
            //�s������
            PlayerPosition = playerObject.transform.position;
            EnemyPosition = transform.position;

            EnemyPosition.x += (PlayerPosition.x - EnemyPosition.x) * speed;
            EnemyPosition.y += (PlayerPosition.y - EnemyPosition.y) * speed;
            transform.position = EnemyPosition;

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

}
