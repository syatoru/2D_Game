using System.IO;
using System.Security.Cryptography;
using System.Text;
using UnityEngine;

public class Read : MonoBehaviour
{
    void OnEnable()
    {
        DoRead();
    }

    private void DoRead()
    {
        //�Z�[�u�t�@�C���̃p�X��ݒ�
        string SaveFilePath = Application.persistentDataPath + "/save.bytes";

        //�Z�[�u�t�@�C�������邩
        if (File.Exists(SaveFilePath))
        {
            //�t�@�C�����[�h���I�[�v���ɂ���
            FileStream file = new FileStream(SaveFilePath, FileMode.Open, FileAccess.Read);
            try
            {
                // �t�@�C���ǂݍ���
                byte[] arrRead = File.ReadAllBytes(SaveFilePath);

                // ������
                byte[] arrDecrypt = AesDecrypt(arrRead);

                // byte�z��𕶎���ɕϊ�
                string decryptStr = Encoding.UTF8.GetString(arrDecrypt);

                // JSON�`���̕�������Z�[�u�f�[�^�̃N���X�ɕϊ�
                SaveData saveData = JsonUtility.FromJson<SaveData>(decryptStr);

                //�f�[�^�̔��f
                ReadData(saveData);

            }
            finally
            {
                // �t�@�C�������
                if (file != null)
                {
                    file.Close();
                }
            }
        }
        else
        {
            Debug.Log("�Z�[�u�t�@�C��������܂���");

        }

        this.enabled = false;

    }

    //�f�[�^�̓ǂݍ��݁i���f�j
    private void ReadData(SaveData saveData)
    {
        GameData.Player_LV = saveData.Player_LV;
        GameData.Player_LP = saveData.Player_LP;
        GameData.Player_EXP = saveData.Player_EXP;
        GameData.Player_NEXT_EXP = saveData.Player_NEXT_EXP;
        GameData.Player_HP_Max = saveData.Player_HP_Max;
        GameData.Player_MP_Max = saveData.Player_MP_Max;
        GameData.Player_SP = saveData.Player_SP;
        GameData.Player_PA = saveData.Player_PA;
        GameData.Player_MA = saveData.Player_MA;
        GameData.Player_DF = saveData.Player_DF;
        GameData.Player_RT = saveData.Player_RT;
        GameData.Player_SPEED = saveData.Player_SPEED;

        GameData.Player_HP_Now = saveData.Player_HP_Now;
        GameData.Player_MP_Now = saveData.Player_MP_Now;

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

    /// AES������
    public byte[] AesDecrypt(byte[] byteText)
    {
        // AES�}�l�[�W���[�擾
        var aes = GetAesManager();
        // ������
        byte[] decryptText = aes.CreateDecryptor().TransformFinalBlock(byteText, 0, byteText.Length);

        return decryptText;
    }

}