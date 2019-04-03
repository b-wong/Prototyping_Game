using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CoinDisplay : MonoBehaviour
{
    [SerializeField] Text textUI;

    private void Update()
    {
        textUI.text = "Coins: " + Coins.numCoin;
    }
}
