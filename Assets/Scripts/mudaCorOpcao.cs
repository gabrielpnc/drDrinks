using UnityEngine;
using System.Collections;

public class mudaCorOpcao : MonoBehaviour {

	//Identifica qual é essa opção no menu
	[SerializeField]
	int numeroOpcao;

	//Marca qual é o material (já que estão feito assim) pra quando NÃO estiver selecionado
	[SerializeField]
	Material opcaoDeselecionada;

	//Marca qual é o material pra quando estiver selecionado
	[SerializeField]
	Material opcaoSelecionada;

	//Cria a variável que será atualizada com a posição atual do controlador do menu
	int opcaoAtual;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {

		//Pega qual é a opção atual no momento pelo controlador do menu
		opcaoAtual = GameObject.Find ("Menu").GetComponent<controlaMenu> ().pegarOpcao ();

		//Se a opção atual for igual ao número dessa opção
		if (opcaoAtual == numeroOpcao) {
			//Muda o material para o selecionado
			gameObject.GetComponent<MeshRenderer> ().material = opcaoSelecionada;	
		} else {
			//Muda o material para o deselecionado
			gameObject.GetComponent<MeshRenderer> ().material = opcaoDeselecionada;
		}
	}
}
//Se Deus é por nós, quem será contra nós?