﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UIEvents : MonoBehaviour
{
    public void StartGame()
    {
        //load the  game scene
        SceneManager.LoadScene("Game");

    }
}
