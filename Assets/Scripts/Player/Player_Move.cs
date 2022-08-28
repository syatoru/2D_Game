using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class Player_Move : MonoBehaviour
{
    #region // �ϐ��錾
    private float DefaultSpeed;
    public bool isRun;
    public static bool isInvincibleTime = false;

    private Rigidbody2D rb = default;
    private Animator anim = null;

    // �ŏI�I�ȑ��x
    private float Speed;

    Camera targetCamera;

    private float PlayerCameraDistance;

    private bool Direction = false;

    // Vertical��Horizontal�p�ϐ�
    private float v, h;

    private bool isAttack = true;

    // Rolling�p�ϐ�
    private int Rolling_Direction = 0;
    private float Rolling_CT = 0.5f;
    private int Rolling_i = 0;
    private bool Rolling_f = false;
    private bool isRolling = true;
    #endregion

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        DefaultSpeed = GameData.Player_SPEED;
        Speed = DefaultSpeed;
        targetCamera = Camera.main;
    }

    private void Update()
    {

        v = Input.GetAxisRaw("Vertical");
        h = Input.GetAxisRaw("Horizontal");
        if (Input.GetKeyDown("space"))
        {
            Rolling_f = true;
        }
        //�@�^�u��������Ă��Ȃ���
        if(KeyManager.TabActive == false)MouseLeftClick();


        if (Input.GetMouseButtonDown(1))
        {

        }
    }

    void FixedUpdate()
    {
        // �}�E�X�̌����Ă�������𒲂ׂ�
        MouseDirection();
        // ���[�����O����
        if (Rolling_f == true && isRolling == true)
        {
            Rolling();
        }

        //�@���菈��
        Run();

        // �}�E�X�̌����Ă�������ɉ摜�𔽓]
        Reversal();
    }

    // ���鏈��
    private void Run()
    {
        if (h > 0 || v > 0)
        {
            isRun = true;
        }
        else if (h < 0 || v < 0)
        {
            isRun = true;
        }
        else
        {
            isRun = false;

        }
        rb.velocity = new Vector2(h, v).normalized * Speed;
        anim.SetBool("run", isRun);
        Speed = DefaultSpeed;
    }

    private void Attack()
    {
        // �v���C���[�̒e�𐶐�
        Bullet_Create.PlayerAttack = true;
    }
    // ���[�����O����
    private void Rolling()
    {
        Speed = DefaultSpeed + 5;
        isInvincibleTime = true;
        // �������Ƃ��̌�����ێ�(1��2�E)
        if (Direction == true && Rolling_Direction == 0) Rolling_Direction = 1;
        else if (Direction == false && Rolling_Direction == 0) Rolling_Direction = 2;

        // ���������獶��]�A�E��������E��]
        if (Rolling_Direction == 1) Rolling_i += 30;
        else if (Rolling_Direction == 2) Rolling_i -= 30;

        // ��]
        transform.rotation = Quaternion.Euler(0, 0, Rolling_i);

        // ���[�����O���I�������I������
        if (Rolling_i == 360 || Rolling_i == -360)
        {
            isInvincibleTime = false;
            Rolling_f = false;
            Rolling_Direction = 0;
            Rolling_i = 0;
            StartCoroutine(RollingCoolTime(Rolling_CT));
        }
    }

    // ���[�����O�N�[���^�C������(�N�[���^�C��)
    private IEnumerator RollingCoolTime(float ct)
    {
        isRolling = false;
        yield return new WaitForSeconds(ct);
        isRolling = true;
    }

    // �A�^�b�N�N�[���^�C������(�N�[���^�C��)
    private IEnumerator AttackCoolTime(float ct)
    {
        isAttack = false;
        yield return new WaitForSeconds(ct);
        isAttack = true;
    }


    // �}�E�X�̌����𒲂ׂ�
    private void MouseDirection()
    {
        // �}�E�X�̃��[���h���W�擾
        Vector3 mousePos = Input.mousePosition;
        
        // �I�u�W�F�N�g�̃��[���h���W�擾
        var targetWorldPos = this.transform.position;
        // ���[���h�̃X�N���[�����W�ɕϊ�
        var targetScreenPos = targetCamera.WorldToScreenPoint(targetWorldPos);

        if (mousePos.x > targetScreenPos.x)
        {
            Direction = false;
        }
        else
        {
            Direction = true;
        }
    }

    // ���N���b�N���̏���
    private void MouseLeftClick()
    {
        if (Input.GetMouseButtonDown(0) && isAttack == true)
        {
            Attack();
            StartCoroutine(AttackCoolTime(0.15f));
        }
        else if (Input.GetMouseButton(0) && isAttack == true)
        {
            Attack();
        }
        else if (Input.GetMouseButtonUp(0) && isAttack == true)
        {
            Bullet_Create.PlayerAttack = false;
        }
    }

    // �����ύX
    private void Reversal()
    {
        if (!Direction)
        {
            transform.localScale = new Vector3(3, 3, 1);
        }
        else
        {
            transform.localScale = new Vector3(-3, 3, 1);
        }
    }

    // ���G�擾
    public bool Get_isInvincibleTime()
    {
        return isInvincibleTime;
    }

}
