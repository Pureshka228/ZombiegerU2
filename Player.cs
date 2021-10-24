using UnityEngine;

public class Player : MonoBehaviour {
    
    [SerializeField] private int maxHealth = 5;

    private int _currentHealth;
    private float _angle;
    
    private Vector2 _moveInput;
    private Vector2 _moveVelocity;
    private Vector2 _mousePosition;
    private Vector2 _lookDirection;
    private Rigidbody2D _rigidbody;

    [Header("Ссылки")]
    [SerializeField] private Joystick joystick;
    [SerializeField] private HealthBar healthBar;
    [SerializeField] private Camera cam;

    private void Awake() {

        TakeWeapon(Equipment.GunSet.AK74);
        
        _currentHealth = maxHealth;
        healthBar.SetMaxHealth(maxHealth);
        _rigidbody = GetComponent<Rigidbody2D>();
    }

    private void Update() {
        _moveInput = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));
        // _moveInput = new Vector2(joystick.Horizontal, joystick.Vertical); -> УПРАВЛЕНИЕ ДЛЯ Android
        _moveVelocity = _moveInput.normalized * Equipment.SpeedWithWeapon;
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
        maxHealth = 7;
    }
    
    private void TakeWeapon(Equipment.GunSet weapon) {
        Equipment.SelectWeapon(weapon);
    }
}