using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CollectableDisplay : MonoBehaviour
{
    [SerializeField] Text textUI;

    void Update()
    {
        textUI.text = string.Format("{0}", GameManager.instance.gravitySwapCharges);
    }
}
