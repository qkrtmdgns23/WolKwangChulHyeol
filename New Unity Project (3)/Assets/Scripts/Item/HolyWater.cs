using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HolyWater : MonoBehaviour, I_Item
{
    private const int maxholy_gauge = 1000; //최대 신성에너지(추후 변경)
    private int Recovery = 10000; // 회복량 (추후 변경)
    private PlayerStats stats;
    void Awake()
    {
        stats = GameObject.Find("Player").GetComponent<PlayerStats>();

    }
    public void Use()
    {
        HolyMaker();
    }
    public void HolyMaker() // 신성 포션 회복
    {
        Debug.Log(this.name + Recovery + "만큼 회복");
        if (maxholy_gauge >= stats.holy_gauge + Recovery)
        {
            stats.holy_gauge += Recovery;
        }
        else
        {
            stats.holy_gauge = maxholy_gauge;
        }
    }
}
