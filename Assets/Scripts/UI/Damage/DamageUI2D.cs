using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DamageUI2D : MonoBehaviour
{
    [SerializeField]
    private float DeleteTime = 1.5f;
    [SerializeField]
    private float MoveRange = 50.0f;
    [SerializeField]
    private float EndAlpha = 0.2f;

    private float TimeCnt;
    private Text NowText;

    void Start()
    {
        TimeCnt = 0.0f;
        Destroy(this.gameObject, DeleteTime);
        NowText = this.gameObject.GetComponent<Text>();
    }

    void Update()
    {
        TimeCnt += Time.deltaTime;
        this.gameObject.transform.localPosition += new Vector3(0, MoveRange / DeleteTime * Time.deltaTime, 0);
        float _alpha = 1.0f - (1.0f - EndAlpha) * (TimeCnt / DeleteTime);
        if (_alpha <= 0.0f) _alpha = 0.0f;
        NowText.color = new Color(1f, 0f, 0f, _alpha);
    }
}