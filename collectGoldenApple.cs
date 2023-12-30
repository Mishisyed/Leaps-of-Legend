using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class collectGoldenApple : MonoBehaviour
{
    private Animator anim;
    private Rigidbody2D rb;
    [SerializeField] private AudioSource transformationSoundEffect;
    private void Start()
    {
        anim = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("GoldenApple"))
        {
            Destroy(collision.gameObject);
            transformation();
            transformationSoundEffect.Play();
            Invoke("completeLevel", 3f);
           
        }
    }
    private void transformation()
    {
        anim.SetTrigger("Transformation");

    }

    private void completeLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

}
