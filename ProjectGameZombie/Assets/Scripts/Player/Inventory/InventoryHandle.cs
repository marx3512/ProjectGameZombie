using UnityEngine;

namespace Inventory.Code {
    
    public class InventoryHandle : MonoBehaviour
    {
        public GameObject inventoryObj;


        private void Start()
        {
            inventoryObj.SetActive(false);
        }

        private void Update()
        {
            if (Input.GetKeyDown(KeyCode.I))
            {
                if (inventoryObj.activeSelf){
                    ChangeBool(false);
                    Cursor.lockState = CursorLockMode.Locked;
                } 
                else{
                    Cursor.lockState = CursorLockMode.None;
                    ChangeBool(true);
                }
            }
        }

        private void ChangeBool(bool cond){
            inventoryObj.SetActive(cond);
            Cursor.visible = cond;
        }
    }
}
