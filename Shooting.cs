using UnityEngine;

public class Shooting : MonoBehaviour {
    
    public GameObject bulletPrefab;
    public Transform firePoint;

    [SerializeField] private float bulletSpeed = 200f;

    private Rigidbody2D _rigidbody;
    
    private void Update() {
        if (Input.GetMouseButtonDown(0)) {
            Shoot();
        }
    }
    
    private void Shoot() {
       GameObject bullet = Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
       _rigidbody = bullet.GetComponent<Rigidbody2D>();
       _rigidbody.AddForce(firePoint.up * bulletSpeed, ForceMode2D.Impulse);
    }
}