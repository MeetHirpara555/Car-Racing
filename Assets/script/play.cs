using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.SocialPlatforms.Impl;
using UnityEngine.UI;

public class play : MonoBehaviour
{
    public Button pp;
    public Sprite puase,playy;
    int c = 0, pc;
    float tt;
    public Text score;
    public SpriteRenderer playercaar;

    public Sprite[] playercarr;


    // Start is called before the first frame update
    void Start()
    {
        pc = PlayerPrefs.GetInt("select");
        playercaar.sprite = playercarr[pc];
        tt = 0;
    }

    // Update is called once per frame
    void Update()
    {
        tt += Time.deltaTime;
        PlayerPrefs.SetFloat("T", tt);
        score.text = "" + PlayerPrefs.GetFloat("T");
    }

    public void btnplaypuase()
    {
        c++;
        if (c % 2 == 1)
        {
            Time.timeScale = 0;
            pp.GetComponentInChildren<Image>().sprite = puase;
        }
        else
        {
            Time.timeScale = 1;
            pp.GetComponentInChildren<Image>().sprite = playy;
        }
    }

    public void btnsettingclick()
    {
        SceneManager.LoadScene("setting");
    }
}
