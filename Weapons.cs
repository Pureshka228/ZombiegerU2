using UnityEngine;

public class Weapons : MonoBehaviour {

    public enum GunSet { USP, AK74, M4A1, MP5, AWP};
    public static int DamageWeapon = 1;

    public static void ChangeWeapon(GunSet gunSet) {
        switch (gunSet) {
            case GunSet.USP  : DamageWeapon = 1; break;
            case GunSet.AK74 : DamageWeapon = 1; break;
            case GunSet.M4A1 : DamageWeapon = 1; break;
            case GunSet.MP5  : DamageWeapon = 1; break;
            case GunSet.AWP  : DamageWeapon = 5; break;
        }
    }
}
