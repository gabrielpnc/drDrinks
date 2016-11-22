#pragma strict
var velocidadeBala: float;


function Start () {

}

function Update () {
velocidadeBala = 15*Time.deltaTime;
transform.Translate(0,0,velocidadeBala);

}
