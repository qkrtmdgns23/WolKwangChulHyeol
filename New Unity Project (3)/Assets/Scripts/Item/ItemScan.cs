using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class ItemScan : MonoBehaviour
{

    [SerializeField]
    private float range;  // 상호 작용 가능한 최대 거리
    [SerializeField]
    private LayerMask layerMask;
    [SerializeField]
    private Text actionText;

    private RaycastHit hit;
    private Vector3 directiona;
    private bool pickupobj = false;  // 아이템 습득 가능할시 True 
    private Dictionary<int, string> itemName_kr = new Dictionary<int, string>()
    {
        {0,"힐링 포션"},
        {1,"마나 포션"},
        {2,"스태미너 포션"},
        {3,"아머"},
        {4,"전기 에너지"},
        {5,"화염 에너지"},
        {6,"신성 에너지"},
        {7,"독 에너지"},
    };
    public enum itemName
    {
        HpPortion = 0,
        MpPortion = 1,
        SpPortion = 2,
        Armor = 3,
        Battery = 4,
        GasBottle =5,
        HolyWater = 6,
        PoisonBarrel = 7
    }
    private itemName itemN;
     void Update()
    {
        CheckItem();
        TryAction();
    }
    private void TryAction()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            CheckItem();
            if (pickupobj)
            {
                if (hit.transform != null)
                {

                    I_Item item = hit.collider.GetComponent<I_Item>();
                    if (item != null)
                    {
                        item.Use();
                    }
                    
                    Destroy(hit.transform.gameObject);
                    ItemInfoDisappear();
                }
            }
        }
    }
    private void CheckItem()
    {
        if (Physics.Raycast(transform.position, transform.forward, out hit, range, layerMask))
        {

            if (hit.transform.CompareTag("Item"))
            {
                ItemInfoAppear();
            }
        }
        else
            ItemInfoDisappear();
    }
    private void ItemInfoAppear()
    {
        itemN = (itemName)Enum.Parse(typeof(itemName), hit.collider.name);
        pickupobj = true;
        actionText.gameObject.SetActive(true);
        actionText.text = "<color=yellow>" + itemName_kr[(int)itemN]+ "</color>" + "<color=red>" + " 획득 " + "</color>" + "<color=yellow>" + "(E)" + "</color>";
    }

    private void ItemInfoDisappear()
    {
        pickupobj = false;
        actionText.gameObject.SetActive(false);
    }
}
