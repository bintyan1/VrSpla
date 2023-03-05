
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BulletFactory : MonoBehaviour
{
    public GameObject _sphere;
    public Transform _muzzle, _muzzleb;
    public Slider slider;
    public int fire_speed = 5;
    public static int reload_speed = 1;
    public int reload_distance = 30;
    private int time;
    private float fire_time = 60f;
    public float fire_rate = 60f;
    public float fire_power, torque;
    public GameObject effect;
    public bool bomb;
    void Start()
    {
        slider = GameObject.Find("Slider").GetComponent<Slider>();
        slider.value = 1000;
    }
    void Update()
    {
        //銃処理
        if (0 < OVRInput.Get(OVRInput.Axis1D.SecondaryIndexTrigger) && !bomb || Input.GetMouseButton(0) && !bomb)
        {

            if (0 < slider.value)
            {
                fire_time -= fire_rate;
                if (fire_time < 0)
                {
                    Fire();
                    fire_time = 60f;
                    slider.value -= fire_speed;
                }

            }
            time = 0;


        } //インク回復処理は銃のみ
        else if (slider.value < slider.maxValue && !bomb)
        {
            if (reload_distance < time)
            {
                slider.value += reload_speed;
            }
            time++;
            fire_time = 60f;
        }

        // ボムランチャー処理
        if (OVRInput.GetDown(OVRInput.Button.PrimaryIndexTrigger) && bomb)
        {
            if (slider.value > 600 && bomb)
            {
                FireBomb();
                slider.value -= 400;
            }
        }
    }

    public void Fire()
    {
        Vector3 pos = _muzzle.position;
        var obj = Instantiate(_sphere, pos, Quaternion.identity);
        Instantiate(effect, pos, Quaternion.identity);
        Rigidbody rigidbody = obj.GetComponent<Rigidbody>();
        rigidbody.AddForce(_muzzle.forward * fire_power, ForceMode.Impulse);
        rigidbody.AddTorque(new Vector3(Random.Range(-torque, torque), Random.Range(-torque, torque), Random.Range(-torque, torque)), ForceMode.Impulse);
    }

    public void FireBomb()
    {
        Vector3 pos = _muzzleb.position;
        var obj = Instantiate(_sphere, pos, Quaternion.identity);
        Instantiate(effect, pos, Quaternion.identity);
        Rigidbody rigidbody = obj.GetComponent<Rigidbody>();
        rigidbody.AddForce(_muzzleb.forward * fire_power, ForceMode.Impulse);
        rigidbody.AddTorque(new Vector3(Random.Range(-torque, torque), Random.Range(-torque, torque), Random.Range(-torque, torque)), ForceMode.Impulse);
    }

}
