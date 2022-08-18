using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class Player_Move : MonoBehaviour
{
    #region // �ϐ��錾
    [Header("�f�t�H���g���x")] public float DefaultSpeed;
    public bool isRun;

    private Rigidbody2D rb = default;
    private Animator anim = null;

    // �ŏI�I�ȑ��x
    private float Speed;

    private bool Direction = false;

    // Vertical��Horizontal�p�ϐ�
    private float v, h;

    // Rolling�p�ϐ�
    private int Rolling_Direction = 0;
    private int Rolling_i = 0;
    private bool Rolling_f = false;
    #endregion

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        Speed = DefaultSpeed;
    }

    private void Update()
    {
        v = Input.GetAxisRaw("Vertical");
        h = Input.GetAxisRaw("Horizontal");
        if (Input.GetKeyDown("space")) Rolling_f = true;
        if (Input.GetMouseButtonDown(0)) Attack();
    }

    void FixedUpdate()
    {
        // �}�E�X�̌����Ă�������𒲂ׂ�
        MouseDirection();

        // ���[�����O����
        if(Rolling_f==true)Rolling();

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

    }
    // ���[�����O����
    private void Rolling()
    {
        Speed = DefaultSpeed + 10;
        // �������Ƃ��̌�����ێ�(1��2�E)
        if(Direction == true && Rolling_Direction == 0) Rolling_Direction = 1;
        else if(Direction == false && Rolling_Direction == 0) Rolling_Direction = 2;

        // ���������獶��]�A�E��������E��]
        if (Rolling_Direction == 1) Rolling_i += 30;
        else if(Rolling_Direction == 2) Rolling_i -= 30;

        // ��]
        transform.rotation = Quaternion.Euler(0, 0, Rolling_i);
        
        // ���[�����O���I�������I������
        if (Rolling_i == 360 || Rolling_i == -360)
        {
            Rolling_f = false;
            Rolling_Direction = 0;
            Rolling_i = 0;
        }
    }

    // �}�E�X�̌����𒲂ׂ�
    private void MouseDirection()
    {
        Vector3 mousePos = Input.mousePosition;

        if (mousePos.x > 960 / 2)
        {
            Direction = false;
        }
        else
        {
            Direction = true;
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
}
