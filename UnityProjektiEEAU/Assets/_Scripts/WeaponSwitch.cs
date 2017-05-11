using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponSwitch : MonoBehaviour {

	[SerializeField]
	public GameObject weapon01;
	[SerializeField]
	public GameObject weapon02;
	[SerializeField]
	public GameObject weapon03;
	[SerializeField]
	public GameObject weapon04;

	public bool showItem1;
	public bool showItem2;
	public bool showItem3;
	public bool showItem4;


	// Use this for initialization
	void Start () 
	{
		showItem1 = true;
		showItem2 = false;
		showItem3 = false;
		showItem4 = false;
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
		if (showItem3 == false) 
		{
			weapon03.SetActive (false);
		}
		if (showItem3 == true) 
		{
			weapon03.SetActive (true);
		}
		if (showItem4 == false) 
		{
			weapon04.SetActive (false);
		}
		if (showItem4 == true) 
		{
			weapon04.SetActive (true);
		}



		if (Input.GetKeyDown (KeyCode.Alpha1) && showItem1 == false) 
		{
			showItem1 = true;
			showItem2 = false;
			showItem3 = false;
			showItem4 = false;
		}
		if (Input.GetKeyDown (KeyCode.Alpha2) && showItem2 == false) 
		{
			showItem1 = false;
			showItem2 = true;
			showItem3 = false;
			showItem4 = false;
		}
		if (Input.GetKeyDown (KeyCode.Alpha3) && showItem3 == false) 
		{
			showItem1 = false;
			showItem2 = false;
			showItem3 = true;
			showItem4 = false;
		}
		if (Input.GetKeyDown (KeyCode.Alpha4) && showItem4 == false) 
		{
			showItem1 = false;
			showItem2 = false;
			showItem3 = false;
			showItem4 = true;
		}
	}
}
