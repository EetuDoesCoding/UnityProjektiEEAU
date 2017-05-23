using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class M4Buy : MonoBehaviour {

public int PriceValue = 50;

public Text M4Price;
public bool Current3 = false;
//Declaring variables
bool crossedBoundary;

AudioSource BuyAudio;

	void Awake ()
	{
		BuyAudio = GetComponent<AudioSource> ();
	}

	void Start ()
	{
//		gameObject.SetActive (true);

	}

	void OnTriggerEnter(Collider other) 
	{
		M4Price.text = "Purchase Weapon (Cost: 500)";	
		crossedBoundary = true;
	}



	void OnGUI () 
	{
		//If the boolean is active, display the text
		if (crossedBoundary == true) 
		{
			if (Input.GetKeyDown("f") && ScoreManager.score >= PriceValue)
			{
				Buy ();
			}
		}
	}


	void Buy ()
	{
		ScoreManager.score -= PriceValue;
		Current3 = true;
		BuyAudio.Play ();
//		Destroy(this.gameObject);
//		gameObject.SetActive (false);
	}


	void OnTriggerExit(Collider other) 
	{
		Current3 = false;
		M4Price.text = "";
		crossedBoundary = false;
	}

}