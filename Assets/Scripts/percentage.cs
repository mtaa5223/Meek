using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class percentage : MonoBehaviour
{
    GameObject stat;
    public Text statText;
    public float fadeDuration = 2.0f; // 텍스트가 사라지는 시간 (초)
    private float currentFadeTime = 0.0f;
    private Color initialColor;

    void Start()
    {
        stat = GameObject.Find("Player");
        initialColor = statText.color; // 초기 색상 저장
    }

    void Update()
    {
        // 텍스트 페이드 아웃 로직
        if (currentFadeTime < fadeDuration)
        {
            currentFadeTime += Time.deltaTime;
            float alpha = 1.0f - (currentFadeTime / fadeDuration);
            Color newColor = statText.color;
            newColor.a = alpha;
            statText.color = newColor;
        }
        if(currentFadeTime == 0)
        {
            statText.text = "";
        }

        if(moruEntering)
        {
            Debug.Log("모루와 접촉함");
            random();
        }
    }

    //private void OnTriggerStay2D(Collider2D collision)
    //{
    //    Debug.Log("강주찬 큰 똥");
    //    if (collision.CompareTag("Player"))
    //    {
    //        Debug.Log("모루와 접촉함");
    //        random();
    //    }
    //}

    bool moruEntering = false;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            moruEntering = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            moruEntering = false;
        }
    }

    public void random()
    {
        int percentage = Random.Range(1, 50);
        percentage /= 10;

        if (Input.GetKeyDown(KeyCode.F))
        {
            
            switch (percentage)
            {
                case 0:
                    stat.GetComponent<PlayerStat>().hp = 10;
                    stat.GetComponent<PlayerStat>().attack = 10;
                    Debug.Log("10++");
                    statText.text = "10++";
                    
                    break;
                case 1:
                    stat.GetComponent<PlayerStat>().hp = 20;
                    stat.GetComponent<PlayerStat>().attack = 20;
                    Debug.Log("20++");
                    statText.text = "20++";
                    break;
                case 2:
                    stat.GetComponent<PlayerStat>().hp = 30;
                    stat.GetComponent<PlayerStat>().attack = 30;
                    Debug.Log("30++");
                    statText.text = "30++";
                    break;
                case 3:
                    stat.GetComponent<PlayerStat>().hp = 40;
                    stat.GetComponent<PlayerStat>().attack = 40;
                    Debug.Log("40++");
                    statText.text = "40++";
                    break;
                case 4:
                    stat.GetComponent<PlayerStat>().hp = 50;
                    stat.GetComponent<PlayerStat>().attack = 50;
                    Debug.Log("50++");
                    statText.text = "50++";
                    break;
            }

            // 텍스트 페이드 아웃를 시작하기 위해 초기화
            currentFadeTime = 0.0f;
            statText.color = initialColor;
        }
    }
}
