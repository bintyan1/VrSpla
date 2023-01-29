
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BulletFactory : MonoBehaviour
{
    public GameObject _sphere;
    [SerializeField]
    private Transform _muzzle;
    public Slider slider;
    public int fire_speed = 5;
    public int reload_speed = 1;
    public int reload_distance = 30;
    private int time;
    void Start() {
        slider = GameObject.Find("Slider").GetComponent<Slider>();
        slider.value = 1000;
    }
    void Update(){
        if (0 < OVRInput.Get(OVRInput.Axis1D.SecondaryIndexTrigger)) {
            if(0 < slider.value){
                Fire(); 
                slider.value -= fire_speed;
            }
            time = 0;
        }else if(slider.value < slider.maxValue){
            if(reload_distance < time){
                slider.value += reload_speed;
            }
            time++;
        }
    }

    public void Fire(){
        Vector3 pos = _muzzle.position;
        var obj = Instantiate(_sphere, pos, Quaternion.identity);
        Rigidbody rigidbody = obj.GetComponent<Rigidbody>();
        rigidbody.AddForce (_muzzle.forward * 20, ForceMode.Impulse);
    }
}
