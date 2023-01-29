using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GetUVScript : MonoBehaviour
{
    
    Texture2D tex;
    MeshRenderer meshRenderer;
    [SerializeField] 
    GameObject player;

    void Start()
    {
        meshRenderer = GetComponent<MeshRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 pos = player.transform.position;
        Vector3 pos2 = new Vector3(pos.x, pos.y-1, pos.z);
        RaycastHit hit;
        tex = meshRenderer.material.GetTexture("_MainTex") as Texture2D;
        if (Physics.Raycast(pos, pos2, out hit, Mathf.Infinity))
            {
                Vector2 uv = hit.textureCoord;
                Color[] pix = tex.GetPixels(Mathf.FloorToInt(uv.x * tex.width), Mathf.FloorToInt(uv.y * tex.height), 1, 1);
                Debug.Log(pix.ToString());
            }
    }
}
