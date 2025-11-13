using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class finishMM : MonoBehaviour
{
    float speed;
    int lno;
    float[] aa = { 0.055f, 0.066f, 0.077f, 0.088f, 0.099f };
    // Start is called before the first frame update
    void Start()
    {
        lno = PlayerPrefs.GetInt("levno");
        speed = aa[lno - 1];
    }

    // Update is called once per frame
    void Update()
    {
        
        if(Time.timeScale == 1)
        {
            transform.position = new Vector3(transform.position.x,transform.position.y - speed,transform.position.z);
        }
    }
}
