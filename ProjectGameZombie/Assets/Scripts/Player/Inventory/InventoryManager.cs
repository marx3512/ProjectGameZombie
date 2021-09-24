using UnityEngine;
using UnityEngine.UI;
using Player;

namespace Invent.Mana
{
    public class InventoryManager : MonoBehaviour
    {
        [SerializeField] private GameObject[] slots;
        [SerializeField] private GameObject item, itemInventory;

        [HideInInspector] public int slotId;
        [SerializeField] private Text descriptionInvent;

        [Header("PlayerStatus")]
        [SerializeField] private PlayerHandler playerHandler;
        [SerializeField] private Image lifeBar;

        private void Update() {
            if(playerHandler.health == 100) lifeBar.color = Color.green;
            else if(playerHandler.health >= 50 && playerHandler.health < 100) lifeBar.color = Color.yellow;
            else lifeBar.color = Color.red;
        }


        public void SendItem(Sprite img,string type)
        {   
            GameObject slotTarget = CheckSlots();
            if(slotTarget != null) {
                item.GetComponent<Image>().sprite = img;
                Instantiate(item,slotTarget.transform);
                slotTarget.GetComponent<SlotHandler>().Busy = true;
                slotTarget.GetComponent<SlotHandler>().typeItem = type;
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
            ManipItem();
        }

        public void Discardbutton()
        {
            itemInventory = slots[slotId].transform.GetChild(0).gameObject;
            SlotHandler slotScript = slots[slotId].GetComponent<SlotHandler>();
            slotScript.Busy = false;
            slotScript.ShowGroupButtons();
            Destroy(itemInventory);
        }

        void ManipItem(){
            itemInventory = slots[slotId].transform.GetChild(0).gameObject;
            SlotHandler slotScript = slots[slotId].GetComponent<SlotHandler>();
            if(slotScript.typeItem == "Heal") {
                playerHandler.health += 20;
                if(playerHandler.health > 100) playerHandler.health = 100;
                slotScript.ShowGroupButtons();
                slotScript.Busy = false;
                Destroy(itemInventory);
            }
            else descriptionInvent.text = "Item is not use";
            
        }
    }
}

