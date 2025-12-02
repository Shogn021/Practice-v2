using NUnit.Framework.Constraints;
using UnityEngine;
using UnityEngine.Rendering.Universal;

public class InventoryGrid : MonoBehaviour
{
    public int width;
    public int height;
    public Slot slotPrefab;
    public RectTransform slotsParent; // slots Panel

    public Item[,] items;
    public Slot[,] slots;

    public RectTransform testItemUI;
    public GameObject itemsPanel;
    public int testX;
    public int testY;

    public int[] test;

    void Start()
    {
        items = new Item[width, height];
        slots = new Slot[width, height];

        for(int y = 0; y < height; y++)
        {
            for(int x = 0; x < width; x++)
            {
                var s = Instantiate(slotPrefab, slotsParent);
                s.x = x;
                s.y = y;
                slots[x, y] = s;
            }
        }

        Item testItem = new Item("Sphere", 4, 4, false,testItemUI);
        Place(testItem, testX, testY);
    }

    public bool CanPlace(Item item, int startX, int startY)
    {
        int w = item.rotated ? item.sizeY : item.sizeX;
        int h = item.rotated ? item.sizeX : item.sizeY;

        // 인벤 범위 밖이면 안 됨
        if (startX < 0 || startY < 0) return false;
        if (startX + w > width) return false;
        if (startY + h > height) return false;

        // 이미 다른 아이템이 있는 칸이 있는지 검사
        for (int y = 0; y < h; y++)
        {
            for (int x = 0; x < w; x++)
            {
                if (items[startX + x, startY + y] != null)
                    return false;
            }
        }

        return true;
    }

    public void Place(Item item, int startX, int startY)
    {
        int w = item.rotated ? item.sizeY : item.sizeX;
        int h = item.rotated ? item.sizeX : item.sizeY;

        if (!CanPlace(item, startX, startY))
            return;

        // 배열 채우기
        for (int y = 0; y < h; y++)
        {
            for (int x = 0; x < w; x++)
            {
                items[startX + x, startY + y] = item;
            }
        }

        
        // UI 위치는 "왼쪽 위 슬롯" 기준으로 맞춰줌
        Slot anchorSlot = slots[startX, startY];
        item.ui.SetParent(anchorSlot.transform, false);

        RectTransform itemRT = item.ui;
        RectTransform slotRT = anchorSlot.GetComponent<RectTransform>();

        // 슬롯 기준으로 딱 고정
        itemRT.anchorMin = new Vector2(0f, 1f);
        itemRT.anchorMax = new Vector2(0f, 1f);
        itemRT.pivot = new Vector2(0f, 1f);

        // 위치도 슬롯 위치 그대로 사용
        itemRT.anchoredPosition = slotRT.anchoredPosition;

        // 필요하면 sizeX/sizeY 만큼 크기도 조절
        Vector2 cellSize = slotRT.sizeDelta;
        itemRT.sizeDelta = new Vector2(cellSize.x * item.sizeX, cellSize.y * item.sizeY);

        // 크기는 이미 sizeDelta로 칸 단위 맞춰둔 상태
        itemRT.localScale = Vector3.one;
        


    }


}
