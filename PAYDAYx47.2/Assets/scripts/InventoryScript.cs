using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Experimental.Rendering;
using UnityEngine.UI;

public class InventoryScript : MonoBehaviour
{
    public GameObject[] item = new GameObject[5];
    public GameObject[] slots = new GameObject[5];
    public Image[] image = new Image[5];
    public int IDSlot;
    public Slot slot;
    public int slotActive;


    // Start is called before the first frame update
    void Start()
    {
        for (int i = 0; i < 5; i++)
        {
            image[i].sprite = Resources.Load<Sprite>("nic");
        }
    }

    // Update is called once per frame
    void FixedUpdate()
    {

        if (Input.GetKey(KeyCode.Alpha1))
        {
            Reload(0);
            slotActive = 0;
        }
        else if (Input.GetKey(KeyCode.Alpha2))
        {
            Reload(1);
            slotActive = 1;
        }
        else if (Input.GetKey(KeyCode.Alpha3))
        {
            Reload(2);
            slotActive = 2;
        }
        else if (Input.GetKey(KeyCode.Alpha4))
        {
            Reload(3);
            slotActive = 3;
        }
        else if (Input.GetKey(KeyCode.Alpha5))
        {
            Reload(4);
            slotActive = 4;
        }
    }

    public void EnterToInventory(GameObject gameObject)
    {
        int zajeteSloty = 0;
        string texturePath = gameObject.GetComponent<ItemScript>().texturePath as string;

        for (int i = 0; i < 5; i++)
        {
            if (item[i] == null)
            {
                item[i] = gameObject;
                IDSlot = i;
                image[i].sprite = Resources.Load<Sprite>(texturePath);
                break;
            }
            else
            {
                zajeteSloty++;
                if (zajeteSloty == item.Length)
                {
                    Debug.Log("Brak miejsca w ekwipunku!");
                }
            }
        }
    }

    public void EnterToGame()
    {
        image[slotActive].sprite = Resources.Load<Sprite>("nic");
        item[slotActive] = null;
    }

    void Reload(int a)
    {
        for (int i=0; i < 5; i++)
        {
            slot = slots[i].GetComponent<Slot>();
            slot.image.sprite = Resources.Load<Sprite>("slot");
        }
        slot = slots[a].GetComponent<Slot>();
        slot.image.sprite = Resources.Load<Sprite>("slotwybrany");
    }
}
