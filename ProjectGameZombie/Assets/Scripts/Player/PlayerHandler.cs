using UnityEngine;
using Cinemachine;
using Weapon;

namespace Player{
    public class PlayerHandler : MonoBehaviour
    {
        //Variable move player
        [Header("Move player")]
        [SerializeField] private CharacterController characterController;
        [SerializeField] private Transform cam;
        private float turnSmoothTime = 0.15f;
        private float turnSmoothVelocity;
        public float speed = 0f;

        //Variabel shooting player
        [Header("Shooting player")]
        [SerializeField] private Transform camTransform;
        [SerializeField] private LayerMask layerMask;
        [SerializeField] private CinemachineFreeLook cine;
        [SerializeField] private WeaponsHandle weaponsHandle;

        //Variable animations player
        [Header("Animations")]
        [SerializeField] private Animator anim;

        //Variable status player
        [Header("Status players")]
        [SerializeField] private PlayerStatus playerStatus;
        private float health;

		//Munition
		[HideInInspector] public int AmmoBag;
		void Start()
        {
            health = playerStatus.Health;
        }

        void Update()
        {
            //Move player
            #region Move player
            float x = Input.GetAxis("Horizontal");
            float z = Input.GetAxis("Vertical");

            Vector3 move = new Vector3(x, 0, z).normalized;

            if (move.magnitude >= 0.1f)
            {
                float targetAngle = Mathf.Atan2(move.x, move.z) * Mathf.Rad2Deg + cam.eulerAngles.y;
                float angle = Mathf.SmoothDampAngle(transform.eulerAngles.y, targetAngle, ref turnSmoothVelocity, turnSmoothTime);
                transform.rotation = Quaternion.Euler(0f, angle, 0f);

                Vector3 moveDir = Quaternion.Euler(0f, targetAngle, 0f) * Vector3.forward;
                anim.SetBool("MoveNotSight", true);
                characterController.Move(moveDir * speed * Time.deltaTime);
            }
            else anim.SetBool("MoveNotSight", false);
            #endregion
            //Shooting player
            #region Shot player
            if (Input.GetMouseButtonDown(0))
            {
                RaycastHit hit;
                if (Physics.Raycast(camTransform.position, camTransform.forward, out hit, 50f, layerMask))
                {
                    var target = hit.transform.gameObject.GetComponent<EnemyHandler>();
                    if (target != null) target.health -= 1;
                }
                weaponsHandle.Shooting();
            }
            if (Input.GetMouseButton(1))
            {
                cine.m_Lens.FieldOfView = 20;
                cine.m_YAxis.m_MaxSpeed = 1f;
                cine.m_XAxis.m_MaxSpeed = 100.0f;
                //Animations
                anim.SetFloat("X", x);
                anim.SetFloat("Y", z);
            }
            else if (Input.GetMouseButtonUp(1))
            {
                cine.m_Lens.FieldOfView = 40;
                cine.m_YAxis.m_MaxSpeed = 2.0f;
                cine.m_XAxis.m_MaxSpeed = 200.0f;
            }
            if(Input.GetKeyDown(KeyCode.R)) weaponsHandle.Reloading();
            #endregion
        }
    }
}