#pragma strict
var projetil: GameObject;
function Start () {

}

function Update () {
if(Input.GetButtonDown("Fire1"))
{
Instantiate(projetil,transform.position,transform.rotation);
}
}