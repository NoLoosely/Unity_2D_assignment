using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// Script for collecting/adding item to inventory - attached on every item object (potion, sowrd, etc.)
/// also used for handling the items which can be equipped by showing an appropriate message 
/// </summary>
public class ItemsController : MonoBehaviour
{

    private InventoryController _inventoryController;
    private GameObject _item;

    private EquipSlotController _equipSlotController;
    private InventoryHandler _inventoryHandler;


    private AudioSource _collectSound;

    private void Start()
    {
        _inventoryController = FindObjectOfType<InventoryController>();
        _equipSlotController = FindObjectOfType<EquipSlotController>();
        _inventoryHandler = FindObjectOfType<InventoryHandler>();
        _collectSound = GameObject.Find("ItemCollect").GetComponent<AudioSource>();
        _item = gameObject;
    }

    private void OnTriggerEnter2D(Collider2D obj)
    {
        if (obj.CompareTag("Player"))
        {
            for (int i = 0; i < _inventoryController.slots.Length; i++)
            {
                if (_inventoryController.IsFull[i] == false)
                {
                    _collectSound.Play();
                    _inventoryController.IsFull[i] = true;
                    _inventoryController.itemName[i].text = gameObject.name.ToUpper();

                    _inventoryController.slots[i].GetComponent<Image>().sprite = _item.GetComponent<SpriteRenderer>().sprite;
                    _inventoryController.slots[i].SetActive(true);
                    _inventoryController.removeSlots[i].SetActive(true);
                    CheckCollectedItem();
                    Instantiate(_item, _inventoryController.slots[i].transform);
                    Destroy(gameObject);

                    break;
                }
            }

        }
    }


    void CheckCollectedItem()
    {
        if (gameObject.name == "sword")
        {
            _equipSlotController.equipItemMessage.SetActive(true);
            _equipSlotController.collectedItemName = "Sword";
            _inventoryHandler.InventoryTrigger = true;
        }
        else if (gameObject.name == "Left Arm" || gameObject.name == "Right Arm")
        {
            _equipSlotController.equipItemMessage.SetActive(true);
            _equipSlotController.collectedItemName = "Arm armor";
            _inventoryHandler.InventoryTrigger = true;
        }
        else if (gameObject.name == "Legs" || gameObject.name == "Legs 2")
        {
            _equipSlotController.equipItemMessage.SetActive(true);
            _equipSlotController.collectedItemName = "Leg armor";
            _inventoryHandler.InventoryTrigger = true;
        }
        else if (gameObject.name == "Body lower")
        {
            _equipSlotController.equipItemMessage.SetActive(true);
            _equipSlotController.collectedItemName = "Body lower armor";
            _inventoryHandler.InventoryTrigger = true;
        }

    }


} // class end
