using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using GoogleMobileAds.Sample;
public class win : MonoBehaviour
{
    int lno, mno;
    // Start is called before the first frame update
    void Start()
    {
        BannerViewController bann;
        bann = FindObjectOfType<BannerViewController>();
        bann.LoadAd();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void nextbtn()
    {
        SceneManager.LoadScene("play");
    }

    public void homebtn()
    {
        SceneManager.LoadScene("home");
    }
}
