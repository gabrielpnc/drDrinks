using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

using GooglePlayGames;
using GooglePlayGames.BasicApi;
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

	[SerializeField]
	GameObject telaGameOver;

	//Variável que verifica se os pontos foram mandados quando jogo acaba
	bool enviarPontos = true;

	void Start ()
	{
		
		PlayGamesClientConfiguration config = new PlayGamesClientConfiguration.Builder ().Build ();

		PlayGamesPlatform.InitializeInstance (config);
		// recommended for debugging:
		PlayGamesPlatform.DebugLogEnabled = true;
		// Activate the Google Play Games platform
		PlayGamesPlatform.Activate ();

		// authenticate user:
		Social.localUser.Authenticate ((bool success) => {
			// handle success or failure
		});
	
	}

	void Update(){
		//Quando a quantidade de vidas acaba envia a pontuação para o Google Play
		if (quantidadeVida == 0 && enviarPontos){
			//Cadastra os pontos no serviço do Google
			Social.ReportScore (GameObject.Find ("Pontuacao").GetComponent<controlaPontuacao> ().informaPonto (), "CgkI69K_rp8dEAIQBQ", (bool success) => {
				enviarPontos = false;	
			});
		}
	}

	public void perdeVida ()
	{
		//Reduz a vida em 1
		quantidadeVida--;

		//Destroi o primeiro copo
		if (quantidadeVida == 2) {
			Destroy (vida3);
		}
		//Destroi o segundo copo
		if (quantidadeVida == 1) {
			Destroy (vida2);
		}
		//Chama os procedimentos pra terminar o jogo
		if (quantidadeVida == 0) {
			Destroy (vida1);

			//Cancela a arma do player
			GameObject.Find ("Arma").SetActive (false);

			//Mostra o quadro do game over
			this.telaGameOver.SetActive (true);

			//Inicia a rotina de esperar para mudar de cena
			StartCoroutine (fimGame (3));
		}
	}

	//Cria um ienumerator que consegue finalizar o jogo e pausar por alguns segundos
	IEnumerator fimGame (int tempo)
	{
		//Fica parado de acordo com o tempo de chamada da função
		yield return new WaitForSeconds (tempo);
		//Apos o tempo carrega a cena 
		SceneManager.LoadScene ("Game Over");
	}
}
//Se Deus é por nós, quem será contra nós?