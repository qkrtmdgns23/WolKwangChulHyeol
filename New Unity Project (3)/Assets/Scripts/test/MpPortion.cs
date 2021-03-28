//using System.Collections;
//using System.Collections.Generic;
//using UnityEngine;

//public class MpPortion : MonoBehaviour, I_Item
//{
//    private const int maxmp = 1000; //최대 마나 (추후 변경)
//    private int Recovery = 10000; // 회복량 (추후 변경)
//    private Stats stats;
//    void Awake()
//    {
//        stats = GameObject.Find("Player").GetComponent<Stats>();
        
//    }
//    public void Use()
//    {
//        MpPortionMaker();
//    }
//    public void MpPortionMaker() // Mp 포션 회복
//    {
//        Debug.Log(this.name + Recovery + "만큼 회복");
//        if (maxmp >= stats.mp + Recovery)
//        {
//            stats.mp += Recovery;
//        }
//        else
//        {
//            stats.mp = maxmp;
//        }
//    }
//}
