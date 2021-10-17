using TreeEditor;
using UnityEngine;
using UnityEngine.AI;

public class Zombie : MonoBehaviour {
    
    [SerializeField] private int maxHealth = 5;
    [SerializeField] private int damageZombie = 1;


/*
    [SerializeField] private float timeBetweenAttacks = 1f;
    [SerializeField] private float sightRange = 10f, attackRange = 2f;
    [SerializeField] private LayerMask isPlayer;
    
    private bool _alreadyAttacked, _playerInSightRange, _playerInAttackRange;
    private NavMeshAgent _agent;
    private Player _player;
    
    // Патрулирование
    [SerializeField] private float walkPointRange;
    [SerializeField] private Vector3 walkPoint;
    private bool _walkPointSet;

    private void Awake() {
        _agent = GetComponent<NavMeshAgent>();
        _player = GetComponent<Player>();
    }

    private void Update() {
        // Проверка, что игрок в радиусе видимости и радиусе атаки
        _playerInSightRange = Physics.CheckSphere(transform.position, sightRange, isPlayer);
        _playerInAttackRange = Physics.CheckSphere(transform.position, attackRange, isPlayer);
        
        if (!_playerInSightRange && !_playerInAttackRange) Patroling();
        if ( _playerInSightRange && !_playerInAttackRange) ChasePlayer();
        if ( _playerInSightRange &&  _playerInAttackRange) AttackPlayer();
    }
    
    private void Patroling() {
        if (!_walkPointSet) SearchWalkPoint();
        
        if (_walkPointSet) 
            _agent.SetDestination(walkPoint);

        Vector2 distanseToWalkPoint = (Vector2)(transform.position - walkPoint);

        if (distanseToWalkPoint.magnitude < 1f)
            _walkPointSet = false;
    }
    
    private void SearchWalkPoint() {
        // Обсчёт рандомной точки в радиусе 
        float randomX = Random.Range(-walkPointRange, walkPointRange);
        float randomY = Random.Range(-walkPointRange, walkPointRange);

        walkPoint = new Vector2(transform.position.x + randomX, transform.position.y + randomY);

        if (Physics.Raycast(walkPoint, -transform.up, 2f)) 
            _walkPointSet = true;
    }
    
    private void ChasePlayer() {
        _agent.SetDestination(_player.transform.position);
    }

    private void AttackPlayer() {
        // Остановка преследования
        _agent.SetDestination(transform.position);
        transform.LookAt(_player.transform.position);
        
        if (!_alreadyAttacked) {
            _player.TakeDamage(damageZombie);
            _alreadyAttacked = true;
            Invoke(nameof(ResetAttack), timeBetweenAttacks);
        }
    }
    
    private void ResetAttack() {
        _alreadyAttacked = false;
    } */

    public void TakeDamage(int damage) {
        maxHealth -= damage;
        
        if (maxHealth <= 0) Destroy(gameObject);
    }
}