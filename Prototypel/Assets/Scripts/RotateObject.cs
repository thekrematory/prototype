using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class RotateObject : MonoBehaviour
{
	[SerializeField] float Xspeed;
	[SerializeField] float Yspeed;
	[SerializeField] float Zspeed;

	private void Update()
	{
		transform.Rotate(Xspeed * Time.deltaTime,Yspeed * Time.deltaTime,
		Zspeed * Time.deltaTime);
	}
}
