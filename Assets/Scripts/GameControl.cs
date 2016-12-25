using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameControl : MonoBehaviour
{

    public static GameControl instance;
    public GameObject gameOverText;
    public Text scoreText;
    public bool gameOver = false;
    public float scrollSpeed = -1.5f;
    private int score = 0;
    private AudioSource audioSource;
    private AudioClip dieAudioClip;

    // Use this for initialization
    void Awake ()
    {
        if (instance == null)
        {
            instance = this;
            audioSource = GetComponent<AudioSource>();
            Debug.Log("Awake");
        }
        else if (instance != this)
        {
            Destroy(gameObject);
        }
    }

    // Update is called once per frame
    void Update ()
    {
		if (gameOver == true && Input.GetMouseButtonDown(0))
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
	}

    public void BirdScored()
    {
        if (gameOver)
        {
            return;
        }
        score++;
        scoreText.text = "Score: " + score.ToString();
        audioSource.PlayOneShot((AudioClip)Resources.Load("score"));
    }

    public void BirdDied()
    {
        gameOverText.SetActive(true);
        gameOver = true;
        audioSource.Stop();
        audioSource.PlayOneShot((AudioClip)Resources.Load("die"));
        Debug.Log(audioSource.clip);
    }
}
