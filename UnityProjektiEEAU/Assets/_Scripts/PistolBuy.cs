using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PistolBuy : MonoBehaviour {

public int PriceValue = 50;

public Text PistolPrice;
public bool Current2 = false;
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
		PistolPrice.text = "Purchase Weapon (Cost: 900)";	
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
		Current2 = true;
		BuyAudio.Play ();
//		Destroy(this.gameObject);
//		gameObject.SetActive (false);
	}


	void OnTriggerExit(Collider other) 
	{
		Current2 = false;
		PistolPrice.text = "";
		crossedBoundary = false;
	}

}