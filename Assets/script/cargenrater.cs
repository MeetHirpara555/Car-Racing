using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cargenrater : MonoBehaviour
{
    public GameObject[] car;
    double[] xpos = { -1.94, -0.68, 0.71, 2.02 };
    float[] aa = { 1.7f, 1.7f, 2.3f, 2.5f, 2.5f };
    float GG;
    int lno;
    // Start is called before the first frame update
    void Start()
    {
        
        lno = PlayerPrefs.GetInt("levno");
        GG = aa[lno-1];

        InvokeRepeating("abcd", 1f, GG);
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void abcd()
    {
        if (Time.timeScale==1)
        {
            int i = Random.Range(0, car.Length);
            int j = Random.Range(0, xpos.Length);

            Instantiate(car[i], new Vector2((float)xpos[j], transform.position.y), Quaternion.identity);
        }
        
    }
}
