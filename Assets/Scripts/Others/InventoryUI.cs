using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class InventoryUI : MonoBehaviour
{

    private TextMeshProUGUI gemText;

    void Start()
    {
        gemText = GetComponent<TextMeshProUGUI>();
    }
   public void UpdateGemText(Inventory inventory)
    {
        gemText.text = inventory.NumberOfGems.ToString();
    }
}
