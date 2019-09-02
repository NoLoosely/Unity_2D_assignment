using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// Script for handling Inventory, Equipment and Attributes UI - attached on Canvas_Inventory object
/// Also used for paused the game if any of UI above is opened
/// </summary>
public class InventoryHandler : MonoBehaviour
{
    public Transform itemsParent;
    public SlotController[] _slots;
    private InventoryController _inventoryController;

    public GameObject inventoryPanel, inventoryButton;
    private bool _inventoryTrigger = false;

    public GameObject equipmentPanel, equipmentButton;
    public bool _equipmentTrigger = false;

    public GameObject[] allItems = new GameObject[32];
    public GameObject promptMessagePanel;

    private AudioSource _buttonClick;
    private Button _dropAllItems;

    public GameObject playerAbilitesPanel, playerAbilitiesButton;
    public bool _abilitiesTrigger = false;

    void Start()
    {
        _inventoryController = FindObjectOfType<InventoryController>();
        _slots = itemsParent.GetComponentsInChildren<SlotController>();
        _buttonClick = GameObject.Find("ButtonClick").GetComponent<AudioSource>();
        _dropAllItems = GameObject.Find("RemoveAllItemsButton").GetComponent<Button>();
        inventoryPanel.SetActive(false);
        equipmentPanel.SetActive(false);
        promptMessagePanel.SetActive(false);
        playerAbilitesPanel.SetActive(false);

    }

    void Update()
    {
        KeyBoardInvetoryOpen();
        KeyBoardEquipmentOpen();
        KeyBoardAbilitiesOpen();

        if (_inventoryTrigger || _equipmentTrigger)
            Time.timeScale = 0f;
        else
            Time.timeScale = 1f;

        if(_dropAllItems != null)
            CheckInventory();

    }


    void CheckInventory()
    {
        var counter = 0;
        for (int i = 0; i < _inventoryController.slots.Length; i++)
        {
            if (_inventoryController.IsFull[i] == true)
            {
                counter++;
            }
        }

        if (counter > 1)
            _dropAllItems.interactable = true;
        else
            _dropAllItems.interactable = false;
    }

    #region Inventory Methods
    public void OpenInventory(bool trigger)
    {
        _buttonClick.Play();
        inventoryPanel.SetActive(trigger);
        inventoryButton.SetActive(!trigger);
        _inventoryTrigger = true;
    }

    public void CloseInventory(bool trigger)
    {
        _buttonClick.Play();
        inventoryPanel.SetActive(trigger);
        inventoryButton.SetActive(!trigger);
        _inventoryTrigger = false;
    }

    void KeyBoardInvetoryOpen()
    {
        if (Input.GetKeyDown(KeyCode.I))
        {
            _inventoryTrigger = !_inventoryTrigger;
            if (_inventoryTrigger)
            {
                inventoryPanel.SetActive(_inventoryTrigger);
                inventoryButton.SetActive(!_inventoryTrigger);
            }
            else
            {
                inventoryPanel.SetActive(_inventoryTrigger);
                inventoryButton.SetActive(!_inventoryTrigger);
            }
        }
    }
    #endregion




    #region Equipment Methods
    public void OpenEquipment(bool trigger)
    {
        _buttonClick.Play();
        equipmentPanel.SetActive(trigger);
        equipmentButton.SetActive(!trigger);
        _equipmentTrigger = true;
    }

    public void CloseEquipment(bool trigger)
    {
        _buttonClick.Play();
        equipmentPanel.SetActive(trigger);
        equipmentButton.SetActive(!trigger);
        _equipmentTrigger = false;
    }

    void KeyBoardEquipmentOpen()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            _equipmentTrigger = !_equipmentTrigger;
            if (_inventoryTrigger)
            {
                equipmentPanel.SetActive(_equipmentTrigger);
                equipmentButton.SetActive(!_equipmentTrigger);
            }
            else
            {
                equipmentPanel.SetActive(_equipmentTrigger);
                equipmentButton.SetActive(!_equipmentTrigger);
            }
        }

    }
    #endregion



    #region Abilities Methods
    public void OpenAbilitiesPanel(bool trigger)
    {
        _buttonClick.Play();
        playerAbilitesPanel.SetActive(trigger);
        playerAbilitiesButton.SetActive(!trigger);
        _abilitiesTrigger = true;
    }

    public void CloseAbilitiesPanel(bool trigger)
    {
        _buttonClick.Play();
        playerAbilitesPanel.SetActive(trigger);
        playerAbilitiesButton.SetActive(!trigger);
        _abilitiesTrigger = false;
    }

    void KeyBoardAbilitiesOpen()
    {
        if (Input.GetKeyDown(KeyCode.C))
        {
            _abilitiesTrigger = !_abilitiesTrigger;
            if (_abilitiesTrigger)
            {
                playerAbilitesPanel.SetActive(_abilitiesTrigger);
                playerAbilitiesButton.SetActive(!_abilitiesTrigger);
            }
            else
            {
                playerAbilitesPanel.SetActive(_abilitiesTrigger);
                playerAbilitiesButton.SetActive(!_abilitiesTrigger);
            }
        }
    }
    #endregion



    #region UI Methods
    public void ShowPromptMessage()
    {
        promptMessagePanel.SetActive(true);
    }

    public void ExitPromptMessage()
    {
        _buttonClick.Play();
        promptMessagePanel.SetActive(false);
    }


    public void RemoveAllItems()
    {
        _buttonClick.Play();
        promptMessagePanel.SetActive(false);
        foreach (var item in allItems)
        {
            item.GetComponent<Image>().sprite = null;

            foreach (Transform child in item.transform)
            {
                
                child.GetComponent<SpawnItem>().SpawnDroppedItem();
                GameObject.Destroy(child.gameObject);
            }
        }

        for (int i = 0; i < allItems.Length; i++)
        {
            _inventoryController.itemName[i].text = "";
        }

    }
#endregion

    public bool InventoryTrigger
    {
        get { return _inventoryTrigger; }
        set { _inventoryTrigger = value; }
    }


    public void ReturnToMainMenu()
    {
        MainMenuController.Instance.BackToMainMenu();
    }

} // class end
