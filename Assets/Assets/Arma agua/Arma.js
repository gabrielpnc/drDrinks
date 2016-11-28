#pragma strict

var projetilAzul: GameObject;
var projetilVermelho: GameObject;

function Start () {

}

//Esse código eu não modifiquei, ele está escrito em javascript pra ter ideia
function Update () {
	if(Input.GetButtonDown("Fire1"))
	{
		Instantiate(projetilAzul,transform.position,transform.rotation);
	}

	if(Input.GetButtonDown("Fire2"))
	{
		Instantiate(projetilVermelho,transform.position,transform.rotation);
	}
}