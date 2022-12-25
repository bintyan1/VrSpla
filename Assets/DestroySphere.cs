using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroySphere : MonoBehaviour
{
    private void OnCollisionStay(Collision collision)
    {
        Debug.Log(collision.gameObject.tag);
        if(collision.gameObject.tag == "Stage")
        {
            Destroy(gameObject);
        }
    }

    void Update(){
        Transform _transform = this.transform;
        if(_transform.position.y < -20){
            Destroy(gameObject);
        }
    }
}
