using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
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
        pickupobj = true;
        actionText.gameObject.SetActive(true);
        actionText.text = hit.collider.name + " 획득 " + "<color=yellow>" + "(E)" + "</color>";
    }

    private void ItemInfoDisappear()
    {
        pickupobj = false;
        actionText.gameObject.SetActive(false);
    }
}
