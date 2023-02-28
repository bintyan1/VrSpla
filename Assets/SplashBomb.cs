using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SplashBomb : MonoBehaviour
{

    private bool isTriggered;
    private Animator animator;

    public GameObject explosion;
    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    void OnCollisionEnter(Collision c)
    {
        if (c.gameObject.tag == "Stage")
            animator.SetBool("bomb", true);
    }

    public void Bomb()
    {
        Debug.Log("bomb!!");
        Instantiate(explosion, transform.position, Quaternion.identity);
        Destroy(gameObject, 0.1f);
    }
}
