using UnityEngine;

public class Bullet : MonoBehaviour {
    
    private void Update() {
        Invoke(nameof(DestroyBullet), 1);
    }

    private void OnTriggerEnter2D(Collider2D other) {
        if (other.GetComponent<Zombie>() != null) {
            
            Zombie zombie = other.GetComponent<Zombie>();
            zombie.TakeDamage(Weapons.DamageWeapon);
        }
        DestroyBullet();
    }
    
    private void DestroyBullet() {
        Destroy(gameObject);
    }

}