using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootEffect : MonoBehaviour
{
    public GameObject muzzle;
    private AudioSource as_shot;
    // Start is called before the first frame update
    void Start()
    {
        muzzle = GameObject.Find("muzzle");
        as_shot = GetComponent<AudioSource>();
        as_shot.pitch = Random.Range(0.8f,1.4f);
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = muzzle.transform.position;
    }
}
