using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

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

	void Update()
	{
		if(Input.GetKey(KeyCode.J))
		{
			//LoadNextLevel();
		}

		if(Input.GetKey(KeyCode.C)) 
		{
			//isTransitioning = true;
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

		Invoke("ReloadLevel", 2f);
	}

	void WinSequence()
	{
		isTransitioning = true;

		GetComponent<Movement>().enabled = false;

		audioS.Stop();
		audioS.PlayOneShot(winSound);

		winParticles.Play();

		Invoke("LoadNextLevel", 2f);
	}

	void LoadNextLevel()
	{
		int currentScene = SceneManager.GetActiveScene().buildIndex;

		int nextScene = currentScene + 1;

		if(nextScene == SceneManager.sceneCountInBuildSettings)
		{
			nextScene = 0;
		}

		SceneManager.LoadScene(nextScene);
	}

	void ReloadLevel()
	{
		int currentScene = SceneManager.GetActiveScene().buildIndex;

		SceneManager.LoadScene(currentScene);
	}
}
