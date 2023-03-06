using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Explosion : MonoBehaviour
{
    // ボム爆発ダメージ持続時間
    public float time = 0.2f;

    void OnCollisionEnter(Collision c)
    {
        if (c.gameObject.tag == "Stage")
        {
            Destroy(gameObject, time);
        }
    }
}
