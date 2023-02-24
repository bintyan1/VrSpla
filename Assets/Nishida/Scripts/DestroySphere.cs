using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroySphere : MonoBehaviour
{
    public GameObject hit;

    public Color color;

    private void Start()
    {
        GetComponent<MeshRenderer>().material.color = color;
    }
    private void OnCollisionStay(Collision collision)
    {
        Debug.Log(collision.gameObject.tag);
        if(collision.gameObject.tag == "Stage")
        {
            Instantiate(hit, transform.position, Quaternion.identity);
            Destroy(gameObject);
        }
    }

    void Update(){
        Transform _transform = this.transform;
        if(_transform.position.y < -20){
            Destroy(gameObject,1f);
        }
    }
}
