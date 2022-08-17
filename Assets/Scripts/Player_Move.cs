using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class Player_Move : MonoBehaviour
{
    #region // 変数宣言
    [Header("移動速度")] public float speed;
    public bool isRun;

    private Animator anim = null;
    Rigidbody2D rb = default;

    // VerticalとHorizontal用変数
    private float v, h;

    // Rolling用変数
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

    // 走る処理
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

    // ローリング処理
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

    // 向き反転処理
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
