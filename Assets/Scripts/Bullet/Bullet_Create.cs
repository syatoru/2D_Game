using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet_Create : MonoBehaviour
{
    public GameObject Bullet;
    public GameObject AttackPoint;
    public GameObject Target;
    public float speed;
    public float deleteTime;

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 AttackPointPos = AttackPoint.transform.position;

        if (Input.GetMouseButtonDown(0) && this.gameObject.tag == "PlayerAttackPoint")
        {
            
            // �N���b�N�������W�̎擾�i�X�N���[�����W���烏�[���h���W�ɕϊ��j
            Vector3 mouseWorldPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);

            GameObject clone = Create(mouseWorldPos);
            clone.gameObject.tag = "PlayerBullet";
            Destroy(clone, deleteTime);
        }
        if(Input.GetMouseButtonDown(0) && this.gameObject.tag == "EnemyAttackPoint")
        {
            Vector3 TargetPos = Target.transform.position;
            
            // ���������������v�Z
            Vector3 dir = (TargetPos - AttackPointPos);
            // �������������ɉ�]
            //AttackPoint.transform.rotation = Quaternion.FromToRotation(Vector3.up, dir);

            GameObject clone = Create(TargetPos);
            clone.gameObject.tag = "EnemyBullet";
            clone.transform.rotation = Quaternion.FromToRotation(Vector3.up, dir);
            Destroy(clone, deleteTime);
        }
        
    }

    GameObject Create(Vector3 Pos)
    {
        // �e�i�Q�[���I�u�W�F�N�g�j�̐���
        GameObject clone = Instantiate(Bullet, transform.position, Quaternion.identity);

        // �����̐����iZ�����̏����Ɛ��K���j
        Vector3 shotForward = Vector3.Scale((Pos - transform.position), new Vector3(1, 1, 0)).normalized;

        // �e�ɑ��x��^����
        clone.GetComponent<Rigidbody2D>().velocity = shotForward * speed;
        return clone;
    }
}
