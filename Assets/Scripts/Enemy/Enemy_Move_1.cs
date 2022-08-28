using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Enemy_Move_1 : MonoBehaviour
{
    public List<EnemyData> enemyDatabase;
    [Header("��ʊO�ł��s������")] public bool nonVisibleAct;
    public GameObject Player;
    public GameObject Enemy;
    public GameObject DamageText;
    #region//�v���C�x�[�g�ϐ�
    private Rigidbody2D rb = null;
    private SpriteRenderer sr = null;
    private GameObject playerObject;
    private Vector3 PlayerPosition;
    private Vector3 EnemyPosition;
    private float dis;

    // �G�X�e�[�^�X
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
        // �G�ƃv���C���[�Ƃ̋���
        Vector3 Player_pos = Player.transform.position;
        Vector3 Enemy_pos = Enemy.transform.position;
        dis = Vector3.Distance(Player_pos, Enemy_pos);

        // HP��0�ɂȂ�����
        if (HP <= 0)
        {
            GameData.Player_EXP += EXP;
            Destroy(this.gameObject);
        }
    }

    private void FixedUpdate()
    {
        //��ʓ�
        if (sr.isVisible || nonVisibleAct)
        {
            // �X�s�[�h�����ɖ߂�
            Speed_Now = Speed;
            // �s���������
            ConditionsAct(Pattern);

            // �G�̍s��
            if (isAct == true)
            {
                // �s����true���������ɂ��鏈��
                IsActTrue(Pattern);
            }
            else
            {
                // �s����false���������ɂ��鏈��
                IsActFalse(Pattern);
            }
        }
        //��ʊO
        else
        {
            ConditionsNonVisibleAct(Pattern);
        }
    }

    // �e���Ԃ�������
    void OnTriggerEnter2D(Collider2D col)
    {
        // �Ԃ������I�u�W�F�N�g���v���C���[�̒e��������
        if (col.gameObject.tag == "PlayerBullet")
        {
            float rnd = Random.Range(0.85f, 1.0f);
            // (�v���C���[�̍U���� + �e�̍U����) / (�G�̖h��� / 50 + 2) * (0.85�`1.0)
            float Attack = (float)Mathf.Round((col.GetComponent<Bullet>().BulletPA) / (DF / 50 + 2) * rnd);

            // �GHP���U���͕����炷
            HP -= Attack;
            Debug.Log("�_���[�W" + Attack);
            // �_���[�W�e�L�X�g�\��
            Instantiate(DamageText, this.transform.position, transform.rotation).GetComponent<TextMesh>().text = Attack.ToString();
            Debug.Log("�U�������c��HP" + HP);
        }
    }

    // �s������
    void ConditionsAct(int Pattern)
    {
        switch (Pattern)
        {
            case 1:
                // �v���C���[�ƓG�Ƃ̋�����4.0f���߂�������s��
                if (dis < 4.0f)
                {
                    isAct = true;
                }
                else
                {
                    isAct = false;
                }
                break;

            // �萔�Ɉ�v���Ȃ������牽�����Ȃ�
            default:
                break;
        }
    }

    // �U�����Ă��鎞
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
    // �U�����Ă��Ȃ��Ƃ�
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
    //�@��ʊO�̍s��
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
    // �s�����~�߂�
    void Freeze()
    {
        Speed_Now = 0;
        rb.Sleep();
    }

}
