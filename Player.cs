using UnityEngine;

public class Player : MonoBehaviour {
    
    private const int _MAX_HEALTH = 5;
    private int _currentHealth;
    private float _angle;
    
    private Vector2 _moveInput;
    private Vector2 _moveVelocity;
    private Vector2 _mousePosition;
    private Vector2 _lookDirection;
    private Rigidbody2D _rigidbody;

    [Header("References")]
    [SerializeField] private Joystick joystick;
    [SerializeField] private HealthBar healthBar;
    [SerializeField] private Camera cam;

    private void Start() {

        TakeWeapon(Weapons.GunSet.AK74);
        
        _currentHealth = _MAX_HEALTH;
        healthBar.SetMaxHealth(_MAX_HEALTH);
        _rigidbody = GetComponent<Rigidbody2D>();
    }

    private void Update() {
        _moveInput = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));
        // _moveInput = new Vector2(joystick.Horizontal, joystick.Vertical); -> УПРАВЛЕНИЕ ДЛЯ Android
        _moveVelocity = _moveInput.normalized * Weapons.SpeedWithWeapon;
        _rigidbody.MovePosition(_rigidbody.position + _moveVelocity * Time.fixedDeltaTime);
    
        _mousePosition = cam.ScreenToWorldPoint(Input.mousePosition);
        _lookDirection = _mousePosition - _rigidbody.position;
        _angle = Mathf.Atan2(_lookDirection.y, _lookDirection.x) * Mathf.Rad2Deg - 90f; // Atan2(y, x) - угол
        _rigidbody.rotation = _angle;
    }

    public void TakeDamage(int damage) {
        _currentHealth -= damage;
        healthBar.SetHealth(_currentHealth);

        if (_currentHealth <= 0) Destroy(gameObject);
    }

    private void SetEquipmentKit() {
        _currentHealth = 7;
    }
    
    private void TakeWeapon(Weapons.GunSet weapon) {
        Weapons.SelectWeapon(weapon);
    }
}