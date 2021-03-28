//using System.Collections;
//using System.Collections.Generic;
//using UnityEngine;

//public class GasBottle : MonoBehaviour, I_Item
//{
//    private const int maxflame_gauge = 1000; // 최대 화염게이지 (추후 변경)
//    private int Recovery = 10000; // 회복량 (추후 변경)
//    private Stats stats;
//    void Awake()
//    {
//        stats = GameObject.Find("Player").GetComponent<Stats>();
//    }
//    public void Use()
//    {
//        GasBottleMaker();
//    }
//    public void GasBottleMaker() // 화염 게이지 포션 회복 
//    {
//        Debug.Log(this.name + Recovery + "만큼 회복");
//        if (maxflame_gauge >= stats.flame_gauge + Recovery)
//        {
//            stats.flame_gauge += Recovery;
//        }
//        else
//        {
//            stats.flame_gauge = maxflame_gauge;
//        }
//    }
//}
