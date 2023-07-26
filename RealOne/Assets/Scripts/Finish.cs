using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Finish : MonoBehaviour
{
    [SerializeField] private GameObject finishline;
    private AudioSource finishsound;
    private bool levelcomplite=false;
    private void Start()
    {
        finishsound = GetComponent<AudioSource>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.name == "Player" && !levelcomplite)
        {
            finishline.transform.position =new Vector2(12, 11);
            finishsound.Play();
            levelcomplite = true;
            Invoke("CompliteLevel", 1.5f);
            
        }
    }
    private void CompliteLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
}

    
