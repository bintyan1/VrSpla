using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlimeGenerator : MonoBehaviour
{

    public GameObject slime;
    private int timer;
    // Start is called before the first frame update
    void Start()
    {
        timer = Random.Range(60, 300);
    }

    // Update is called once per frame
    void Update()
    {
        timer--;
        if (timer < 0)
        {
            Instantiate(slime, transform.position, Quaternion.identity);
            timer = Random.Range(60, 300);
        }
    }
}
