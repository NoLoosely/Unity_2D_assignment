using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// Script which is used for saving and handling collected items - attached on Player object
/// </summary>
public class InventoryController : MonoBehaviour
{
    // Standard items
    private bool[] _isFull = new bool[32];
    public GameObject[] slots;
    public Text[] itemName;
    public GameObject[] removeSlots;

    public bool[] IsFull
    {
        get { return _isFull; }
        set { _isFull = value; }
    }

} // class end
