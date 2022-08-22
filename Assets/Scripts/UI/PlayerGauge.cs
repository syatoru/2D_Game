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
        // ���݂̗̑� / �ő�l
        float valueTo = GameData.Player_HP_Now / GameData.Player_HP_Max;
        // �΃Q�[�W����
        GreenGauge.fillAmount = valueTo;

    }

}