using TreeEditor;
using UnityEngine;
using UnityEngine.AI;

public class Zombie : MonoBehaviour {
    
    private const int _MAX_HEALTH = 5;
    private int _currentHealth;

    private void Start() {
        _currentHealth = _MAX_HEALTH;
    }

    public void TakeDamage(int damage) {
        _currentHealth -= damage;
        
        if (_currentHealth <= 0) Destroy(gameObject);
    }
}