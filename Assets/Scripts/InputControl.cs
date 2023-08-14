using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;

public class InputControl : MonoBehaviour, IDragHandler, IPointerDownHandler
{
    //Reload Scene
    public void Restart()
    {
        SceneManager.LoadScene("MainScene");
    }

    public float speed;
    public GameObject Player;

    float xclamp;

    // Update is called once per frame
    bool start = false;

    void Awake()
    {
        Player.GetComponent<Animator>().SetBool("isRunning", false);
    }

    void IDragHandler.OnDrag(PointerEventData eventData)
    {
        //Dragging mouse moves character laterally
        Player.transform.position += new Vector3(eventData.delta.x * speed / 2 * Time.deltaTime, 0, 0);
        xclamp = Mathf.Clamp(Player.transform.position.x,-6.7f, 6.5f);

        Player.transform.position = new Vector3(xclamp, Player.transform.position.y, Player.transform.position.z);
    }

    void IPointerDownHandler.OnPointerDown(PointerEventData eventData)
    {
        //Game starts on mouse click to screen
        start = true;
        Player.GetComponent<Animator>().SetBool("isRunning", true);
    }

    void Update()
    {
        if (start)
        {
            //Players runs forward
            Player.transform.position += new Vector3(0f, 0f, speed * Time.deltaTime);
        }
    }
}
