﻿using UnityEngine;
using System.Collections;

public class RELOAD : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKeyUp(KeyCode.Escape)) Application.LoadLevel(0);
	}
}
