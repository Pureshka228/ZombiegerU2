using UnityEngine;

public class Shooting : MonoBehaviour {

    private int _bulletsLeft, _bulletsShot;
    private bool _shooting, _readyToShoot, _reloading, _allowButtonHold;
    
    private Rigidbody2D _rigidbody;
    
    [Header("Ссылки")]
    [SerializeField] private Transform firePoint;
    [SerializeField] private GameObject bulletPrefab;
    [SerializeField] private LayerMask whatIsEnemy;

    private void Awake() {
        _bulletsLeft = Equipment.MagazineSize;
        _readyToShoot = true;  
    }

    private void Update() {
        MyInput();
    }
    
    private void MyInput() {
        if (_allowButtonHold) {
            _shooting = Input.GetKey(KeyCode.Mouse0);
        } else {
            _shooting = Input.GetKeyDown(KeyCode.Mouse0);
        }
        
        if (Input.GetKeyDown(KeyCode.R) && _bulletsLeft < Equipment.MagazineSize && !_reloading) {
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
        _rigidbody.AddForce(firePoint.up * Equipment.BulletSpeed, ForceMode2D.Impulse);
        
        _bulletsLeft--;
        _bulletsShot--;
        
        Invoke("ResetShot", Equipment.TimeBetweenShooting);

        if (_bulletsShot > 0 && _bulletsLeft > 0) {
            _bulletsShot = Equipment.BulletPerTap;
            Invoke("Shoot", Equipment.TimeBetweenShots);
        }
    }

    private void ResetShot() {
        _readyToShoot = true;
    }

    private void Reload() {
        _reloading = true;
        Invoke("ReloadFinished", Equipment.ReloadTime);
    }

    private void ReloadFinished() {
        _bulletsLeft = Equipment.MagazineSize;
        _reloading = false;
    }
}