using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class percentage : MonoBehaviour
{
     GameObject stat;
    // Start is called before the first frame update
    void Start()
    {
        stat = GameObject.Find("Player");
    }

    // Update is called once per frame
    void Update()
    {

    }
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            Debug.Log("모루와 접촉함");
            random();
        }
    }
    public void random()
    {
        int percentage = Random.Range(1, 50);
        percentage /= 10;

        if (Input.GetKey(KeyCode.F))
        {
            switch (percentage)
            {
                case 0:
                    stat.GetComponent<PlayerStat>().hp = 10;
                    stat.GetComponent<PlayerStat>().attack = 10;
                    Debug.Log("10++");
                    break;
                case 1:
                    stat.GetComponent<PlayerStat>().hp = 20;
                    stat.GetComponent<PlayerStat>().attack = 20;
                    Debug.Log("20++");
                    break;
                case 2:
                    stat.GetComponent<PlayerStat>().hp = 30;
                    stat.GetComponent<PlayerStat>().attack = 30;
                    Debug.Log("30++");
                    break;
                case 3:
                    stat.GetComponent<PlayerStat>().hp = 40;
                    stat.GetComponent<PlayerStat>().attack = 40;
                    Debug.Log("40++");
                    break;
                case 4:
                    stat.GetComponent<PlayerStat>().hp = 50;
                    stat.GetComponent<PlayerStat>().attack = 50;
                    Debug.Log("50++");
                    break;

            }
        }


}

}
