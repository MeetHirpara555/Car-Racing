using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class setting : MonoBehaviour
{
    public Slider volume;
    float vol = 1f;
    public int aa, i=0,c=0,j=0;
    public Sprite[] playercar;
    public Image carselect;
    public Button pp;
    public Sprite mute,nonmute;
    string[] control = { "keybord", "buttons", "touch", "gyro" };
    public Text showcontrol;
    // Start is called before the first frame update
    void Start()
    {
        
        vol = PlayerPrefs.GetFloat("volume",1f);
        volume.value = vol;
        carselect.sprite = playercar[i];
        showcontrol.text = control[j];
        if(volume.value > 0 )
        {
            pp.GetComponentInChildren<Image>().sprite = nonmute;
        }
        else
        {
            pp.GetComponentInChildren<Image>().sprite = mute;
        }    
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void backbtnclick()
    {
        SceneManager.LoadScene("play");
    }   
    public void applybtn()
    {
        PlayerPrefs.SetInt("select", i);
        PlayerPrefs.SetInt("SC", j);
        SceneManager.LoadScene("play");

    }
    public void homebtn()
    {
        SceneManager.LoadScene("home");

    }

    public void rightbtnclick()
    {
        
        if(i <= 5)
        {
            i++;
        }
        if (i == 6)
        {
            i = 0;
        }
        carselect.sprite = playercar[i];
        
    }

    public void Controlleft()
    {
        if (j >= 0)
        {
            j--;
        }
        if (j == -1)
        {
            j = 3;
        }
        showcontrol.text = control[j];

    }

    public void Controlright()
    {
        if (j <= 3)
        {
            j++;
        }
        if (j == 4)
        {
            j = 0;
        }
        showcontrol.text = control[j];
        
    }

    public void leftbtnclick()
    {
        if (i > 0)
        {
            i--;
        }
        if (i == 0)
        {
            i = 6;
        }

        carselect.sprite = playercar[i];
        
    }
    public void onVolumeChange(float value)
    {
        PlayerPrefs.SetFloat("volume",value);
    }

    public void btnplaypuase()
    {
        c++;
        if (c % 2 == 1)
        {
            volume.value = 0;
            PlayerPrefs.SetFloat("volume",volume.value);
            pp.GetComponentInChildren<Image>().sprite = mute;
        }
        else
        {
            volume.value = 1;
            PlayerPrefs.SetFloat("volume", volume.value);
            pp.GetComponentInChildren<Image>().sprite = nonmute;
        }
    }
}
