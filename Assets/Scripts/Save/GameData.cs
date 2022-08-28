public class GameData
{
    public static int Player_LV;            // プレイヤーレベル
    public static int Player_LP;            // プレイヤーのレベルポイント
    public static float Player_EXP;         // プレイヤー経験値
    public static float Player_NEXT_EXP;    // プレイヤーの次の経験値
    public static float Player_HP_Max;          // プレイヤーのHP
    public static float Player_MP_Max;          // プレイヤーのMP
    public static float Player_SP;          // プレイヤーのスタミナ
    public static float Player_PA;          // プレイヤーの物攻
    public static float Player_MA;          // プレイヤーの魔攻
    public static float Player_DF;          // プレイヤーの防御力
    public static float Player_RT;          // プレイヤーの抵抗力
    public static float Player_SPEED;       // プレイヤーのスピード

    public static float Player_HP_Now;          // プレイヤーの現在のHP
    public static float Player_MP_Now;          // プレイヤーの現在のMP

    public static Item[] items; // アイテムデータベース1234
    public static byte[] bag = new byte[21]; // バッグの情報、255は無
}