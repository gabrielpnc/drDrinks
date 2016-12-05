using UnityEngine;
using System.Collections;

public class detectaTiro : MonoBehaviour
{
	//Variável que controla o nivel de líquido no copo
	public int nivelCopo;

	//Variável que controla a cor do copo
	public int corCopo;

	//Variável que controla a cor da bala
	int corBala;

	GameObject Placar;

	// Use this for initialization
	void Start ()
	{
		Placar = GameObject.Find ("Pontuacao");
	}

	//Verifica se houve uma interação e aciona o gatilho com base no que colidiu
	void OnTriggerEnter (Collider col)
	{
		//Identifica qual é a bala que está acertando o copo e confere um valor com base na cor do copo
		if (col.name == "bala(Clone)") {
			corBala = 1;
		} else {
			corBala = 0;
		}

		//Confere se a bala que acertou é igual a cor do copo e se o nível não está cheio
		if (corCopo == corBala && nivelCopo < 3) {
			//Cria um novo copo com os mesmos elementos porém um nível acima
			//Essa foi a gambiarra adotada para mudar os níveis com objetos difernetes, sem animação ou comportamentos
			GameObject.Find ("Sistema").GetComponent<controlaRespawn> ().criaCopo (++nivelCopo, corCopo, gameObject.transform.position.x);
			//Destroi o objeto de nível antigo para ficar apenas o novo criado
			Destroy (gameObject);


			//Controla a pontuação
			switch (nivelCopo) {
			case 1: 
				//Copo menos da metade cheio 3 pontos
				Placar.GetComponent<controlaPontuacao> ().adicionaPonto (3);
				break;
			case 2: 
				//Copo metade cheio 5 pontos
				Placar.GetComponent<controlaPontuacao> ().adicionaPonto (5);
				break;
			case 3: 
				//Copo totalmente cheio
				Placar.GetComponent<controlaPontuacao> ().adicionaPonto (10);
				break;
			}
		}

		if (corCopo != corBala) {
			Placar.GetComponent<controlaPontuacao> ().removePonto (50);
		}
	}


}
//Se Deus é por nós, quem será contra nós?