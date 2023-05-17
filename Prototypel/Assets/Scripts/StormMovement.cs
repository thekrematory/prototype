using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class StormMovement : MonoBehaviour
{
	[SerializeField] private float Xspeed;
	[SerializeField] private float ySpeed;

	Rigidbody rb;

	private void Start()
	{
	rb = GetComponent<Rigidbody>();
	}

	private void Update()
	{
		rb.AddRelativeForce(Xspeed * Time.deltaTime,ySpeed*Time.deltaTime,0);
	}
}
