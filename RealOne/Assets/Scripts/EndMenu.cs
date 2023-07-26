using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;
using UnityEngine.SceneManagement;
public class EndMenu : MonoBehaviour
{
    [SerializeField] private Text ItemText;
    [SerializeField] private Text losetext;
    private int score;
    private string name;
    public void Quit()
    {
        Application.Quit();

    }
    private void Start()
    {
        name = PlayerPrefs.GetString("name");
        score= PlayerPrefs.GetInt("itemscore");
        if (score == 0)
        {
            ItemText.text = name + ", � ��������� �� �� ������ ������� ����";
            losetext.text = "�������� ���������";
        }
        else {
            ItemText.text = name + ", ��� ����: " + score;
        }
    }
}
