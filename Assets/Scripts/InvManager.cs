using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InvManager : MonoBehaviour
{
    public static InvManager Instance;
    public List<Item> Items = new List<Item>();

    public Transform ItemContent;
    public GameObject InvItem;

    private void Awake()
    {
        Instance = this;
    }

    public void Add(Item Item)
    {
        Items.Add(Item);
    }

    public void Remove(Item Item)
    {
        Items.Remove(Item);
    }

    public void ListItems()
    {
        foreach (Transform item in ItemContent){
            Destroy(item.gameObject);
        }
        foreach (var item in Items)
        {
            GameObject obj = Instantiate(InvItem, ItemContent);
            var itemName = obj.transform.Find("ItemName").GetComponent<Text>();
            var itemIcon = obj.transform.Find("ItemIcon").GetComponent<Image>();

            itemName.text = item.ItemnName;  
            itemIcon.sprite = item.ItemIcon;  
        }
    }

}
