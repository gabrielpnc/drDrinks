using UnityEngine;
using System.Collections;

public class controlaRespawn : MonoBehaviour {

	[SerializeField]
	GameObject copoAzul;

	int interval = 2; 
	float nextTime = 0;

	// Use this for initialization
	void Start () {
		/*
		GameObject novoCopo = Instantiate(copoAzul,new Vector3 (14.59f, 3.85f, -2.16f),transform.rotation) as GameObject;
		novoCopo.transform.localScale = new Vector3 (10, 10, 10);
		novoCopo.AddComponent <movimentaCopo>();
		*/
	}
	
	// Update is called once per frame
	void Update () {
		if (Time.time >= nextTime) {

			GameObject novoCopo = Instantiate(copoAzul,new Vector3 (14.59f, 3.85f, -2.16f),transform.rotation) as GameObject;
			novoCopo.transform.localScale = new Vector3 (10, 10, 10);
			novoCopo.AddComponent <movimentaCopo>();

			nextTime += interval; 

		}
	}
}
