using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using GoogleMobileAds.Sample;

public class levels : MonoBehaviour
{
    public Button[] allbtn;
    int lno, mno;
    // Start is called before the first frame update
    void Start()
    {
        BannerViewController bann;
        bann = FindObjectOfType<BannerViewController>();
        bann.LoadAd();
        lno = PlayerPrefs.GetInt("levno", 1);
        mno = PlayerPrefs.GetInt("maxno", 0);

        for (int i = 0; i < allbtn.Length; i++)
        {
            allbtn[i].enabled = false;
        }
        

        for (int i = 0; i <= mno; i++)
        {
            if(i < mno)
            {
                allbtn[i].GetComponent<Image>().color = Color.white;
            }
            
            allbtn[i].enabled = true;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void levelbtn(int x)
    {
        PlayerPrefs.SetInt("levno", x);
        SceneManager.LoadScene("play");
    }
}
