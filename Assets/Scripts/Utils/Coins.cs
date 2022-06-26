using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Coins : MonoBehaviour
{
    [Header("UI")]
    public TextMeshProUGUI[] texts;

    private int _coins;
    private string _coinsDataKey = "Coins";

    public int TotalCoins
    {
        get => _coins;
        set
        {
            _coins = value;
            SaveData();

            if (texts.Length > 0)
            {
                foreach (var item in texts)
                {
                    item.text = _coins.ToString();   
                }
            }
        }
    }

    public static Coins Instance;

    private void Awake()
    {
        Instance = this;
        LoadData();
    }

    [ContextMenu("Save Data")]
    public void SaveData()
    {
        PlayerPrefs.SetInt(_coinsDataKey, TotalCoins);
        PlayerPrefs.Save();
    }

    [ContextMenu("Load Data")]
    public void LoadData()
    {
        TotalCoins = PlayerPrefs.GetInt(_coinsDataKey, 5000);
    }
}
