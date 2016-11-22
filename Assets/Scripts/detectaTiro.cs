using UnityEngine;
using System.Collections;

public class detectaTiro : MonoBehaviour
{

	public int nivelCopo;
	public int corCopo;


	void OnTriggerEnter (Collider col)
	{
		Debug.Log (nivelCopo);
		GameObject.Find ("Sistema").GetComponent<controlaRespawn> ().criaCopo (++nivelCopo, corCopo, gameObject.transform.position.x);
		Destroy (gameObject);
	}


}