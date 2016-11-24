#pragma strict
var projetil: GameObject;
function Start () {

}

function Update () {
if(Input.GetButtonDown("Fire2"))
{
Instantiate(projetil,transform.position,transform.rotation);
}
}