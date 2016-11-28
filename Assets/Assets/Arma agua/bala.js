#pragma strict
var velocidadeBala: float;


function Start () {

}

function Update () {
	velocidadeBala = 15*Time.deltaTime;
	transform.Translate(0,0,velocidadeBala);

	//A cada update controle o objeto para ser destruído caso tenha ficado longe da cena
	controlaDestruicao();
}

//Coloquei esse código para detectar se a bala acerta o copo, ela é destruída
function OnTriggerEnter (col: Collider)
{
	Destroy (gameObject);
}

//Criei uma função para controlara destruição do objeto caso ele cai pra fora da cena
function controlaDestruicao(){
	if(transform.position.z > 9){
		Destroy(gameObject);
	}

	if(transform.position.z < -9){
		Destroy(gameObject);
	}

	if(transform.position.y < 0){
		Destroy(gameObject);
	}

	if(transform.position.y > 9){
		Destroy(gameObject);
	}
}