using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collisions : MonoBehaviour
{
	[SerializeField] AudioClip explosionSound;
	[SerializeField] AudioClip winSound;
	[SerializeField] ParticleSystem deathParticles;
	[SerializeField] ParticleSystem winParticles;

	bool isTransitioning = false;
	
	AudioSource audioS;

	void Start()
	{
		audioS = GetComponent<AudioSource>();
	}

	private void Update()
	{
		if(Input.GetKeyDown(KeyCode.J)) 
		{
			Debug.Log("Starting Method");
			audioS.PlayOneShot(explosionSound);
		}
	}

	void OnCollisionEnter(Collision other)
	{
		if(isTransitioning) 
		{
			return;
		}

		switch(other.gameObject.tag)
		{
			case "Finish":
			WinSequence();
			break;

			case "Friendly":
			Debug.Log("Friendly");
			break;

			default:
			DeathSequence();
			break;
		}
	}

	void DeathSequence()
	{
		isTransitioning = true;

		GetComponent<Movement>().enabled = false;

		audioS.Stop();
		audioS.PlayOneShot(explosionSound);

		deathParticles.Play();
	}

	void WinSequence()
	{
		isTransitioning = true;

		GetComponent<Movement>().enabled = false;

		audioS.Stop();
		audioS.PlayOneShot(winSound);

		winParticles.Play();
	}
}
