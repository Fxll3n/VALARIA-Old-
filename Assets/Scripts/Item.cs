using UnityEngine;

[CreateAssetMenu(fileName = "New Item", menuName = "Item/Create New Item")]
public class Item : ScriptableObject
{
    public int ItemId;
    public string ItemnName;
    public int ItemAmount;
    public Sprite ItemIcon;
}
