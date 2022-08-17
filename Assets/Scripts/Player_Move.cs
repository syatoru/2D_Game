using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class Player_Move : MonoBehaviour
{
    #region // �ϐ��錾
    [Header("�ړ����x")] public float speed;
    public bool isRun;

    private Animator anim = null;
    Rigidbody2D rb = default;

    // Vertical��Horizontal�p�ϐ�
    private float v, h;

    // Rolling�p�ϐ�
    private int i = 0;
    private bool f = false;
    #endregion

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
    }

    private void Update()
    {
        v = Input.GetAxisRaw("Vertical");
        h = Input.GetAxisRaw("Horizontal");
        if (Input.GetKeyDown("space")) f = true;
    }

    void FixedUpdate()
    {
        Reversal();

        Run();

        Rolling();

    }

    // ���鏈��
    private void Run()
    {
        if (h > 0)
        {
            isRun = true;
        }
        else if (h < 0)
        {
            isRun = true;
        }
        else
        {
            isRun = false;

        }
        rb.velocity = new Vector2(h, v).normalized * speed;
        anim.SetBool("run", isRun);
    }

    // ���[�����O����
    private void Rolling()
    {
        if (i < 360 && f == true)
        {
            i += 30;
            transform.rotation = Quaternion.Euler(0, 0, i);
        }
        if (i == 360)
        {
            f = false;
            i = 0;
        }
    }

    // �������]����
    private void Reversal()
    {
        Vector3 mousePos = Input.mousePosition;

        if (mousePos.x > 960 / 2)
        {
            transform.localScale = new Vector3(3, 3, 1);
        }
        else
        {
            transform.localScale = new Vector3(-3, 3, 1);
        }
    }

}
