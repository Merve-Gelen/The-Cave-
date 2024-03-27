using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using TMPro;

public class ShopManager : MonoBehaviour
{
    public int[,] shopItems = new int[4,4];
    public TMP_Text shopCrystalsTXT;
    public TMP_Text mainCrystalText;
    private CrystalCounter crystalCounter; // CrystalCounter script'ine referans

    // Start is called before the first frame update
    void Start()
    {
        // CrystalCounter script'inden referansı al
        crystalCounter = FindObjectOfType<CrystalCounter>();

        // Başlangıçta metni güncelle
        shopCrystalsTXT.text = "Crystals: " + crystalCounter.currentCrystals.ToString();

        //ID
        shopItems[1, 1] = 1;
        shopItems[1, 2] = 2;

        //Price
        shopItems[2, 1] = 5;
        shopItems[2, 2] = 5;

        //Quantity
        shopItems[3, 1] = 0;
        shopItems[3, 2] = 0;
    }

    public void Buy()
    {
        GameObject ButtonRef = GameObject.FindGameObjectWithTag("Event").GetComponent<EventSystem>().currentSelectedGameObject;

        // CrystalCounter script'inden kristal sayısını alarak kullan
        if (crystalCounter.currentCrystals >= shopItems[2, ButtonRef.GetComponent<ButtonInfo>().ItemID])
        {
            crystalCounter.currentCrystals -= shopItems[2, ButtonRef.GetComponent<ButtonInfo>().ItemID];
            shopItems[3, ButtonRef.GetComponent<ButtonInfo>().ItemID]++;
            shopCrystalsTXT.text = "Crystals: " + crystalCounter.currentCrystals.ToString();
            mainCrystalText.text = ": " + crystalCounter.currentCrystals.ToString();
            ButtonRef.GetComponent<ButtonInfo>().QuantityTxt.text = shopItems[3, ButtonRef.GetComponent<ButtonInfo>().ItemID].ToString();
        }
    }
}
