using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeapoSummoner : MonoBehaviour
{
    private bool summoned;
    [SerializeField]
    private GameObject weapon;
    [SerializeField]
    private GameObject hand;
    // Start is called before the first frame update
    void Start()
    {
        summoned = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (!summoned)
        {
            if (OVRInput.GetDown(OVRInput.Button.One))
            {
                /*Buttonが押された瞬間の処理*/
                var obj = (GameObject)Instantiate(weapon, hand.transform.position, Quaternion.identity);
                obj.transform.parent = hand.transform;
                summoned = true;
            }

        }

        Debug.Log("now the ikura point is " + Ikura.point + " !!");
    }
}
