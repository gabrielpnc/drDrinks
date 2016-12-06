using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class controlaVida : MonoBehaviour {

	// Define quantas vidas o jogador terá
	[SerializeField]
	int quantidadeVida = 3;

	//Aqui a representação da vida escolhida foi 3 objetos na cena, por isso preciso marcálos para excluir
	[SerializeField]
	GameObject vida1;

	[SerializeField]
	GameObject vida2;

	[SerializeField]
	GameObject vida3;

	public void perdeVida(){
		quantidadeVida--;

		if (quantidadeVida == 2) {
			Destroy (vida3);
		}
		if (quantidadeVida == 1) {
			Destroy (vida2);
		}
		if (quantidadeVida == 0) {
			Destroy (vida1);
		}
		if (quantidadeVida < 0) {
			SceneManager.LoadScene ("Game Over");
		}
	}
}
