using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PurchaseDoor : MonoBehaviour {

public int PriceValue = 50;

//Declaring variables
bool crossedBoundary;


	void Start ()
	{
		gameObject.SetActive (true);

	}

	void OnTriggerStay(Collider other) 
	{
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
		gameObject.SetActive (false);
//		Destroy(this.gameObject);
	}


	void OnTriggerExit(Collider other) 
	{
		crossedBoundary = false;
	}

}

//			GUI.Label(new Rect(600, 300, 100, 20), "Open Barricade (Cost: 750)");
//			gameObject.SetActive (false);