using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PurchaseDoor : MonoBehaviour {

//Declaring variables
bool crossedBoundary;
void OnTriggerEnter(Collider other) 
{
		//Telling game to actiavte boolean
		if(other.gameObject.CompareTag ("test")) 
		{
			crossedBoundary = true;
		}
	}
	void OnGUI () 
	{
		//If the boolean is active, display the text
		if (crossedBoundary == true) 
		{
			GUI.Label(new Rect(200, 100, 0, 0), "Open Barricade (Cost: 750)");
		}
	}
}




//	void OnTriggerEnter (Collider other)
//	{
//		if(other.gameObject.CompareTag ("test"))
//		{
		
//		}
//	}


//}