using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponSwitch : MonoBehaviour {

	[SerializeField]
	public GameObject weapon01;
	[SerializeField]
	public GameObject weapon02;

	public bool showItem1;
	public bool showItem2;

	// Use this for initialization
	void Start () 
	{
		showItem1 = true;
		showItem2 = false;
	}
	
	// Update is called once per frame
	void Update () 
	{
		if (showItem1 == false) 
		{
			weapon01.SetActive (false);
		}
		if (showItem1 == true) 
		{
			weapon01.SetActive (true);
		}
		if (showItem2 == false) 
		{
			weapon02.SetActive (false);
		}
		if (showItem2 == true) 
		{
			weapon02.SetActive (true);
		}

		if (Input.GetKeyDown (KeyCode.Alpha1) && showItem1 == false) 
		{
			showItem1 = true;
			showItem2 = false;
		}
		if (Input.GetKeyDown (KeyCode.Alpha2) && showItem2 == false) 
		{
			showItem1 = false;
			showItem2 = true;
		}
	}
}
