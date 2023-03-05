using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ikura : MonoBehaviour
{
    Rigidbody rb;
    public float instPower;
    public bool isEarned;

    public Transform target;

    public float power, damping;

    public string targetStr;

    public static int point;

    public GameObject effect;
    // Start is called before the first frame update
    void Start()
    {
        rb = gameObject.GetComponent<Rigidbody>();

        rb.AddForce(new Vector3(Random.Range(-instPower, instPower), Random.Range(1f, 5f), Random.Range(-instPower, instPower)), ForceMode.Impulse);

        target = GameObject.Find(targetStr).transform;
    }

    // Update is called once per frame
    void Update()
    {
        if (this.isEarned)
        {
            //追従
            var lookPos = target.position - transform.position;
            lookPos.y = 0;
            var rotation = Quaternion.LookRotation(lookPos);
            transform.rotation = Quaternion.Slerp(transform.rotation, rotation, Time.deltaTime * damping);

            rb.AddRelativeForce(Vector3.forward * power, ForceMode.Force);

            //rbの回転をさせない様にする
            rb.constraints = RigidbodyConstraints.FreezeRotation;
            //rb.AddForce(Vector3.right * power, ForceMode.Acceleration);
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            Instantiate(effect, transform.position, Quaternion.identity);
            point++;
            Destroy(gameObject, 0.1f);
        }
    }
}
