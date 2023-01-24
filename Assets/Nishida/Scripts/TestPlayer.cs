using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestPlayer : MonoBehaviour
{
 //Rigidbody型のrbという変数を作る
    private Rigidbody rb;

    public float power;

    private void Start()
    {
        //リジットボディを取得しrbに代入する
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
         //キー入力による値を代入(解説は後で
        float x = Input.GetAxisRaw("Horizontal");
        float z = Input.GetAxisRaw("Vertical");
        Vector3 force = new Vector3(x, 0, z);

        //rbに力を加える
        //velocityは質量などの物理演算を無視するときに使う
        rb.AddForce(force * power,ForceMode.VelocityChange);

        //rbの回転をさせない様にする
        rb.constraints = RigidbodyConstraints.FreezeRotation;
    }
}
