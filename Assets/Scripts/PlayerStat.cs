using System.Collections;
using System.Collections.Generic;
using System.Data;
using UnityEngine;

public class PlayerStat : MonoBehaviour
{
    public static PlayerStat instance;

    void Start()
    {
        if(null == instance)
        {
            instance = this;
        }
    }
    public int hp = 0;
    public int attack = 0;
    public int sheild = 0;
    public int gold = 100;
    public int lowattackstat;
    public int lowshieldstat;

    // Update is called once per frame
    void Update()
    {
        //lowattackstat += LowAnvil.instance.lowattack;
        //lowshieldstat += LowAnvil.instance.lowshield;
        //lowattackstat += attack;
        //lowshieldstat += sheild;

        //Debug.Log(lowattackstat);
        //Debug.Log(lowshieldstat);
    }
}
