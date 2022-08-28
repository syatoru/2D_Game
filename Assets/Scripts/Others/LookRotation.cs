using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LookRotation : MonoBehaviour
{
    Camera targetCamera;

    private void Start()
    {
        targetCamera = Camera.main;
    }

    private void Update()
    {
        // �}�E�X�̃��[���h���W�擾
        Vector2 mousePos = Input.mousePosition;
        Debug.Log(mousePos);
        // �I�u�W�F�N�g�̃��[���h���W�擾
        Vector2 targetWorldPos = this.transform.position;
        // ���[���h�̃X�N���[�����W�ɕϊ�
        Vector2 targetScreenPos = targetCamera.WorldToScreenPoint(targetWorldPos);
        // ���������������v�Z
        Vector2 dir = (mousePos - targetScreenPos);

        // �����Ō������������ɉ�]�����Ă܂�
        this.transform.rotation = Quaternion.FromToRotation(Vector2.up, dir);
    }

}
