using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class PlayerHp : MonoBehaviour
{
    public float curHealth; //* ���� ü��
    public float maxHealth; //* �ִ� ü��
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
