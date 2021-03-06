﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class button : MonoBehaviour
{
    public Image image;
    public GameObject kanazuti;
    public Sprite[]room= new Sprite[4];
    public Sprite roomk;
    public AudioSource closedoor;
    public AudioSource opendoor;
    public AudioSource getkey;
    public AudioSource piano;
    public AudioSource senion;

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
        if (Input.GetMouseButton(0))

        {
          //  touchon.Play();
        }
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
        senion.Play();
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
            kanazuti.SetActive(true);
        }

    }
    public void OnPianoButton()
    {
        piano.Play();
    }
    public void Ondoor()
    {
        if (roomnow == 0 && key == true)
        {
            opendoor.Play();

            StartCoroutine(End());
        }
        else if (roomnow == 0 && key == false)
        {
            closedoor.Play();
        }
    }
  
    IEnumerator End()
    {
        
        yield return new WaitForSeconds(1.2f);
        SceneManager.LoadScene("End");
    }
}
