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
        //セーブファイルのパスを設定
        string SaveFilePath = Application.persistentDataPath + "/save.bytes";
        // セーブデータの作成
        SaveData saveData = CreateSaveData();
        // セーブデータをJSON形式の文字列に変換
        string jsonString = JsonUtility.ToJson(saveData);
        // 文字列をbyte配列に変換
        byte[] bytes = Encoding.UTF8.GetBytes(jsonString);
        // AES暗号化
        byte[] arrEncrypted = AesEncrypt(bytes);
        // 指定したパスにファイルを作成
        FileStream file = new FileStream(SaveFilePath, FileMode.Create, FileAccess.Write);

        //ファイルに保存する
        try
        {
            // ファイルに保存
            file.Write(arrEncrypted, 0, arrEncrypted.Length);

        }
        finally
        {
            // ファイルを閉じる
            if (file != null)
            {
                file.Close();
            }
        }
        this.enabled = false;//このスクリプトをオフにする
    }

    // セーブデータの作成
    private SaveData CreateSaveData()
    {
        //セーブデータのインスタンス化
        SaveData saveData = new SaveData();
        //ゲームデータの値をセーブデータに代入
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


    /// AesManagedマネージャーを取得

    private AesManaged GetAesManager()
    {
        //任意の半角英数16文字
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

    /// AES暗号化
    public byte[] AesEncrypt(byte[] byteText)
    {
        // AESマネージャーの取得
        AesManaged aes = GetAesManager();
        // 暗号化
        byte[] encryptText = aes.CreateEncryptor().TransformFinalBlock(byteText, 0, byteText.Length);

        return encryptText;
    }

}