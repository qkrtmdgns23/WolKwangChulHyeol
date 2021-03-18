using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpPortion : MonoBehaviour, I_Item
{
    private const int maxsp = 1000; //최대 스태미나 (추후 변경)
    private int Recovery = 10000; // 회복량 (추후 변경)
    private PlayerStats stats;
    void Awake()
    {
        stats = GameObject.Find("Player").GetComponent<PlayerStats>();

    }
    public void Use()
    {
        SpPortionMaker();
    }
    public void SpPortionMaker() // Sp 포션 회복
    {
        Debug.Log(this.name + Recovery + "만큼 회복");
        if (maxsp >= stats.sp + Recovery)
        {
            stats.sp += Recovery;
        }
        else
        {
            stats.sp = maxsp;
        }
    }
}