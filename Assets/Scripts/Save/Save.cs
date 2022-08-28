using System.IO;
using System.Security.Cryptography;
using System.Text;
using UnityEngine;

public class Save : MonoBehaviour
{
    void OnEnable()
    {
        DoSave();
    }

    private void DoSave()
    {
        //�Z�[�u�t�@�C���̃p�X��ݒ�
        string SaveFilePath = Application.persistentDataPath + "/save.bytes";
        // �Z�[�u�f�[�^�̍쐬
        SaveData saveData = CreateSaveData();
        // �Z�[�u�f�[�^��JSON�`���̕�����ɕϊ�
        string jsonString = JsonUtility.ToJson(saveData);
        // �������byte�z��ɕϊ�
        byte[] bytes = Encoding.UTF8.GetBytes(jsonString);
        // AES�Í���
        byte[] arrEncrypted = AesEncrypt(bytes);
        // �w�肵���p�X�Ƀt�@�C�����쐬
        FileStream file = new FileStream(SaveFilePath, FileMode.Create, FileAccess.Write);

        //�t�@�C���ɕۑ�����
        try
        {
            // �t�@�C���ɕۑ�
            file.Write(arrEncrypted, 0, arrEncrypted.Length);

        }
        finally
        {
            // �t�@�C�������
            if (file != null)
            {
                file.Close();
            }
        }
        this.enabled = false;//���̃X�N���v�g���I�t�ɂ���
    }

    // �Z�[�u�f�[�^�̍쐬
    private SaveData CreateSaveData()
    {
        //�Z�[�u�f�[�^�̃C���X�^���X��
        SaveData saveData = new SaveData();
        //�Q�[���f�[�^�̒l���Z�[�u�f�[�^�ɑ��
        saveData.Player_LV = GameData.Player_LV;
        saveData.Player_LP = GameData.Player_LP;
        saveData.Player_EXP = GameData.Player_EXP;
        saveData.Player_NEXT_EXP = GameData.Player_NEXT_EXP;
        saveData.Player_HP_Max = GameData.Player_HP_Max;
        saveData.Player_MP_Max = GameData.Player_MP_Max;
        saveData.Player_SP = GameData.Player_SP;
        saveData.Player_PA = GameData.Player_PA;
        saveData.Player_MA = GameData.Player_MA;
        saveData.Player_DF = GameData.Player_DF;
        saveData.Player_RT = GameData.Player_RT;
        saveData.Player_SPEED = GameData.Player_SPEED;

        saveData.Player_HP_Now = GameData.Player_HP_Now;
        saveData.Player_MP_Now = GameData.Player_MP_Now;

        saveData.items = GameData.items;
        saveData.bag = GameData.bag;
        return saveData;
    }


    /// AesManaged�}�l�[�W���[���擾

    private AesManaged GetAesManager()
    {
        //�C�ӂ̔��p�p��16����
        string aesIv = "1234567890123456";
        string aesKey = "1234567890123456";

        AesManaged aes = new AesManaged();
        aes.KeySize = 128;
        aes.BlockSize = 128;
        aes.Mode = CipherMode.CBC;
        aes.IV = Encoding.UTF8.GetBytes(aesIv);
        aes.Key = Encoding.UTF8.GetBytes(aesKey);
        aes.Padding = PaddingMode.PKCS7;
        return aes;
    }

    /// AES�Í���
    public byte[] AesEncrypt(byte[] byteText)
    {
        // AES�}�l�[�W���[�̎擾
        AesManaged aes = GetAesManager();
        // �Í���
        byte[] encryptText = aes.CreateEncryptor().TransformFinalBlock(byteText, 0, byteText.Length);

        return encryptText;
    }

}