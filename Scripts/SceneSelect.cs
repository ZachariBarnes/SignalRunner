﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SceneSelect : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    void Awake()
    {
        DontDestroyOnLoad(transform.gameObject);
    }

    public void GoToScene()
    {
        Application.LoadLevel("gameplay");
    }
}
