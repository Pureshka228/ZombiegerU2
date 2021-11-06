using UnityEngine;

public class Shooting : MonoBehaviour {

    private int _bulletsLeft, _bulletsShot;
    private bool _shooting;
    private bool _readyToShoot;
    private bool _reloading;
    private bool _allowButtonHold;
    
    private Rigidbody2D _rigidbody;
    
    [Header("References")]
    [SerializeField] private Transform firePoint;
    [SerializeField] private GameObject bulletPrefab;
    [SerializeField] private LayerMask whatIsEnemy;

    private void Start() {
        _bulletsLeft = Weapons.MagazineSize;
        _readyToShoot = true;  
    }

    private void Update() {
        ShootingSystem();
    }
    
    private void ShootingSystem() {
        if (_allowButtonHold) {
            _shooting = Input.GetKey(KeyCode.Mouse0);
        } else {
            _shooting = Input.GetKeyDown(KeyCode.Mouse0);
        }
        
        if (Input.GetKeyDown(KeyCode.R) && _bulletsLeft < Weapons.MagazineSize && !_reloading) {
            Reload();
        }
        
        if (_readyToShoot && _shooting && !_reloading && _bulletsLeft > 0) {
            Shoot();
        }
    }

    private void Shoot() {
        _readyToShoot = false;
        
        GameObject bullet = Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
        _rigidbody = bullet.GetComponent<Rigidbody2D>();
        _rigidbody.AddForce(firePoint.up * Weapons.BulletSpeed, ForceMode2D.Impulse);
        
        _bulletsLeft--;
        _bulletsShot--;
        
        Invoke("ResetShot", Weapons.TimeBetweenShooting);

        if (_bulletsShot > 0 && _bulletsLeft > 0) {
            _bulletsShot = Weapons.BulletPerTap;
            Invoke("Shoot", Weapons.TimeBetweenShots);
        }
    }

    private void ResetShot() {
        _readyToShoot = true;
    }

    private void Reload() {
        _reloading = true;
        Invoke("ReloadFinished", Weapons.ReloadTime);
    }

    private void ReloadFinished() {
        _bulletsLeft = Weapons.MagazineSize;
        _reloading = false;
    }
}