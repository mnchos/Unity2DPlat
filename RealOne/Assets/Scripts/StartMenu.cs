using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;
using UnityEngine.SceneManagement;

public class StartMenu : MonoBehaviour
{ string tmpname;
    [SerializeField] private InputField name;
    public void startgame()
    {
        tmpname = name.text;
        PlayerPrefs.SetString("name",tmpname);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
  
}
