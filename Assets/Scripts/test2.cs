using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class test2 : MonoBehaviour
{
	void Update()
	{
		var pos = Camera.main.WorldToScreenPoint(transform.localPosition);
		var rotation = Quaternion.LookRotation(Vector3.forward, Input.mousePosition - pos);

		transform.localRotation = rotation;
	}
}
