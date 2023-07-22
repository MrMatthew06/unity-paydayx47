using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;
using UnityEngine.UI;

public class ItemScript : MonoBehaviour
{
    [HideInInspector]
    public InventoryScript script;
    public GameObject inventory;
    RuchScript player;
    public BoxCollider2D box;
    public SpriteRenderer spriteRenderer;
    public string texturePath;
    bool off = false;
    public int IDSlotHere;

    // Start is called before the first frame update
    void Start()
    {
        script = inventory.GetComponent<InventoryScript>();
        box = GetComponent<BoxCollider2D>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        player = GameObject.Find("HITMAN").GetComponent<RuchScript>();
    }

    


    // Update is called once per frame
    void FixedUpdate()
    {

        if (Input.GetKey(KeyCode.Q) && off == true)
        {
            if (script.slotActive == IDSlotHere)
            {
                script.EnterToGame();
                gameObject.transform.position = player.position;
                box.enabled = true;
                spriteRenderer.enabled = true;
                off = false;
            }

        }
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            if (Input.GetKey(KeyCode.E))
            {
                script.EnterToInventory(gameObject);
                IDSlotHere = script.IDSlot;
                box.enabled = false;
                spriteRenderer.enabled = false;
                off = true;

            }
        }

    }


}