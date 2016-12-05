using UnityEngine;
using System.Collections;

public class controlaPontuacao : MonoBehaviour
{

	//Variável que terá o numero de pontos
	int pontos = 0;

	// Use this for initialization
	void Start ()
	{
	
	}
	
	// Update is called once per frame
	void Update ()
	{
		gameObject.GetComponent<TextMesh> ().text = pontos.ToString();
	}

	public void adicionaPonto(int ponto){
		pontos += ponto;
	}

	public void removePonto(int ponto){
		pontos -= ponto;
	}
}
//Se Deus é por nós, quem será contra nós?