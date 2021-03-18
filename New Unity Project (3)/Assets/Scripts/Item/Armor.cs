using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Armor : MonoBehaviour, I_Item
{
    private const int maxarmor = 1000; //최대 아머 (추후 변경)
    private int Recovery = 10000; // 회복량 (추후 변경)
    private PlayerStats stats;
    void Awake()
    {
        stats = GameObject.Find("Player").GetComponent<PlayerStats>();

    }
    public void Use()
    {
        ArmorMaker();
    }
    public void ArmorMaker() // 아머 회복
    {
        Debug.Log(this.name + Recovery + "만큼 회복");
        if (maxarmor >= stats.armor + Recovery)
        {
            stats.armor += Recovery;
        }
        else
        {
            stats.armor = maxarmor;
        }
    }
}
