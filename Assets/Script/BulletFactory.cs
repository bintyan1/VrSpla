
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletFactory : MonoBehaviour
{
    public GameObject _sphere;
    [SerializeField]
    private Transform _muzzle;

    void Update(){
        Fire();
    }

    void Fire(){
        
        Vector3 pos = _muzzle.position;
        var obj = Instantiate(_sphere, pos, Quaternion.identity);
        Rigidbody rigidbody = obj.GetComponent<Rigidbody>();
        rigidbody.AddForce (_muzzle.forward * 20, ForceMode.Impulse);
      
    }
}