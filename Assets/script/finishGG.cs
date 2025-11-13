using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class finishGG : MonoBehaviour
{
    public GameObject Fline;
    float[] aa = { 29f, 59f, 89f, 119f, 149f };
    int lno;
    // Start is called before the first frame update
    void Start()
    {
        lno = PlayerPrefs.GetInt("levno");
        InvokeRepeating("abcd", aa[lno - 1], 300f);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void abcd()
    {
        if(Time.timeScale == 1)
        {
            Instantiate(Fline, new Vector2(transform.position.x, transform.position.y), Quaternion.identity);
        }
       
    }
}
