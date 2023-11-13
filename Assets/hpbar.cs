using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.UI;

public class hpbar : MonoBehaviour
{
    [Range(0, 1)] public float HP = 0;
    private Slider slider;
    public Image otherImage;
    private void Start()
    {
        slider = gameObject.GetComponent<Slider>();
        otherImage = GameObject.Find("ImageHP").GetComponent<Image>();
    }
    public void SetHp()
    {
        slider.value = HP;
        otherImage.fillAmount = HP;
    }
}
