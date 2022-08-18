using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class test3 : MonoBehaviour
{
    public GameObject bullet;
    Vector3 createposition;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            createposition = transform.position;
            createposition.y += 0.1f;
            Instantiate(bullet, createposition, Quaternion.identity);
        }
    }
}
