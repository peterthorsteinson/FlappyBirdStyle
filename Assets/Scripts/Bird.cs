using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bird : MonoBehaviour
{
    public float upForce = 200f;
    private bool isDead = false;
    private Rigidbody2D rb2d;
    private Animator anim;
    private AudioSource audioSource;

    // Use this for initialization
    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        audioSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        if (isDead == false)
        {
            if (Input.GetMouseButtonDown(0))
            {
                rb2d.velocity = Vector2.zero;
                var v3 = Input.mousePosition;
                v3.z = 0;
                rb2d.AddForce(new Vector2(0, upForce));
                audioSource.PlayOneShot((AudioClip)Resources.Load("flap"));
                anim.SetTrigger("Flap");
            }
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        rb2d.velocity = Vector2.zero;
        isDead = true;
        anim.SetTrigger("Die");
        GameControl.instance.BirdDied();
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Coin")
        {
            other.transform.position = new Vector3(
                    this.transform.position.x + 10,
                    this.transform.position.y + Random.Range(-5, +5),
                    0);
        }
    }
}



