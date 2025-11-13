using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using GoogleMobileAds.Sample;
public class home : MonoBehaviour
{
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

    public void playbtnclick()
    {
        SceneManager.LoadScene("play");
    }
    public void levelsbtnclick()
    {
        SceneManager.LoadScene("levels");
    }
}
