using UnityEngine;

namespace Weapon
{
    public class WeaponsHandle : MonoBehaviour
    {
        [SerializeField] private WeaponStatus weaponStatus;
        [SerializeField] private int maxAmmo;
        [SerializeField] private int AmmoWeapon;
        [SerializeField] private int AmmoBag;

        void Start()
        {
            maxAmmo = weaponStatus.MaxAmmoInWeapon;
        }

        public void Shooting(){
            if(AmmoWeapon > 0) AmmoWeapon--;
            else if(AmmoWeapon == 0 && AmmoBag >= maxAmmo){
                AmmoBag -= maxAmmo;
                AmmoWeapon = maxAmmo;
            }
            else{
                AmmoWeapon = AmmoBag;
                AmmoBag = 0;
            }
        }

        public void Reloading(){
            if (AmmoBag > 0){
                var bullet = maxAmmo - AmmoWeapon;
                AmmoBag -= bullet;
                if(AmmoBag < 0) AmmoBag = 0;
                AmmoWeapon += bullet;
            }
        }
    }
}
