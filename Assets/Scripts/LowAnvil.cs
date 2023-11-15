using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class LowAnvil : MonoBehaviour
{
    public static LowAnvil instance = null;
    public GameObject Keyboard;

    GameObject stat;
    public TMP_Text statText;
    public TMP_Text gameRuleText;
    public float fadeDuration = 2.0f; // 텍스트가 사라지는 시간 (초)
    private float currentFadeTime = 0.0f;
    private Color initialColor;
    public GameObject Keypad;

    private void Awake()
    {
        if (null == instance)
        {
            instance = this;
        }
    }
    public int lowattack;
    public int lowshield;
    public List<int> LowPercente = new List<int>() { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };
    public List<int> LowPercente2 = new List<int>() { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };
    public List<int> TiePercente = new List<int>() { 8, 9, 10, 11, 12, 13, 14, 15 };
    public List<int> TiePercente2 = new List<int>() { 8, 9, 10, 11, 12, 13, 14, 15 };
    public List<int> HighPercente = new List<int>() { 13, 14, 15, 16, 17, 18, 19, 20 };
    public List<int> HighPercente2 = new List<int>() { 13, 14, 15, 16, 17, 18, 19, 20 };
    public bool LowGhaca1 = false;
    public bool TieGhaca1 = false;
    public bool HighGhaca1 = false;
    void Start()
    {

    }
    public void LowGhaca()
    {
        PlayerStat goldStat = FindObjectOfType<PlayerStat>();
        if (goldStat.gold > 0)
        {
            lowattack = LowPercente[Random.Range(0, LowPercente.Count)];
            lowshield = LowPercente2[Random.Range(0, LowPercente2.Count)];
            Debug.Log(lowattack);
            Debug.Log(lowshield);
        }
        else
        {
            Color gameruleNewColor = gameRuleText.color;
            gameruleNewColor.a = 1;
            gameRuleText.color = gameruleNewColor;
            gameRuleText.text = "코인이 부족합니다";
            currentFadeTime = 0.0f;
        }
        statText.color = initialColor;
        currentFadeTime = 0.0f;
        gameRuleText.color = initialColor;

    }
    public void TieGhaca()
    {
        PlayerStat goldStat = FindObjectOfType<PlayerStat>();
        if (goldStat.gold > 0)
        {
            int attack2 = TiePercente[Random.Range(0, TiePercente.Count)];
            int shield2 = TiePercente2[Random.Range(0, TiePercente2.Count)];
            Debug.Log(attack2);
            Debug.Log(shield2);
        }
        else
        {
            Color gameruleNewColor = gameRuleText.color;
            gameruleNewColor.a = 1;
            gameRuleText.color = gameruleNewColor;
            gameRuleText.text = "코인이 부족합니다";
            currentFadeTime = 0.0f;
        }

    }

    public void HighGhaca()
    {
        PlayerStat goldStat = FindObjectOfType<PlayerStat>();
        if (goldStat.gold > 0)
        {
            int attack3 = HighPercente[Random.Range(0, HighPercente.Count)];
            int shield3 = HighPercente2[Random.Range(0, HighPercente2.Count)];
            Debug.Log(attack3);
            Debug.Log(shield3);
        }
        else
        {
            Color gameruleNewColor = gameRuleText.color;
            gameruleNewColor.a = 1;
            gameRuleText.color = gameruleNewColor;
            gameRuleText.text = "코인이 부족합니다";
            currentFadeTime = 0.0f;
        }
    }
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.CompareTag("LowAnvil") && Input.GetKeyDown(KeyCode.F))
        {
            LowGhaca();
            PlayerStat.instance.gold -= 10;
            Debug.Log(PlayerStat.instance.gold);
        }
        else if (collision.CompareTag("TieAnvil") && Input.GetKeyDown(KeyCode.F))
        {
            TieGhaca();
            PlayerStat.instance.gold -= 20;
            Debug.Log(PlayerStat.instance.gold);
        }
        else if (collision.CompareTag("HighAnvil") && Input.GetKeyDown(KeyCode.F))
        {
            HighGhaca();
            PlayerStat.instance.gold -= 30;
            Debug.Log(PlayerStat.instance.gold);
        }

    }

    // Update is called once per frame
    void Update()
    {
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
    }

}
