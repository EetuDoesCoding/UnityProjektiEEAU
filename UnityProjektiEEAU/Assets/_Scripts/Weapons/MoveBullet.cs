using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveBullet : MonoBehaviour {

	public float lifetime = 2.0f;

	public float speed = 1f;

	void  Awake ()
	{
		Destroy(gameObject, lifetime);
	}

	void Update ()
	{
		transform.Translate (0, 0, speed);
	}
}