using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class Player_Move : MonoBehaviour
{
    #region // 変数宣言
    private float DefaultSpeed;
    public bool isRun;
    public static bool isInvincibleTime = false;

    private Rigidbody2D rb = default;
    private Animator anim = null;

    // 最終的な速度
    private float Speed;

    Camera targetCamera;

    private float PlayerCameraDistance;

    private bool Direction = false;

    // VerticalとHorizontal用変数
    private float v, h;

    private bool isAttack = true;

    // Rolling用変数
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
        //　タブが押されていない間
        if(KeyManager.TabActive == false)MouseLeftClick();


        if (Input.GetMouseButtonDown(1))
        {

        }
    }

    void FixedUpdate()
    {
        // マウスの向いている方向を調べる
        MouseDirection();
        // ローリング処理
        if (Rolling_f == true && isRolling == true)
        {
            Rolling();
        }

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
        // プレイヤーの弾を生成
        Bullet_Create.PlayerAttack = true;
    }
    // ローリング処理
    private void Rolling()
    {
        Speed = DefaultSpeed + 5;
        isInvincibleTime = true;
        // 押したときの向きを保持(1左2右)
        if (Direction == true && Rolling_Direction == 0) Rolling_Direction = 1;
        else if (Direction == false && Rolling_Direction == 0) Rolling_Direction = 2;

        // 左だったら左回転、右だったら右回転
        if (Rolling_Direction == 1) Rolling_i += 30;
        else if (Rolling_Direction == 2) Rolling_i -= 30;

        // 回転
        transform.rotation = Quaternion.Euler(0, 0, Rolling_i);

        // ローリングが終わったら終了処理
        if (Rolling_i == 360 || Rolling_i == -360)
        {
            isInvincibleTime = false;
            Rolling_f = false;
            Rolling_Direction = 0;
            Rolling_i = 0;
            StartCoroutine(RollingCoolTime(Rolling_CT));
        }
    }

    // ローリングクールタイム処理(クールタイム)
    private IEnumerator RollingCoolTime(float ct)
    {
        isRolling = false;
        yield return new WaitForSeconds(ct);
        isRolling = true;
    }

    // アタッククールタイム処理(クールタイム)
    private IEnumerator AttackCoolTime(float ct)
    {
        isAttack = false;
        yield return new WaitForSeconds(ct);
        isAttack = true;
    }


    // マウスの向きを調べる
    private void MouseDirection()
    {
        // マウスのワールド座標取得
        Vector3 mousePos = Input.mousePosition;
        
        // オブジェクトのワールド座標取得
        var targetWorldPos = this.transform.position;
        // ワールドのスクリーン座標に変換
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

    // 左クリック時の処理
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

    // 無敵取得
    public bool Get_isInvincibleTime()
    {
        return isInvincibleTime;
    }

}
