using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PoisonBarrel : MonoBehaviour, I_Item
{
    private const int maxpoison_gauge = 1000; //최대 독성에너지(추후 변경)
    private int Recovery = 10000; // 회복량 (추후 변경)
    private PlayerStats stats;
    void Awake()
    {
        stats = GameObject.Find("Player").GetComponent<PlayerStats>();

    }
    public void Use()
    {
        PoisonMaker();
    }
    public void PoisonMaker() // 독성 포션 회복
    {
        Debug.Log(this.name + Recovery + "만큼 회복");
        if (maxpoison_gauge >= stats.poison_gauge + Recovery)
        {
            stats.poison_gauge += Recovery;
        }
        else
        {
            stats.poison_gauge = maxpoison_gauge;
        }
    }
}