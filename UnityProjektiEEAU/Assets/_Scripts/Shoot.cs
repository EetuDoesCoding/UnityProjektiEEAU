using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shoot : MonoBehaviour {

	public GameObject bullet;

	public int damagePerShot = 20; 
	public float delayTime = 8;
	public float range = 100f;

	AudioSource gunAudio;



	private float counter = 0;


	void Awake () 
	{
		gunAudio = GetComponent<AudioSource> ();
	}
	// Use this for initialization
	void Start () 
	{
		
	}

	void Update () 
	{
		counter += Time.deltaTime;


		// If the Fire1 button is being press and it's time to fire...
		if(Input.GetButton ("Fire1") && counter >= delayTime)
		{
			Instantiate (bullet, transform.position, transform.rotation);
			counter = 0;

			gunAudio.Play ();
		}

//		if (Input.GetKey (KeyCode.Mouse0) && counter > delayTime) 
//		{
//			Instantiate (bullet, transform.position, transform.rotation);
//			counter = 0;

//			RaycastHit hit;
//			Ray ray = new Ray (transform.position, transform.forward);
//			if (Physics.Raycast (ray, out hit, 100f)) 
//			{
//				Instantiate  ();
//			}
		}
}