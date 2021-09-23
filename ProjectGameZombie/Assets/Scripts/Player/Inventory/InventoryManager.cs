using UnityEngine;
using UnityEngine.UI;

namespace Invent.Mana
{
    public class InventoryManager : MonoBehaviour
    {
        [SerializeField] private GameObject[] slots;
        [SerializeField] private GameObject item, itemInventory;

        public int slotId;

        public void SendItem(Sprite img)
        {   
            GameObject slotTarget = CheckSlots();
            if(slotTarget != null) {
                item.GetComponent<Image>().sprite = img;
                Instantiate(item,slotTarget.transform);
                slotTarget.GetComponent<SlotHandler>().Busy = true;
            }
            else Debug.Log("Inventory full");
        }


        GameObject CheckSlots()
        {
            for (int i = 0; i < slots.Length; i++)
            {
                if (!slots[i].GetComponent<SlotHandler>().Busy) return slots[i];
            }
            return null;
        }

        public void Usebutton(){
            itemInventory = slots[slotId].GetComponentInChildren<GameObject>();
            Debug.Log("I'm using item");
        }

        public void Discardbutton()
        {
            Debug.Log("I'm discard item");
        }
    }
}

