using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class playercar : MonoBehaviour
{
    float speed = 0.05f;
    float carrot = 0f;
    public Slider lifebar;
    int lifevalue = 3,pc;
    float vol,tt;   
    AudioSource audio;
    public AudioClip c1, c2;
    bool isgoingleft = false,isgoingright = false;
    public GameObject leftB ,rightB;
    int lno, mno;
    
    


    // Start is called before the first frame update
    void Start()
    {
        vol = PlayerPrefs.GetFloat("volume",1);
        lno = PlayerPrefs.GetInt("levno", 1);

        if(lno > 5)
        {
            PlayerPrefs.SetFloat("levno", 5);
        }

        lifebar.value = lifevalue;
        lifebar.enabled = false;
        audio = GetComponent<AudioSource>();
        audio.volume = vol;
        pc = PlayerPrefs.GetInt("SC");
    }

    // Update is called once per frame
    void Update()
    {
        if(pc == 0)
        {
            keybordcontrol();
        }
        if (pc == 1)
        {
            buttoncontrol();    
        }
        if (pc == 2)
        {
            touchcontrol();
        }
        if(pc == 3)
        {
            gyrocontrol();
        }
        
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (Time.timeScale == 1)
        {
            if (collision.gameObject.tag == "Ecar")
            {
                audio.clip = c1;
                audio.Play();
                lifevalue--;
                lifebar.value = lifevalue;

                if (lifevalue < 0)
                {
                   
                    SceneManager.LoadScene("loss");
                }
            }

            if (collision.gameObject.tag == "petrol")
            {
                audio.clip = c2;
                audio.Play();
                if (lifevalue < 3)
                {
                    lifevalue++;
                }
                lifebar.value = lifevalue;
                Destroy(collision.gameObject);
            }

            if(collision.gameObject.tag == "fline")
            {
                if (lno > mno)
                {
                    PlayerPrefs.SetInt("maxno", lno);
                }
                PlayerPrefs.SetInt("levno",lno + 1);
                SceneManager.LoadScene("win");
            }
        }
    }
    public void leftarrowrelese()
    {
        isgoingleft = false;
    }
    public void leftarrowpress()
    {
        isgoingleft = true;
    }

    public void rightarrowrelese()
    {
        isgoingright = false;
    }
    public void rightarrowpress()
    {
        isgoingright = true;
    }

    void movecarleft()
    {
        carrot += Time.deltaTime * 5f;

        float xpos = Mathf.Clamp(transform.position.x - speed, (float)-1.94, (float)2.02);
        transform.position = new Vector2(xpos, transform.position.y);
        transform.rotation = Quaternion.Euler(0, 0, carrot);
    }

    void movecarright()
    {
        carrot -= Time.deltaTime * 5f;
        float xpos = Mathf.Clamp(transform.position.x + speed, (float)-1.94, (float)2.02);
        transform.position = new Vector2(xpos, transform.position.y);
        transform.rotation = Quaternion.Euler(0, 0, carrot);
    }

    void keybordcontrol()
    {
        if (Time.timeScale == 1)
        {

            if (Input.GetKey(KeyCode.LeftArrow))
            {
                carrot += Time.deltaTime * 5f;

                float xpos = Mathf.Clamp(transform.position.x - speed, (float)-1.94, (float)2.02);
                transform.position = new Vector2(xpos, transform.position.y);
                transform.rotation = Quaternion.Euler(0, 0, carrot);
            }
            if (Input.GetKey(KeyCode.RightArrow))
            {
                carrot -= Time.deltaTime * 5f;
                float xpos = Mathf.Clamp(transform.position.x + speed, (float)-1.94, (float)2.02);
                transform.position = new Vector2(xpos, transform.position.y);
                transform.rotation = Quaternion.Euler(0, 0, carrot);
            }
            if (Input.GetKey(KeyCode.UpArrow))
            {
                float ypos = Mathf.Clamp(transform.position.y + speed, (float)-4, (float)4);
                transform.position = new Vector2(transform.position.x, ypos);
            }
            if (Input.GetKey(KeyCode.DownArrow))
            {
                float ypos = Mathf.Clamp(transform.position.y - speed, (float)-4, (float)4);
                transform.position = new Vector2(transform.position.x, ypos);
            }
            if (Input.GetKeyUp(KeyCode.LeftArrow) || Input.GetKeyUp(KeyCode.RightArrow))
            {
                carrot = 0f;
                transform.rotation = Quaternion.Euler(0, 0, carrot);
            }
        }
    }

    void buttoncontrol()
    {
        leftB.SetActive(true); 
        rightB.SetActive(true);
        if (Time.timeScale == 1)
        {
            if (isgoingleft)
            {
                movecarleft();
            }
            if (isgoingright)
            {
                movecarright();
            }
            if (isgoingleft == false && isgoingright == false)
            {
                carrot = 0f;
                transform.rotation = Quaternion.Euler(0, 0, carrot);
            }
            //if (isgoingright == false)
            //{
            //    carrot = 0f;
            //    transform.rotation = Quaternion.Euler(0, 0, carrot);
            //}
        }
    }

    void touchcontrol()
    {
        if(Time.timeScale == 1)
        {
            if(Input.touchCount>0)
            {
                Touch t = Input.GetTouch(0);
                float half = Screen.width / 2;
                if(t.position.x < half)
                {
                    movecarleft();
                }
                else
                {
                    movecarright();
                }
            }
            else
            {
                isgoingleft = false;
            }
        }
    }

    void gyrocontrol()
    {
        if(Input.acceleration.x < -0.1)
        {
            movecarleft();
        }
        else if (Input.acceleration.x < 0.1)
        {
            movecarright();
        }
        else
        {
            isgoingleft =false;
        }
    }
}
