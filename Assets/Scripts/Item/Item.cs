using UnityEngine;

public class Item
{
    //public int itemID;
    public string itemName;
    public int sizeX; // 가로 칸 수
    public int sizeY; // 세로 칸 수
    public bool rotated;
    //public GameObject prefab;

    public RectTransform ui; // 실제 아이콘 RectTransform

    public Item(string itemName, int sizeX, int sizeY, bool rotated,RectTransform ui)
    {
        //this.itemID = itemID;
        this.itemName = itemName;
        this.sizeX = sizeX;
        this.sizeY = sizeY;
        this.rotated = rotated;
        //this.prefab = prefab;
        this.ui = ui;
    }
}
