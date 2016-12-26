using UnityEngine;

public class Coin : MonoBehaviour {
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.GetComponent<Bird>() != null)
        {
            GameControl.instance.BirdScored(10);
        }
    }
}
