using UnityEngine;
using Invent.Mana;

namespace Item.interaction {
    
    public class InteractableItem : MonoBehaviour
    {
        [SerializeField] private InventoryManager inventoryManager;

        float m_MaxDistance;
        bool m_HitDetect;

        RaycastHit m_Hit;

        public LayerMask layerMask;
        public GameObject textObj;

        private void Start()
        {
            m_MaxDistance = 1.0f;
        }

        private void Update()
        {
            if (textObj.activeSelf && Input.GetKeyDown(KeyCode.E))
            {
                inventoryManager.SendItem(m_Hit.transform.GetComponent<ItensHandle>().itenIcon);
                Destroy(m_Hit.transform.gameObject);
            }
        }

        private void FixedUpdate()
        {
            m_HitDetect = Physics.BoxCast(transform.position, new Vector3(0.25f, 0.25f, 0.25f),
            transform.forward, out m_Hit, transform.rotation, m_MaxDistance, layerMask);

            if (m_HitDetect) textObj.SetActive(true);
            else textObj.SetActive(false);

        }

        /*private void OnDrawGizmos() {
            Gizmos.color = Color.red;

            if(m_HitDetect){
                Gizmos.DrawRay(transform.position, transform.forward * m_MaxDistance);
                Gizmos.DrawCube(transform.position + transform.forward * m_Hit.distance, transform.localScale);
            }
            else{
                Gizmos.DrawRay(transform.position, transform.forward * m_MaxDistance);
                Gizmos.DrawWireCube(transform.position + transform.forward * m_MaxDistance, transform.localScale);
            }
        }*/
    }
}


