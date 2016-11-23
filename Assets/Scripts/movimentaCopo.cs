using UnityEngine;
using System.Collections;

public class movimentaCopo : MonoBehaviour {
	//Vou fazer tudo em português já que parece há rejeição quando eu comento em inglês s

	float velocidade = 0.01f;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		Vector3 atual = gameObject.transform.position;
		atual.x = gameObject.transform.position.x - velocidade;
		transform.position = atual;
	}
}
