using UnityEngine;

namespace Weapon
{
    public class WeaponsHandle : MonoBehaviour
    {
        [SerializeField] private WeaponStatus weaponStatus;
        private int maxAmmo;
        private int AmmoBag;

        void Start()
        {
            maxAmmo = weaponStatus.MaxAmmoInWeapon;
        }
    }
}
