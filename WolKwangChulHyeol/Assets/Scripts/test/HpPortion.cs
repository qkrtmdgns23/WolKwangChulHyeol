//using System.Collections;
//using System.Collections.Generic;
//using UnityEngine;

//public class HpPortion : MonoBehaviour, I_Item
//{
//    private const int maxhp = 1000; // 최대 체력 (추후 변경)
//    private int Recovery = 10000; // 회복량 (추후 변경)
//    private Stats stats;
//    void Awake()
//    {
//        stats = GameObject.Find("Player").GetComponent<Stats>();
//    }
//    public void Use()
//    {
//        HpPortionMaker();
//    }
//    public void HpPortionMaker() // Hp 포션 회복 
//    {
//        Debug.Log(this.name + Recovery + "만큼 회복");
//        if (maxhp >= stats.hp + Recovery)
//        {
//            stats.hp += Recovery;
//        }
//        else
//        {
//            stats.hp = maxhp;
//        }
//    }
//}
