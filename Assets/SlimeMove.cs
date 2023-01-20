using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlimeMove : MonoBehaviour
{
 //Rigidbody型のrbという変数を作る
    private Rigidbody rb;
    public Transform target;

    public float damping;

    public float power;

    private void Start()
    {
        //リジットボディを取得しrbに代入する
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        var lookPos = target.position - transform.position;
lookPos.y = 0;
var rotation = Quaternion.LookRotation(lookPos);
transform.rotation = Quaternion.Slerp(transform.rotation, rotation, Time.deltaTime * damping);
         //キー入力による値を代入(解説は後で
        float x = Input.GetAxisRaw("Horizontal");
        float z = Input.GetAxisRaw("Vertical");

        //↑で代入された値をVector3型のIdouHoukouという変数に代入する
        Vector3 force = new Vector3(x, 0, z);

        //rbに力を加える
        //velocityは質量などの物理演算を無視するときに使う
        rb.AddForce(force * power,ForceMode.VelocityChange);

        //rbの回転をさせない様にする
        rb.constraints = RigidbodyConstraints.FreezeRotation;
    }
}
