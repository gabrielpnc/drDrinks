#pragma strict
var velocidadeBala: float;


function Start () {

}

function Update () {
velocidadeBala = 60*Time.deltaTime;
transform.Translate(0,0,velocidadeBala);

}
