var clip = 10;
var reserve = 40;

function Update()
{
	transform.GetComponent.<GUIText>().text = clip.ToString() + "/" + reserve.ToString();
}