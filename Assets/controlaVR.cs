﻿using UnityEngine;
using System.Collections;

public class controlaVR : MonoBehaviour {

	int jogarVR;


	// Use this for initialization
	void Start () {
		jogarVR = PlayerPrefs.GetInt("JogarVR");

		if (jogarVR == 0) {
			gameObject.GetComponent<GvrViewer> ().VRModeEnabled = false;
		}
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
