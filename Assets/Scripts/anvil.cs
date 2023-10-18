using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class anvil : MonoBehaviour
{
    // Start is called before the first frame update

    public GameObject leftAnvil;
    public GameObject middleAnvil;
    public GameObject rightAnvil;
    

    public GameObject Keyboard;
    private float speed = 1.0f;
    public float stopPositionY = -2.0f;
    bool stop = false;
    void Start()
    {

        Keyboard.SetActive(false);
        leftAnvil.transform.position = new Vector3(0f, 10f, 0f);
        middleAnvil.transform.position = new Vector3(-3f, 10f, 0f);
        rightAnvil.transform.position = new Vector3(3f, 10f, 0f);
    }

    // Update is called once per frame
    void Update()
    {
        LeftAnvil();
        MiddleAnvil();
        RightAnvil();

    }
    void LeftAnvil()
    {
        
        if (!stop)
        {
            Vector3 currentPosition = leftAnvil.transform.position;
            currentPosition.y -= speed * Time.deltaTime;
            leftAnvil.transform.position = currentPosition;
            if (currentPosition.y < stopPositionY)
            {
                stop = true;
            }
           
        }
    }
    void MiddleAnvil()
    {
       
        if (!stop)
        {
            Vector3 currentPosition = middleAnvil.transform.position;
            currentPosition.y -= speed * Time.deltaTime;
            middleAnvil.transform.position = currentPosition;
            if (currentPosition.y < stopPositionY)
            {
                stop = true;
            }
        }
    }
    void RightAnvil()
    {
      
        if (!stop)
        {
            Vector3 currentPosition = rightAnvil.transform.position;
            currentPosition.y -= speed * Time.deltaTime;
            rightAnvil.transform.position = currentPosition;
            if (currentPosition.y < stopPositionY)
            {
                stop = true;
            }
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {

            Debug.Log("´êÀ½");
            Keyboard.SetActive(true);
        }

       
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            Keyboard.SetActive(false);
        }


    }

}
