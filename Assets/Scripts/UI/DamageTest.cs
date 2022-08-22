using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DamageTest : MonoBehaviour
{
    [SerializeField]
    private GameObject ParentObj;
    [SerializeField]
    private GameObject DamageObj;
    [SerializeField]
    private GameObject PosObj;
    [SerializeField]
    private Vector3 AdjPos;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            ViewDamage(100);
        }
    }

    private void ViewDamage(int _damage)
    {
        GameObject _damageObj = Instantiate(DamageObj, ParentObj.transform);
        _damageObj.GetComponent<Text>().text = _damage.ToString();
        _damageObj.transform.position = RectTransformUtility.WorldToScreenPoint(Camera.main, PosObj.transform.position + AdjPos);
    }

}