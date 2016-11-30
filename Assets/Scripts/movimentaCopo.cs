using UnityEngine;
using System.Collections;

public class movimentaCopo : MonoBehaviour
{
	//Vou fazer tudo em português já que parece há rejeição quando eu comento em inglês

	public float velocidade = 0.2f;

	// Use this for initialization
	void Start ()
	{
	
	}
	
	// Update is called once per frame
	void Update ()
	{
		Vector3 atual = gameObject.transform.position;
		atual.x = gameObject.transform.position.x - (Time.deltaTime * velocidade);
		transform.position = atual;

		//Se o copo sair do campo de visão do jogador ele será destruído
		if (transform.position.x < 9) {
			Destroy (gameObject);	
		}
	}
}
//Se Deus é por nós, quem será contra nós?