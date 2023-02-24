using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlimeGenerator : MonoBehaviour
{

    public GameObject slime;
    private int timer;
    public int timer_min;
    public int timer_max;
    // Start is called before the first frame update
    void Start()
    {
        timer = Random.Range(timer_min, timer_max);
    }

    // Update is called once per frame
    void Update()
    {
        timer--;
        if (timer < 0)
        {
            Instantiate(slime, transform.position, Quaternion.identity);
            timer = Random.Range(timer_min, timer_max);
        }
    }
}
