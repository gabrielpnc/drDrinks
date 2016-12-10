using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

using GooglePlayGames;
using GooglePlayGames.BasicApi;
using UnityEngine.SocialPlatforms;


public class controlaVida : MonoBehaviour
{

	void Start(){
		
		PlayGamesClientConfiguration config = new PlayGamesClientConfiguration.Builder().Build();

		PlayGamesPlatform.InitializeInstance(config);
		// recommended for debugging:
		PlayGamesPlatform.DebugLogEnabled = true;
		// Activate the Google Play Games platform
		PlayGamesPlatform.Activate();

		Debug.Log ("entrou");

		// authenticate user:
		Social.localUser.Authenticate((bool success) => {
			// handle success or failure
		});
	
	}


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
			// post score 12345 to leaderboard ID "Cfji293fjsie_QA")
			Social.ReportScore(GameObject.Find ("Pontuacao").GetComponent<controlaPontuacao> ().informaPonto(), "CgkI69K_rp8dEAIQBQ", (bool success) => {
				// handle success or failure
			});
			SceneManager.LoadScene ("Game Over");

		}
	}
}
//Se Deus é por nós, quem será contra nós?