using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class controlaMenu : MonoBehaviour
{

	//Deixa publico a opção que está selecionada pra mostrar o objeto com cores
	public int opcaoSelecionada;

	//Variavel que ira controlar o analogico do controle e o menu nao passar rapido
	bool botaoApertado = false;

	// Use this for initialization
	void Start ()
	{
		//Ao iniciar a cena a opção jogar é a primeira a ser selecionada
		opcaoSelecionada = 1;
	}
	
	// Update is called once per frame
	void Update ()
	{

		//Controla as opções para não ir menos do que a primeira opcao
		if (opcaoSelecionada < 1) {
			opcaoSelecionada = 1;
		}
		//Controla as opções para não ir mais do que existe dentro do objeto menu
		if (opcaoSelecionada > transform.childCount) {
			opcaoSelecionada = transform.childCount;
		}

		//Se o analógio retornar ao meio ele pode ser apertado novamente
		if (Input.GetAxis ("Vertical") == 0) {
			botaoApertado = false;
		}

		//Verifica se o analógico não esta direcionado para nenhuma lado
		if (botaoApertado == false) {

			//Verifica se o analogico está pra CIMA
			if (Input.GetAxis ("Vertical") > 0.5) {
				//AUMENTA em 1 a opção selecionada
				opcaoSelecionada--;
				//Se o jogador não soltar o analógico ele não passa para a proxima opção
				botaoApertado = true;
			}

			//Verifica se o analogico está pra BAIXO
			if (Input.GetAxis ("Vertical") < -0.5) {
				//REDUZ em 1 a opção selecionada
				opcaoSelecionada++;
				//Se o jogador não soltar o analógico ele não passa para a proxima opção
				botaoApertado = true;
			}
				
		}

		//Verifica se o botão de executar a opção foi apertado
		if (Input.GetButtonDown ("Fire1")) {
			SceneManager.LoadScene (identificaCena (opcaoSelecionada));
		}
	}


	//Fução que informa aos botões do menu qual é a opção que está selecionada no momento
	public int pegarOpcao ()
	{
		return opcaoSelecionada;
	}

	protected string identificaCena (int opcaoSelecionada)
	{
		Debug.Log (opcaoSelecionada);

		switch (opcaoSelecionada) {
		//OPCAO 1
		case 1: 
			return("Cena 1 VR Dev"); 
			break;
		//OPCAO 2
		case 2: 
			Application.Quit ();
			return null;
		//OPCAO 3
		case 3: 
			Application.Quit ();
			return null;
		}
		return null;
	}
}
//Se Deus é por nós, quem será contra nós?