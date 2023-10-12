using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class anvil : MonoBehaviour
{
    // Start is called before the first frame update

    public GameObject lowBox;
    public GameObject highBox;
    public GameObject tieBox;
    

    public GameObject Keyboard;
    private float speed = 1.0f;
    public float stopPositionY = -2.0f;
    bool stop = false;
    void Start()
    {

        Keyboard.SetActive(false);
        lowBox.transform.position = new Vector3(0f, 10f, 0f);
        highBox.transform.position = new Vector3(-3f, 10f, 0f);
        tieBox.transform.position = new Vector3(3f, 10f, 0f);
    }

    // Update is called once per frame
    void Update()
    {
        lowBox1();
        highBox1();
        tieBox1();

    }
    void lowBox1()
    {
        
        if (!stop)
        {
            Vector3 currentPosition = lowBox.transform.position;
            currentPosition.y -= speed * Time.deltaTime;
            lowBox.transform.position = currentPosition;
            if (currentPosition.y < stopPositionY)
            {
                stop = true;
            }
           
        }
    }
    void highBox1()
    {
       
        if (!stop)
        {
            Vector3 currentPosition = highBox.transform.position;
            currentPosition.y -= speed * Time.deltaTime;
            highBox.transform.position = currentPosition;
            if (currentPosition.y < stopPositionY)
            {
                stop = true;
            }
        }
    }
    void tieBox1()
    {
      
        if (!stop)
        {
            Vector3 currentPosition = tieBox.transform.position;
            currentPosition.y -= speed * Time.deltaTime;
            tieBox.transform.position = currentPosition;
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
