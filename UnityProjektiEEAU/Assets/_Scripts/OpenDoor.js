var ShowGUI : boolean;

function OnTriggerEnter ()
{
	ShowGUI = true;
	if (Input.GetKeyDown (KeyCode.Alpha6)) 
	{
		Destroy(gameObject);
	}
}

function OnTriggerExit ()
{
	ShowGUI = false;
}

function OnGUI ()
{
	if(ShowGUI == true)
	GUI.Label(Rect(600,400,100,20), "Open Barricade (Cost: 750)");
}