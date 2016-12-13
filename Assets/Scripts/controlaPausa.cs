using UnityEngine;
using System.Collections;

public class controlaPausa : MonoBehaviour {

	[SerializeField]
	GameObject menu;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetButtonDown ("Start")) {
			Debug.Log ("apertou");
			if (menu.activeSelf) {
				menu.SetActive (false);
			} else {
				menu.SetActive (true);
			}

		}
	}
}
