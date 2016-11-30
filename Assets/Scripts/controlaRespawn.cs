using UnityEngine;
using System.Collections;

public class controlaRespawn : MonoBehaviour
{

	//Vou fazer tudo em PT pa não dar problema

	/*
	 * Tive que colocar todos os placeholders aqui pois como não está pela animação
	 * foi a melhor maneira que encontrei de acessá-los
	*/

	//Campo serializado do copo azul vazio
	[SerializeField]
	GameObject copoAzul;

	//Campo serializado do copo azul enchendo
	[SerializeField]
	GameObject copoAzul1;

	//Campo serializado do copo azul meio cheio
	[SerializeField]
	GameObject copoAzul2;

	//Campo serializado do copo azul cheio
	[SerializeField]
	GameObject copoAzul3;

	//Campo serializado do copo vermelho
	[SerializeField]
	GameObject copoVermelho;

	//Campo serializado do copo vermelho enchendo
	[SerializeField]
	GameObject copoVermelho1;

	//Campo serializado do copo vermelho meio cheio
	[SerializeField]
	GameObject copoVermelho2;

	//Campo serializado do copo vermelho cheio
	[SerializeField]
	GameObject copoVermelho3;

	//Campo serializado do tempo do intervalo do respawn
	[SerializeField]
	float respawnIntervalo;

	//Respawn será variado a cada objeto criado ele é zerado
	float respawnCooldown;

	//Cria uma variável para controlar a dificuldade conforme o tempo
	float tempoJogo;

	//Define o tempo que será colocado para mudar cada nível
	[SerializeField]
	float tempoDificuldade;

	//Variavel que informará qual o nível da dificuldade e que será baseada para somar a movimentação do copo
	int dificuldadeJogo;

	void Awake() {
		QualitySettings.vSyncCount = 1;
		Application.targetFrameRate = 60;
	}


	// Use this for initialization
	void Start ()
	{
		//Começa o jogo na dificuldade 1 
		dificuldadeJogo = 1;

		respawnCooldown = respawnIntervalo;
	}
	
	// Update is called once per frame
	void Update ()
	{
		//A cada frame é retirada o segundos do cooldown
		respawnCooldown += Time.deltaTime;

		//Se o cooldown estiver menor que 0 cria um copo		
		if (respawnCooldown > respawnIntervalo) {

			//Volta o cooldown para o tempo escolhido
			respawnCooldown = 0;

			criaCopo (0, Random.Range (0, 2), 14.59f);
		}

		//conta o tempo de jogo
		tempoJogo += Time.deltaTime;

		//Se o jogo atinge o tempo para mudar de dificuldade
		if (tempoJogo > tempoDificuldade) {
			tempoJogo = 0;
			dificuldadeJogo = ++dificuldadeJogo;

			Debug.Log ("Dificuldade aumentada");

			//Se o intevalo de respawn for menor que 1
			if (respawnIntervalo < 1) {
				//Define o limite de 1 copo por segundo
				respawnIntervalo = 1;
			} else {
				//Reduz 8% do intervalo a cada dificuldade aumentada
				respawnIntervalo -= respawnIntervalo*0.08f;
			}

		} 
	}

	public void criaCopo (int nivelCopo, int corCopo, float posX)
	{
		/*
		 * Como o prefab estava salvo de uma maneira estranha (em .fbx)
		 * Tive que adicionar os componentes na unha, mudar escala e talz..
		*/

		//Cria um objeto para ficar guardado até ser instanciado
		GameObject tipoCopo = gameObject; 

		//Escolhe qual é o tipo do copo baseado na cor 1 = azul e 0 = vermelho
		if (corCopo == 1) {
			//Verifica o nível do copo para chamar o "placeholder" correto
			//Azul
			switch (nivelCopo) {
			case 0: 
				tipoCopo = copoAzul; 
				break;
			case 1: 
				tipoCopo = copoAzul1; 
				break;
			case 2: 
				tipoCopo = copoAzul2; 
				break;
			case 3: 
				tipoCopo = copoAzul3; 
				break;
			}
		} else {
			//Verifica o nível do copo para chamar o "placeholder" correto
			//Vermelho
			switch (nivelCopo) {
			case 0: 
				tipoCopo = copoVermelho; 
				break;
			case 1: 
				tipoCopo = copoVermelho1; 
				break;
			case 2: 
				tipoCopo = copoVermelho2; 
				break;
			case 3: 
				tipoCopo = copoVermelho3; 
				break;
			}
		}


		//Copo instanciado com a posição colocada na mão, se mudar qualquer posicionamento é preciso mudar isso ou instanciar alguma gameObject de referencia
		GameObject novoCopo = Instantiate (tipoCopo, new Vector3 (posX, 3.85f, -2.16f), transform.rotation) as GameObject;


		//A escala foi modificada pois o prefab estava pequeno
		novoCopo.transform.localScale = new Vector3 (10, 10, 10);
		//O prefab também não tinha a movimentação do copo
		novoCopo.AddComponent <movimentaCopo> ();
		//Calcula a velocidade aumentando 1/6 a cada dificuldade aumentada
		novoCopo.GetComponent <movimentaCopo> ().velocidade *= 1+(0.16f*dificuldadeJogo);
		//Adiciona o script pra detectar o tiro da arma
		novoCopo.AddComponent <detectaTiro> ();
		//Informa que o nivel atual do objeto criado
		novoCopo.GetComponent <detectaTiro> ().nivelCopo = nivelCopo;
		//Informa a cor do objeto criado
		novoCopo.GetComponent <detectaTiro> ().corCopo = corCopo;
		//Adiciona um collider que também deveria estar no placeholder
		BoxCollider areaBox = novoCopo.AddComponent <BoxCollider> ();
		//Modifica o tamanho do box do collider
		areaBox.size = new Vector3 (0.05f, 0.05f, 0.05f);
		//Como o centro desse placeholder esta estranho, tive que mudar o Y baseado no tamanho colocado acima
		areaBox.center = new Vector3 (0, 0.05f, 0);
		areaBox.isTrigger = true;

	}
}
//Se Deus é por nós, quem será contra nós?