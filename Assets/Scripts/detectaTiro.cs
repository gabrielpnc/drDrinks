using UnityEngine;
using System.Collections;

public class detectaTiro : MonoBehaviour
{

	public int nivelCopo;
	public int corCopo;

	int corBala;

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
		}
	}


}
//Se Deus é por nós, quem será contra nós?