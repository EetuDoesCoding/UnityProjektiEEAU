using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PurchaseDoor : MonoBehaviour {

public int PriceValue = 50;
public Text DoorPrice;
//Declaring variables
bool crossedBoundary;
// EnemyManager enemyManager;

//AudioSource BuyAudio;



	void Awake ()
	{
//		BuyAudio = GetComponent<AudioSource> ();
	}

	void Start ()
	{
		gameObject.SetActive (true);
		// enemyManager = GetComponentInChildren <EnemyManager> ();

	}

	void OnTriggerEnter(Collider other)
	{
		DoorPrice.text = "Purchase Barricade (Cost: 750)";	
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
		// EnemyManager.spawnCount += 1;
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