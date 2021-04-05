//using System.Collections;
//using System.Collections.Generic;
//using UnityEngine;

//public class Battery : MonoBehaviour, I_Item
//{
//    private const int maxelectric_gauge = 1000; //최대 전기에너지(추후 변경)
//    private int Recovery = 10000; // 회복량 (추후 변경)
//    private Stats stats;
//    void Awake()
//    {
//        stats = GameObject.Find("Player").GetComponent<Stats>();

//    }
//    public void Use()
//    {
//        BatteryMaker();
//    }
//    public void BatteryMaker() // Sp 포션 회복
//    {
//        Debug.Log(this.name + Recovery + "만큼 회복");
//        if (maxelectric_gauge >= stats.electric_gauge + Recovery)
//        {
//            stats.electric_gauge += Recovery;
//        }
//        else
//        {
//            stats.electric_gauge = maxelectric_gauge;
//        }
//    }
//}