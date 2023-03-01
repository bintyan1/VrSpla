using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Explosion : MonoBehaviour
{
    //ダメージ判定用 trueになったら攻撃判定しない
    bool damaged;

    void OnCollisionEnter(Collision c)
    {
        if (c.gameObject.tag == "Stage")
        {
            Destroy(gameObject, 0.2f);
        }
    }


}
