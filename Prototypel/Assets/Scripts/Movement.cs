using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
	[SerializeField] float mainThrustSpeed;
	[SerializeField] float rotationSpeed;
	[SerializeField] AudioClip mainThrustSound;
	[SerializeField] ParticleSystem mainThrustPasticles;

	Rigidbody rb;
	AudioSource audioS;

	private void Start()
	{
		rb = GetComponent<Rigidbody>();
		audioS = GetComponent<AudioSource>();
	}

	void Update()
	{
		ProcessMainThrust();

		ProcessRotation();
	}

	private void ProcessRotation()
	{
		if (Input.GetKey(KeyCode.A))
		{
			rb.freezeRotation = true;
			transform.Rotate(0, 0, -rotationSpeed * Time.deltaTime);
			rb.freezeRotation = false;
		}

		if (Input.GetKey(KeyCode.D))
		{
			rb.freezeRotation = true;
			transform.Rotate(0, 0, rotationSpeed * Time.deltaTime);
			rb.freezeRotation = false;
		}
	}

	private void ProcessMainThrust()
	{
		if (Input.GetKey(KeyCode.Space))
		{
			rb.AddRelativeForce(0, mainThrustSpeed * Time.deltaTime, 0);

			if(!audioS.isPlaying) 
			{
				audioS.PlayOneShot(mainThrustSound);
			}

			if(!mainThrustPasticles.isPlaying)
			{
				mainThrustPasticles.Play();
			}
		}

		else
		{
			audioS.Stop();
			mainThrustPasticles.Stop();
		}
	}
}
