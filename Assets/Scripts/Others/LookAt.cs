using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LookAt : MonoBehaviour
{
    public GameObject cubeA;
    public GameObject cubeB;
    void Start()
    {
    }
    private void Update()
    {
        Vector3 posA = cubeA.transform.position;
        Vector3 posB = cubeB.transform.position;
        // Œü‚«‚½‚¢•ûŒü‚ðŒvŽZ
        Vector3 dir = (posB - posA);
        cubeA.transform.rotation = Quaternion.FromToRotation(Vector3.up, dir);
    }
}
