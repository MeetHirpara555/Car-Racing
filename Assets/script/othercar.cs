using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewBehaviourScript : MonoBehaviour
{
    float speed;
    float[] aa = { 0.1f, 0.14f, 0.2f, 0.24f, 0.32f };
    int lno;
    // Start is called before the first frame update
    void Start()
    {
        lno = PlayerPrefs.GetInt("levno");
        speed = aa[lno - 1];
    }

    // Update is called once per frame
    void Update()
    {
        if (Time.timeScale == 1)
        {
            transform.position = new Vector3(transform.position.x, transform.position.y - speed, transform.position.z);

        }
    }
}
