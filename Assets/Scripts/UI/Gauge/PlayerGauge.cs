using UnityEngine;
using UnityEngine.UI;

public class PlayerGauge : MonoBehaviour
{
    [SerializeField]
    private Image GreenGauge;
    [SerializeField]
    private Image RedGauge;


    private void Update()
    {
        // 現在の体力 / 最大値
        float valueTo = GameData.Player_HP_Now / GameData.Player_HP_Max;
        // 緑ゲージ減少
        GreenGauge.fillAmount = valueTo;

    }

}