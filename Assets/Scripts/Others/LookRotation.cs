using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LookRotation : MonoBehaviour
{
    public Transform arrowTrans; // �������I�u�W�F�N�g�̃g�����X�t�H�[��
    public Transform ballTrans; // �^�[�Q�b�g�̃I�u�W�F�N�g�̃g�����X�t�H�[��

    private void Update()
    {
        // ���������������v�Z
        Vector3 dir = (ballTrans.position - arrowTrans.position);

        // �����Ō������������ɉ�]�����Ă܂�
        arrowTrans.rotation = Quaternion.FromToRotation(Vector3.up, dir);
    }

}