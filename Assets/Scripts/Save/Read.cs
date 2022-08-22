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
        //セーブファイルのパスを設定
        string SaveFilePath = Application.persistentDataPath + "/save.bytes";

        //セーブファイルがあるか
        if (File.Exists(SaveFilePath))
        {
            //ファイルモードをオープンにする
            FileStream file = new FileStream(SaveFilePath, FileMode.Open, FileAccess.Read);
            try
            {
                // ファイル読み込み
                byte[] arrRead = File.ReadAllBytes(SaveFilePath);

                // 復号化
                byte[] arrDecrypt = AesDecrypt(arrRead);

                // byte配列を文字列に変換
                string decryptStr = Encoding.UTF8.GetString(arrDecrypt);

                // JSON形式の文字列をセーブデータのクラスに変換
                SaveData saveData = JsonUtility.FromJson<SaveData>(decryptStr);

                //データの反映
                ReadData(saveData);

            }
            finally
            {
                // ファイルを閉じる
                if (file != null)
                {
                    file.Close();
                }
            }
        }
        else
        {
            Debug.Log("セーブファイルがありません");

        }

        this.enabled = false;

    }

    //データの読み込み（反映）
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

    /// AES復号化
    public byte[] AesDecrypt(byte[] byteText)
    {
        // AESマネージャー取得
        var aes = GetAesManager();
        // 復号化
        byte[] decryptText = aes.CreateDecryptor().TransformFinalBlock(byteText, 0, byteText.Length);

        return decryptText;
    }

}