﻿using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ChangeScene : MonoBehaviour
{
  
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if(Input.GetMouseButtonDown(0) || Input.GetMouseButtonDown(1))
        {
            Debug.Log(Input.GetMouseButtonDown(0));
            SceneManager.LoadScene("stage1");
        }
	}

}
