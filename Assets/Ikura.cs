using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ikura : MonoBehaviour
{
    Rigidbody rb;
    public float instPower;
    // Start is called before the first frame update
    void Start()
    {
        rb = gameObject.GetComponent<Rigidbody>();

        rb.AddForce(new Vector3(Random.Range(-instPower, instPower), Random.Range(1f, 5f), Random.Range(-instPower, instPower)), ForceMode.Impulse);
    }

    // Update is called once per frame
    void Update()
    {

    }
}
