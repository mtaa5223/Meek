using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class PlayerHp : MonoBehaviour
{
    public float curHealth; //* ���� ü��
    public float maxHealth; //* �ִ� ü��
    public Image Hpbar;
    
    [SerializeField]
    private Slider _slider;

    public void SetValue(float value)
    {
        _slider.value = value;
    }
}
