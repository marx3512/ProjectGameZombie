using UnityEngine;
using Invent.Mana;

public class SlotHandler : MonoBehaviour
{   
    [SerializeField] private InventoryManager invManager;

    [SerializeField] private GameObject groupButtons;

    public bool Busy = false;
    public int id = 0;

    public void ShowGroupButtons()
    {
        if(Busy){
            if (groupButtons.activeSelf) {
                groupButtons.SetActive(false);
                invManager.slotId = id;
            }
            else {
                groupButtons.SetActive(true);
                invManager.slotId = id;
            }
        }
        else if(!Busy && groupButtons.activeSelf) groupButtons.SetActive(false);
    }
}
