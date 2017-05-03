var clip = 10;
var reserve = 40;

function Update()
{
	if(Input.GetMouseButtonDown(0) && clip > 0)
	{
		clip -= 1;
	}

	if(Input.GetMouseButtonDown(1) && clip != 8 && reserve != 0)
	{
		var totalAmmo = clip + reserve;
		if(totalAmmo <= 8){
			clip = totalAmmo;
			reserve = 0;
		}else{
			var shotsFired = 8 - clip;
			clip = 8;
			reserve -= shotsFired;
		}
	}

	transform.GetComponent.<GUIText>().text = clip.ToString() + "/" + reserve.ToString();
}