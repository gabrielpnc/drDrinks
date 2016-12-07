using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
using GooglePlayGames;
using UnityEngine.SocialPlatforms;

public class controlaVida : MonoBehaviour
{

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

	// Use this for initialization
	void Start ()
	{
		Social.localUser.Authenticate ((bool success) => {});

	}

	public void perdeVida ()
	{
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

	//Esse script também controla pontos, tá tudo misturado pois cada dia era um escopo diferente e teve coisas que não previ
	public static void Init ()
	{
		//Mostra o Log no Celular.
		//PlayGamesPlatform.DebugLogEnabled = false;
		//Ativa o plugin
		PlayGamesPlatform.Activate ();

	}
}


//Se Deus é por nós, quem será contra nós?