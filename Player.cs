using UnityEngine;

public class Player : MonoBehaviour {
    
    public Camera cam;
    public Vector2 lookDirection;
    public Gradient gradient;
    
    [SerializeField] private int maxHealth = 5;
    [SerializeField] private float speed = 6f;
    [SerializeField] private Joystick joystick;
    [SerializeField] private HealthBar healthBar;

    private int _currentHealth;
    private float _angle;
    private Vector2 _moveInput;
    private Vector2 _moveVelocity;
    private Vector2 _mousePosition;
    private Rigidbody2D _rigidbody;

    private void Awake() {
        _currentHealth = maxHealth;
        healthBar.SetMaxHealth(maxHealth);
        _rigidbody = GetComponent<Rigidbody2D>();
    }

    private void Update() {
        _moveInput = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));
        // _moveInput = new Vector2(joystick.Horizontal, joystick.Vertical); -> УПРАВЛЕНИЕ ДЛЯ Android
        _moveVelocity = _moveInput.normalized * speed;
        _rigidbody.MovePosition(_rigidbody.position + _moveVelocity * Time.fixedDeltaTime);
    
        _mousePosition = cam.ScreenToWorldPoint(Input.mousePosition);
        lookDirection = _mousePosition - _rigidbody.position;
        _angle = Mathf.Atan2(lookDirection.y, lookDirection.x) * Mathf.Rad2Deg - 90f; // Atan2(y, x) - угол
        _rigidbody.rotation = _angle;
    }

    public void TakeDamage(int damage) {
        _currentHealth -= damage;
        healthBar.SetHealth(_currentHealth);

        if (_currentHealth <= 0) Destroy(gameObject);
    }
    
    private void TakeWeapon(Weapons.GunSet weapon) {
        Weapons.ChangeWeapon(weapon);
    }
}