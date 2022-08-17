using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class weapon_ofset : MonoBehaviour
{
    public Transform target;
    public Vector3 r_offset;
    public Vector3 l_offset;
    public float location;

    private void Start()
    {
        transform.Rotate(new Vector3(0,0,location));
        
    }

    void Update()
    {
        Vector3 mousePos = Input.mousePosition;
        if (mousePos.x > 960 / 2)
        {
            transform.localScale = new Vector3(0.015f, 0.015f, 1);
            transform.rotation = Quaternion.Euler(0,0,-location);
            this.transform.position = target.position + r_offset;
        }
        else
        {
            transform.localScale = new Vector3(-0.015f, 0.015f, 1);
            transform.rotation = Quaternion.Euler(0, 0, location);
            this.transform.position = target.position + l_offset;
        }

    }
}
