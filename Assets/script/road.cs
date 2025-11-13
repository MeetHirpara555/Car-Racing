using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class road : MonoBehaviour
{
    Renderer renderer;
    float speed;
    float[] aa = { 0.7f, 0.8f, 0.9f, 1.0f, 1.4f };
    int lno;
    // Start is called before the first frame update
    void Start()
    {
        lno = PlayerPrefs.GetInt("levno");
        speed = aa[lno - 1];
        renderer = GetComponent<Renderer>();
       
    }

    // Update is called once per frame
    void Update()
    {
        
        float yoffset = Time.time * speed;
        renderer.material.SetTextureOffset("_MainTex", new Vector2(0, yoffset));
    }
}
