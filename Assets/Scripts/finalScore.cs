using UnityEngine;
using System.Collections;

public class finalScore : MonoBehaviour
{

	// Use this for initialization
	void Start ()
	{
		//Atribui ao text mesh a pontuação salva nas preferencias
		gameObject.GetComponent<TextMesh> ().text = PlayerPrefs.GetInt ("Pontuacao").ToString();

	}
}
//Se Deus é por nós, quem será contra nós?