using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class percentage : MonoBehaviour
{
    GameObject stat;
    public Text statText;
    public Text gameRuleText;
    public float fadeDuration = 2.0f; // �ؽ�Ʈ�� ������� �ð� (��)
    private float currentFadeTime = 0.0f;
    private Color initialColor;
    public GameObject Keypad;
    public Text bigStatText;

    void Start()
    {
        stat = GameObject.Find("Player");
        initialColor = statText.color; // �ʱ� ���� ����
    }

    void Update()
    {
        // �ؽ�Ʈ ���̵� �ƿ� ����
        if (currentFadeTime < fadeDuration)
        {
            currentFadeTime += Time.deltaTime;
            float alpha = 1.0f - (currentFadeTime / fadeDuration);
            Color gameruleNewColor = gameRuleText.color;
            Color statNewColor = statText.color;
            statNewColor.a = alpha;
            gameruleNewColor.a = alpha;
            statText.color = statNewColor;
            gameRuleText.color = gameruleNewColor;
        }
        if (currentFadeTime == 0)
        {
            statText.text = "";
            gameRuleText.text = "";
        }

        if (moruEntering)
        {
            Debug.Log("���� ������");
            random();
        }
    }
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
        PlayerStat goldStat = FindObjectOfType<PlayerStat>();
        if (Input.GetKeyDown(KeyCode.F))
        {
            if (goldStat.gold > 0)
            {
                Debug.Log(goldStat.gold -= 10);
                switch (percentage)
                {
                    case 0:
                        stat.GetComponent<PlayerStat>().hp = 10;
                        stat.GetComponent<PlayerStat>().attack = 10;
                        Debug.Log("10++");
                        statText.text = "10++";
                        bigStatText.text = "����ġ : 10++";


                        break;
                    case 1:
                        stat.GetComponent<PlayerStat>().hp = 20;
                        stat.GetComponent<PlayerStat>().attack = 20;
                        Debug.Log("20++");
                        statText.text = "20++";
                        bigStatText.text = "����ġ : 20++";
                        break;
                    case 2:
                        stat.GetComponent<PlayerStat>().hp = 30;
                        stat.GetComponent<PlayerStat>().attack = 30;
                        Debug.Log("30++");
                        statText.text = "30++";
                        bigStatText.text = "����ġ : 30++";
                        break;
                    case 3:
                        stat.GetComponent<PlayerStat>().hp = 40;
                        stat.GetComponent<PlayerStat>().attack = 40;
                        Debug.Log("40++");
                        statText.text = "40++";
                        bigStatText.text = "����ġ : 40++";
                        break;
                    case 4:
                        stat.GetComponent<PlayerStat>().hp = 50;
                        stat.GetComponent<PlayerStat>().attack = 50;
                        Debug.Log("50++");
                        statText.text = "50++";
                        bigStatText.text = "����ġ : 50++";
                        break;
                }
                // �ؽ�Ʈ ���̵� �ƿ��� �����ϱ� ���� �ʱ�ȭ
                statText.color = initialColor;
                currentFadeTime = 0.0f;
                gameRuleText.color = initialColor;
            }
            else
            {
                Color gameruleNewColor = gameRuleText.color;
                gameruleNewColor.a = 1;
                gameRuleText.color = gameruleNewColor;
                gameRuleText.text = "������ �����մϴ�";
                currentFadeTime = 0.0f;
            }
        }
    }
}
