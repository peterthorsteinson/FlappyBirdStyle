using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RepeatingBackground : MonoBehaviour
{

    private BoxCollider2D groundCollider;
    private float groundHorizontalLenth;

	// Use this for initialization
	void Start ()
    {
        groundCollider = GetComponent<BoxCollider2D>();
        groundHorizontalLenth = groundCollider.size.x;

    }
	
	// Update is called once per frame
	void Update ()
    {
		if (transform.position.x < -groundHorizontalLenth)
        {
            RepositionBackground();
        }
	}

    private void RepositionBackground()
    {
        Vector2 groundOffset = new Vector2(groundHorizontalLenth * 2f, 0);
        transform.position = (Vector2)transform.position + groundOffset;
    }
}
