using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PurchaseDoor : MonoBehaviour {

public int PriceValue = 50;
public Text DoorPrice;
//Declaring variables
bool crossedBoundary;

	public int SpawnCount = 0;
//AudioSource BuyAudio;



	void Awake ()
	{
//		BuyAudio = GetComponent<AudioSource> ();
	}

	void Start ()
	{
		gameObject.SetActive (true);

	}

	void OnTriggerEnter(Collider other)
	{
		DoorPrice.text = "Purchase Barricade (Cost: 500)";	
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
		SpawnCount += 1;
//		BuyAudio.Play ();
		DoorPrice.text = "";
		gameObject.SetActive (false);
//		Destroy(this.gameObject);
	}


	void OnTriggerExit(Collider other) 
	{
		crossedBoundary = false;
	}

}