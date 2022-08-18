using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class Player_Move : MonoBehaviour
{
    #region // 変数宣言
    [Header("デフォルト速度")] public float DefaultSpeed;
    public bool isRun;

    private Rigidbody2D rb = default;
    private Animator anim = null;

    // 最終的な速度
    private float Speed;

    private bool Direction = false;

    // VerticalとHorizontal用変数
    private float v, h;

    // Rolling用変数
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
        // マウスの向いている方向を調べる
        MouseDirection();

        // ローリング処理
        if(Rolling_f==true)Rolling();

        //　走り処理
        Run();

        // マウスの向いている方向に画像を反転
        Reversal();
    }

    // 走る処理
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
    // ローリング処理
    private void Rolling()
    {
        Speed = DefaultSpeed + 10;
        // 押したときの向きを保持(1左2右)
        if(Direction == true && Rolling_Direction == 0) Rolling_Direction = 1;
        else if(Direction == false && Rolling_Direction == 0) Rolling_Direction = 2;

        // 左だったら左回転、右だったら右回転
        if (Rolling_Direction == 1) Rolling_i += 30;
        else if(Rolling_Direction == 2) Rolling_i -= 30;

        // 回転
        transform.rotation = Quaternion.Euler(0, 0, Rolling_i);
        
        // ローリングが終わったら終了処理
        if (Rolling_i == 360 || Rolling_i == -360)
        {
            Rolling_f = false;
            Rolling_Direction = 0;
            Rolling_i = 0;
        }
    }

    // マウスの向きを調べる
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

    // 向き変更
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
