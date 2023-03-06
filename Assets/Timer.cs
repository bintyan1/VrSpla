using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Timer : MonoBehaviour
{

    private Text text;
    private int timer;

    private int time = 60;
    // Start is called before the first frame update
    void Start()
    {
        text = GetComponent<Text>();
    }

    // Update is called once per frame
    void Update()
    {
        timer++;
        if (timer >= 72) time--;

        if (time <= 0)
        {
            //結果発表
        }
    }
}
