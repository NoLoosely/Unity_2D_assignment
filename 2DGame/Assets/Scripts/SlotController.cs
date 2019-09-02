using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// Script for removing items from inventory and to equip appropriate  items - attached on every Slot object (Slot/Item/BackgroundImage)
/// </summary>
public class SlotController : MonoBehaviour
{
    private InventoryController _inventoryController;
    private Image _itemImage;
    [SerializeField]
    private Text _currentItemName;
    public int currentSlot;

    private EquipSlotController _equipSlotController;
    private InventoryHandler _inventoryHandler;

    private void Awake()
    {
        _itemImage = GetComponent<Image>();
        _inventoryController = FindObjectOfType<InventoryController>();
        _equipSlotController = FindObjectOfType<EquipSlotController>();
        _inventoryHandler = FindObjectOfType<InventoryHandler>();
        _currentItemName.text = "";
    }

    private void Update()
    {
        if (transform.childCount <= 0)
            _inventoryController.IsFull[currentSlot] = false;
    }

    public void RemoveItem()
    {
        _itemImage.sprite = null;
        _currentItemName.text = "";
        foreach (Transform child in transform)
        {
            child.GetComponent<SpawnItem>().SpawnDroppedItem();
            GameObject.Destroy(child.gameObject);
        }
    }

    public void OnItemClick()
    {
        foreach (Transform child in transform)
        {
            var objName = child.gameObject.name;
            // print(objName);
            if (objName.Contains("sword"))
            {
                _inventoryHandler.OpenEquipment(true);
                var tempColor = _equipSlotController._itemImage[0].color;
                tempColor.a = 1f;
                _equipSlotController._itemImage[0].color = tempColor;
                _equipSlotController.TotalAttack = 115;
                _equipSlotController.SwordCollected = true;
                _equipSlotController.swordMessage.SetActive(true);
                _currentItemName.text = "";

                _itemImage.sprite = null;
                GameObject.Destroy(child.gameObject);
            }
            else if(objName.Contains("Right Arm"))
            {
                _inventoryHandler.OpenEquipment(true);
                var tempColor = _equipSlotController._itemImage[1].color;
                tempColor.a = 1f;
                _equipSlotController._itemImage[1].color = tempColor;
                _equipSlotController.TotalArmor += 10;
                _currentItemName.text = "";

                _itemImage.sprite = null;
                GameObject.Destroy(child.gameObject);
            }
            else if (objName.Contains("Body lower"))
            {
                _inventoryHandler.OpenEquipment(true);
                var tempColor = _equipSlotController._itemImage[2].color;
                tempColor.a = 1f;
                _equipSlotController._itemImage[2].color = tempColor;
                _equipSlotController.TotalArmor += 20;
                _currentItemName.text = "";

                _itemImage.sprite = null;
                GameObject.Destroy(child.gameObject);
            }
            else if (objName.Contains("Left Arm"))
            {
                _inventoryHandler.OpenEquipment(true);
                var tempColor = _equipSlotController._itemImage[3].color;
                tempColor.a = 1f;
                _equipSlotController._itemImage[3].color = tempColor;
                _equipSlotController.TotalArmor += 10;
                _currentItemName.text = "";

                _itemImage.sprite = null;
                GameObject.Destroy(child.gameObject);
            }
            else if (objName.Contains("Legs 2"))
            {
                _inventoryHandler.OpenEquipment(true);
                var tempColor = _equipSlotController._itemImage[4].color;
                tempColor.a = 1f;
                _equipSlotController._itemImage[4].color = tempColor;
                _equipSlotController.TotalArmor += 6;
                _equipSlotController.TotalStamina += 14;
                _currentItemName.text = "";

                _itemImage.sprite = null;
                GameObject.Destroy(child.gameObject);
            }
            else if (objName.Contains("Legs"))
            {
                _inventoryHandler.OpenEquipment(true);
                var tempColor = _equipSlotController._itemImage[5].color;
                tempColor.a = 1f;
                _equipSlotController._itemImage[5].color = tempColor;
                _equipSlotController.TotalArmor += 6;
                _equipSlotController.TotalStamina += 14;
                _currentItemName.text = "";

                _itemImage.sprite = null;
                GameObject.Destroy(child.gameObject);
            }

        }
    }


} // class end
