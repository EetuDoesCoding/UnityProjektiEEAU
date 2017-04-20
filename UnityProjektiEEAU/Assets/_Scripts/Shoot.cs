using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shoot : MonoBehaviour {

	public GameObject bullet;
	public float delayTime = 8;

	public AudioClip shootSound;
	private AudioSource myAudioSource;

	private float counter = 0;


	void Awake () 
	{
		myAudioSource = GetComponent<AudioSource>();

	}
	// Use this for initialization
	void Start () 
	{
		
	}
	
	// Update is called once per frame
	void Update () 
	{
		if (Input.GetKey (KeyCode.Mouse0) && counter > delayTime) 
		{
			Instantiate (bullet, transform.position, transform.rotation);
			counter = 0;
		}
		counter += Time.deltaTime;
	}
}