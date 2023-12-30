using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class collectableItems : MonoBehaviour
{
    [SerializeField] private Text applecounter;
    [SerializeField] private AudioSource collectItems;
    private int apple = 0;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Apple"))
        {
            Destroy(collision.gameObject);
            apple++;
            applecounter.text = "Apples: " + apple;
            collectItems.Play();
        } 

    }
}
