using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;
using UnityEngine.SceneManagement;
public class ItemCollector1 : MonoBehaviour
{
   
    private int itemcollect=0;
    [SerializeField] private Text ItemText;
    [SerializeField] private AudioSource collectionSound;
    [SerializeField] private Text timertext;

    private int timer;
    private void Start()
        
    {
       itemcollect = 0;
    timer = 75;
    }
    private void Update()
    {
       
        ItemText.text = "Items: " + itemcollect;
        timertext.text = "Time: " + (timer-Convert.ToInt32(Time.realtimeSinceStartup));
        if ((timer - Convert.ToInt32(Time.realtimeSinceStartup)) <= 0)
        {
            CompliteLevel();
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Items"))
        {
            
            collectionSound.Play();
            Destroy(collision.gameObject);
            itemcollect++;
            ItemText.text = "Items: " + itemcollect; 
            
        }      
        
        
        
    }
    private void CompliteLevel()
    {
        PlayerPrefs.SetInt("itemscore", itemcollect);
        timertext.text = "";
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
}
