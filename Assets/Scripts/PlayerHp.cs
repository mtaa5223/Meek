using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class PlayerHp : MonoBehaviour
{
    public float curHealth; //* 현재 체력
    public float maxHealth; //* 최대 체력
    public Image Hpbar;

    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        Hpbar.fillAmount = curHealth / maxHealth;
    }
}
