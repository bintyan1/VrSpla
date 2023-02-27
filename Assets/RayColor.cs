using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RayColor : MonoBehaviour
{
    public Camera cam;
    public Transform target;
    private RenderTexture renderTexture;

    void Start()
    {
        // カメラのレンダリング先をRenderTextureに変更する
        renderTexture = new RenderTexture(16, 16, 16);
        renderTexture.Create();
        cam.targetTexture = renderTexture;
    }

    void Update()
    {
        //カメラの位置をメインカメラ位置に固定
        transform.position = target.position;

        // RenderTextureからピクセル情報を取得する
        RenderTexture.active = renderTexture;
        Texture2D texture = new Texture2D(renderTexture.width, renderTexture.height);
        texture.ReadPixels(new Rect(0, 0, renderTexture.width, renderTexture.height), 0, 0);
        texture.Apply();

        // 取得したテクスチャからピクセルの色情報を取得する
        Color pixelColor = texture.GetPixel(0, 0);

        // 色情報を使って何かをする
        Debug.Log("Pixel Color: " + pixelColor);
    }
}