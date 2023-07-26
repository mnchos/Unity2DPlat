using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;
using UnityEngine.SceneManagement;
public class ItemCollector : MonoBehaviour
{
    [SerializeField] private GameObject vase;
    private int itemcollect=0;
    [SerializeField] private Text ItemText;
    [SerializeField] private AudioSource collectionSound;
    [SerializeField] private Text timertext;
    private int timer;
    private void Start()
        
    {
        timer =75;
        vase.SetActive(false);
    }
    private void Update()
    {
        timertext.text = "Time: " + (timer - Convert.ToInt32(Time.realtimeSinceStartup));
        if(timer - Convert.ToInt32(Time.realtimeSinceStartup)<=0)
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
            ItemText.text = "Ключей найдено : " + itemcollect;
        }
        if (itemcollect >= 6)
        {
            vase.SetActive(true);
            vase.transform.position = new Vector3(-7, -2, 0);
            ItemText.text = "Найдите выход!";
        }
        if (collision.gameObject.CompareTag("Greatvase") && itemcollect>=1)
        {

            vase.transform.position = new Vector3(11, 12, 0);

        }

    }
    private void CompliteLevel()
    {
        itemcollect = 0;
        PlayerPrefs.SetInt("itemscore", itemcollect);
        timertext.text = "";
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 2);
    }
}
