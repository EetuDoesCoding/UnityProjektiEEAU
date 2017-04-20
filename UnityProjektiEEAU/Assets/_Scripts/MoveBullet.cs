using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveBullet : MonoBehaviour {

	public float speed = 1f;

	void Start ()
	{
		
	}

	void Update ()
	{
		transform.Translate (0, 0, speed);
	}
}