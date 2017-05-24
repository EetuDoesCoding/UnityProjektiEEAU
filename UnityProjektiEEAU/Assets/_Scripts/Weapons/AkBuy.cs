using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AkBuy : MonoBehaviour {

public int PriceValue = 50;

public Text AKPrice;
public bool Current1 = false;
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
		AKPrice.text = "Purchase Weapon (Cost: 1200)";	
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
		Current1 = true;
		BuyAudio.Play ();
//		Destroy(this.gameObject);
//		gameObject.SetActive (false);
	}


	void OnTriggerExit(Collider other) 
	{
		Current1 = false;
		AKPrice.text = "";
		crossedBoundary = false;
	}

}