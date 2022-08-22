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
        // Œ»İ‚Ì‘Ì—Í / Å‘å’l
        float valueTo = GameData.Player_HP_Now / GameData.Player_HP_Max;
        // —ÎƒQ[ƒWŒ¸­
        GreenGauge.fillAmount = valueTo;

    }

}