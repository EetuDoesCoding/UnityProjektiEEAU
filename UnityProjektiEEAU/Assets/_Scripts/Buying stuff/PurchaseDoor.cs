using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PurchaseDoor : MonoBehaviour {

public int PriceValue = 50;
public Text priceText;
//Declaring variables
bool crossedBoundary;


	void Start ()
	{
		gameObject.SetActive (true);

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
			priceText.text = "Open Barricade (cost: 500)";
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
		gameObject.SetActive (false);
		priceText.text = "";
//		Destroy(this.gameObject);
	}


	void OnTriggerExit(Collider other) 
	{
		crossedBoundary = false;
	}

}