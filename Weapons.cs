using UnityEngine;

public class Weapons : MonoBehaviour {
    
    public static int DamageWeapon = 1;
    public static int MagazineSize, BulletPerTap;
    public static float ReloadTime, TimeBetweenShooting, TimeBetweenShots;

    public enum GunSet { USPExpert, AK74, M4A1, MP5, AWP};

    public static void ChangeWeapon(GunSet gunSet) {
        switch (gunSet) {
            case GunSet.USPExpert:
                DamageWeapon = 1;
                MagazineSize = 12;
                BulletPerTap = 1;
                ReloadTime = 2.1f;
                TimeBetweenShooting = 0.4f;
                TimeBetweenShots = 0.4f;
                break;
            case GunSet.AK74:
                DamageWeapon = 1;
                MagazineSize = 30;
                BulletPerTap = 1;
                ReloadTime = 2.5f;
                TimeBetweenShooting = 0.2f;
                TimeBetweenShots = 0.2f;
                break;
            case GunSet.M4A1:
                DamageWeapon = 1;
                MagazineSize = 25;
                BulletPerTap = 1;
                ReloadTime = 3.1f;
                TimeBetweenShooting = 0.1f;
                TimeBetweenShots = 0.1f;
                break;
            case GunSet.MP5:
                DamageWeapon = 1;
                MagazineSize = 30;
                BulletPerTap = 1;
                ReloadTime = 2.97f;
                TimeBetweenShooting = 0.1f;
                TimeBetweenShots = 0.1f;
                break;
            case GunSet.AWP:
                DamageWeapon = 4;
                MagazineSize = 10;
                BulletPerTap = 1;
                ReloadTime = 3.6f;
                TimeBetweenShooting = 1.4f;
                TimeBetweenShots = 1.4f;
                break;
        }
    }
}
