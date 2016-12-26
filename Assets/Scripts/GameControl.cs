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

    private Bird bird;
    public GameObject coinPrefab;
    public int coinPoolSize = 5;
    private GameObject[] coins;

    // Use this for initialization
    void Awake()
    {
        if (instance == null)
        {
            instance = this;
            audioSource = GetComponent<AudioSource>();
            Bird bird = GetComponent<Bird>();
        }
        else if (instance != this)
        {
            Destroy(gameObject);
        }
    }

    void Start()
    {
        coins = new GameObject[coinPoolSize];
        for (int i = 0, x = 0; i < coinPoolSize; i++)
        {
            x += Random.Range(1, 3);
            var pos = new Vector2(x, Random.Range(-3, +3));
            coins[i] = (GameObject)Instantiate(
                coinPrefab, pos, Quaternion.identity);
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (gameOver == true && Input.GetMouseButtonDown(0))
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
    }

    public void BirdScored(int amount)
    {
        if (gameOver)
        {
            return;
        }
        score += amount;
        scoreText.text = "Score: " + score.ToString();
        if (amount == 5)
        {
            audioSource.PlayOneShot((AudioClip)Resources.Load("bell"));
            var first = coins[0];
            coins[0] = coins[1];
            coins[1] = coins[2];
            coins[2] = coins[3];
            coins[3] = coins[4];
            coins[4] = first;
            first.transform.position = new Vector3(
                    first.transform.position.x + 10,
                    first.transform.position.y + Random.Range(-5, +5),
                    0);
        }
        if (amount == 10)
        {
            audioSource.PlayOneShot((AudioClip)Resources.Load("giggle"));
        }

    }

    public void BirdDied()
    {
        gameOverText.SetActive(true);
        gameOver = true;
        audioSource.Stop();
        audioSource.PlayOneShot((AudioClip)Resources.Load("die"));
    }
}
