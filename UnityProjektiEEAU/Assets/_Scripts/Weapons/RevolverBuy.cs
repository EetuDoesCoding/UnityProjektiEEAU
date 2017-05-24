using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RevolverBuy : MonoBehaviour {

public int PriceValue = 50;

public Text RevolverPrice;
public bool Current4 = false;
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
		RevolverPrice.text = "Purchase Weapon (Cost: 1500)";	
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
		Current4 = true;
		BuyAudio.Play ();
//		Destroy(this.gameObject);
//		gameObject.SetActive (false);
	}


	void OnTriggerExit(Collider other) 
	{
		Current4 = false;
		RevolverPrice.text = "";
		crossedBoundary = false;
	}

}