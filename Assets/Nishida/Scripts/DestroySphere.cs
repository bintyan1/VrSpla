using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroySphere : MonoBehaviour
{
    public GameObject hit;

    public Color color;

    private AudioSource[] audios;



    private void Start()
    {
        GetComponent<MeshRenderer>().material.color = color;
        audios = hit.GetComponents<AudioSource>();
    }
    private void OnCollisionStay(Collision collision)
    {
        Debug.Log(collision.gameObject.tag);

        hit.GetComponents<AudioSource>()[1].enabled = true;
        hit.GetComponents<AudioSource>()[0].enabled = false;
        Instantiate(hit, transform.position, Quaternion.identity);
        Destroy(gameObject);
    }

    void Update()
    {
        Transform _transform = this.transform;
        if (_transform.position.y < -20)
        {
            Destroy(gameObject, 1f);
        }
    }
}
