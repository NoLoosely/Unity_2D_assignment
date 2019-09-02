using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// Script for handling equipment inventory - attached on EquipInventory object
/// For updating stats about equipped items, their values and for showing appropriate messages  
/// </summary>
public class EquipSlotController : MonoBehaviour
{
    private InventoryController _inventoryController;
    public Image[] _itemImage;

    public Text attackText, armorText, helathText, staminaText;
    public Text attackTextUI, armorTextUI, helathTextUI, staminaTextUI;
    private int _attack = 0;
    private int _totalArmor = 0;
    private int _totalStamina = 0;
    private bool _staminaMessageTrigger = true;
    private int _helath = 100;

    private bool _swordCollected = false;
    public GameObject swordMessage, equipItemMessage, runMessage;
    public Text equipItemText;
    public string collectedItemName = "None";

    private InventoryHandler _inventoryHandler;

    private void Awake()
    {
        swordMessage.SetActive(false);
        equipItemMessage.SetActive(false);
        runMessage.SetActive(false);
        _inventoryHandler = FindObjectOfType<InventoryHandler>();
    }

    private void Update()
    {
        attackText.text = _attack.ToString();
        armorText.text = _totalArmor.ToString();
        helathText.text = _helath.ToString() + "%";
        staminaText.text = _totalStamina.ToString();
        equipItemText.text = "Congratulations, you collected " + collectedItemName + ". Open inventory and press \"Left click\" to equip.";

        if(_totalStamina >= 28 && _staminaMessageTrigger)
        {
            runMessage.SetActive(true);
        }

        attackTextUI.text = _attack.ToString();
        armorTextUI.text = _totalArmor.ToString();
        helathTextUI.text = _helath.ToString() + "%";
        staminaTextUI.text = _totalStamina.ToString();
    }

    public int TotalAttack
    {
        get { return _attack; }
        set { _attack = value; }
    }

    public int TotalArmor
    {
        get { return _totalArmor; }
        set { _totalArmor = value; }
    }

    public int TotalStamina
    {
        get { return _totalStamina; }
        set { _totalStamina = value; }
    }

    public bool SwordCollected
    {
        get { return _swordCollected; }
        set { _swordCollected = value; }
    }


    public void CloseCollectedItemMessage(string itemName)
    {
        switch (itemName)
        {
            case "sword":
                swordMessage.SetActive(false);
                _inventoryHandler.InventoryTrigger = false;
                break;

            case "stamina":
                runMessage.SetActive(false);
                _staminaMessageTrigger = false;
                _inventoryHandler.InventoryTrigger = false;
                break;

            case "collected item":
                equipItemMessage.SetActive(false);
                _inventoryHandler.InventoryTrigger = false;
                break;

            default: break;
        }
       
    }

} // class end
