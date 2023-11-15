using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class anvil : MonoBehaviour
{
    public GameObject Keyboard;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("LowAnvil"))
        {
            Keyboard.SetActive(true);
        }
        else if (collision.CompareTag("TieAnvil"))
        {
            Keyboard.SetActive(true);
        }
        else if (collision.CompareTag("HighAnvil"))
        {
            Keyboard.SetActive(true);
        }


    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("LowAnvil"))
        {
            Keyboard.SetActive(false);
        }
        else if (collision.CompareTag("TieAnvil"))
        {
            Keyboard.SetActive(false);
        }
        else if (collision.CompareTag("HighAnvil"))
        {
            Keyboard.SetActive(false);
        }


    }
}
