using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Script which is used to spawn the item from the inventory back to scene - attached on every item object (potion, sowrd, etc.)
/// </summary>
public class SpawnItem : MonoBehaviour
{
    private GameObject _item;
    private Transform _player;

    void Start()
    {
        _player = FindObjectOfType<PlayerController>().transform;
        _item = gameObject;
    }

    public void SpawnDroppedItem()
    {
        Vector2 playerPos = new Vector2(_player.position.x + 1f, _player.position.y + 1f);
        Instantiate(_item, playerPos, Quaternion.identity);
    }

    
} // class end
