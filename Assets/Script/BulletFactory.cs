
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
    private float fire_time = 60f;
    public float fire_rate = 60f;
    public float fire_power;
    void Start()
    {
        slider = GameObject.Find("Slider").GetComponent<Slider>();
        slider.value = 1000;
    }
    void Update()
    {
        if (0 < OVRInput.Get(OVRInput.Axis1D.SecondaryIndexTrigger))
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
        }
        else if (slider.value < slider.maxValue)
        {
            if (reload_distance < time)
            {
                slider.value += reload_speed;
            }
            time++;
            fire_time = 60f;
        }
    }

    public void Fire()
    {
        Vector3 pos = _muzzle.position;
        var obj = Instantiate(_sphere, pos, Quaternion.identity);
        Rigidbody rigidbody = obj.GetComponent<Rigidbody>();
        rigidbody.AddForce(_muzzle.forward * fire_power, ForceMode.Impulse);
    }
}
