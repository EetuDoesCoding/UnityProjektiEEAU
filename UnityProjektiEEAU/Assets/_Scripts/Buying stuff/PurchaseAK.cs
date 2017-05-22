using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PurchaseAK : MonoBehaviour {


public Text priceText;
public int PriceValue = 50;


public bool current = false;
//Declaring variables
bool crossedBoundary;


	void Awake ()
	{
//		gameObject.SetActive (true);
//		current = false;
	}

	void OnTriggerEnter(Collider other) 
	{
			crossedBoundary = true;
	}



	void OnGUI () 
	{
		//If the boolean is active, display the text
		if (crossedBoundary == true) 
		{
			priceText.text = "Purchase Weapon (cost: 500)";
			if (Input.GetKeyDown("f") && ScoreManager.score >= PriceValue)
			{
				Buy ();
			}
		}

		if (crossedBoundary == false) 
		{
			priceText.text = "";
		}
	}


	void Buy ()
	{
		ScoreManager.score -= PriceValue;
		current = true;		
		priceText.text = "";
//		Destroy(this.gameObject);
	}


	void OnTriggerExit(Collider other) 
	{
		current = false;
		crossedBoundary = false;
	}

}