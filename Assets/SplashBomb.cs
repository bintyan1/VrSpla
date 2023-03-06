using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SplashBomb : MonoBehaviour
{

    private bool isTriggered;
    private Animator animator;

    public GameObject explosion;
    public GameObject ink;

    private AudioSource hitAudio;
    public AudioClip clip;
    // Start is called before the first frame update
    void Start()
    {
        hitAudio = GetComponent<AudioSource>();
        animator = GetComponent<Animator>();
    }

    void OnCollisionEnter(Collision c)
    {
        if (c.gameObject.tag == "Stage")
        {
            animator.SetBool("bomb", true);
            hitAudio.PlayOneShot(clip);
        }
    }

    public void Bomb()
    {
        Instantiate(explosion, transform.position, Quaternion.identity);
        Instantiate(ink, transform.position + new Vector3(0, 0.15f, 0), Quaternion.identity);
        Destroy(gameObject, 0.1f);
    }
}
