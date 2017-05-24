using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOverManager : MonoBehaviour {

	public PlayerHealth playerHealth;
//	public float restartDelay = 7f;

	Animator anim;
//	float restartTimer;

	void Awake()
	{
		anim = GetComponent<Animator> ();
	}
	
	// Update is called once per frame
	void Update () 
	{
		if (playerHealth.currentHealth <= 0) 
		{ 
			anim.SetTrigger ("GameOver");

//			restartTimer += Time.deltaTime;

			if (Input.GetMouseButtonDown(0)) 
			{
//				Application.LoadLevel (Application.loadedLevel);
				SceneManager.LoadScene(0);
			}
		}
	}
}