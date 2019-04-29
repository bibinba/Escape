using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class button : MonoBehaviour
{
    public Image image;
    public Sprite[]room= new Sprite[4];
    public Sprite roomk;
    public AudioSource closedoor;
    public AudioSource opendoor;
    public AudioSource getkey;
    int roomnow = 0;
    bool key=false;
    // Start is called before the first frame update
    void Start()
    {
        image.sprite = room[roomnow];
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnRightButton()
    {
        if (0<=roomnow&& roomnow <= 2)
        {
            roomnow++;
        }
        else if (roomnow == 3)
        {
            roomnow = 0;
        }

        image.sprite = room[roomnow];
        Debug.Log(roomnow);
    }

    public void OnLeftButton()
    {
       
        if (1 <= roomnow && roomnow <= 3)
        {
            roomnow--;
        }
        else if (roomnow == 0)
        {
            roomnow = 3;
        }
        image.sprite = room[roomnow];
        Debug.Log(roomnow);
    }

    public void Onkey()
    {
        if (roomnow == 1 && key == false)
        {
            getkey.Play();
           image.sprite= roomk;
            room[1] = roomk;
            key = true;
        }

    }

    public void Ondoor()
    {
        if (roomnow==0&&key == true)
        {
           opendoor.Play();
            SceneManager.LoadScene("End");
        }
        else if(roomnow == 0 && key == false)
        {
            closedoor.Play();
        }
     
    }
}
