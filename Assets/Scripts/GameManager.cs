using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{

    public Text timeText;
    public Text text;
    private float time;
    private GameObject lowBox;
    public GameObject hide;

    private float speed = 1.0f;


    // Start is called before the first frame update
    void Start()
    {
        time = 0f;    
    }

    // Update is called once per frame
    void Update()
    {
        if(time >= 0f)
        {
            time += Time.deltaTime;

            timeText.text = Mathf.Ceil(time).ToString();
        }

        if (time > 3)
        {
            text.text = "잠시후 게임이 시작됩니다";
           
        }

        if(time > 5  && time < 6)
        {
            hide.SetActive(false);
        }
    }
}
