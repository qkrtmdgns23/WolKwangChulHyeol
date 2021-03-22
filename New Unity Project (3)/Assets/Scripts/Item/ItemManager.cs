using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class ItemManager : MonoBehaviour, I_Item
{
    [SerializeField]
    private string statsname;

    private PlayerStats stats;
    private string myname;
    public enum ItemRecovery
    {
        Armor=20,
        Battery=10,
        GasBottle=10,
        HolyWater = 10,
        HpPortion=30,
        MpPortion=10,
        SpPortion=20,
        PoisonBarrel=10
    }
    public enum ItemMax
    {
        Armor=50,
        Battery=50,
        GasBottle=50,
        HolyWater = 50,
        HpPortion=200,
        MpPortion=100,
        SpPortion=100,
        PoisonBarrel=50
    }
    private ItemRecovery itemR;
    private ItemMax itemM;
    private void Awake()
    {
        
        myname = this.name;
        itemR = (ItemRecovery)Enum.Parse(typeof(ItemRecovery), myname);// 해당 포션 이름으로 Enum에서 회복량 찾기.
        itemM = (ItemMax)Enum.Parse(typeof(ItemMax), myname);// 해당 포션 이름으로 Enum에서 최대 회복량 찾기.
        stats = GameObject.Find("Player").GetComponent<PlayerStats>();
    }

    public void Use()
    {
        Portion();
    }
    private void Portion() //
    {
        int temp = (int)stats.GetType().GetField(statsname).GetValue(stats);
        if ((int)itemM > temp + (int)itemR)
        {
            stats.GetType().GetField(statsname).SetValue(stats, temp+(int)itemR);
            Debug.Log(stats.GetType().GetField(statsname).GetValue(stats));
        }
        else
        {
            stats.GetType().GetField(statsname).SetValue(stats, (int)itemM);
        }
    }
}
