using System;
using UnityEngine;

public class EnemyAI : MonoBehaviour{
    public event EventHandler<OnEnemyFireEventArgs> OnEnemyFire;
    public class OnEnemyFireEventArgs : EventArgs{
        public Transform gunFirePointPosition;
        public Vector3 shootPosition;
    }
    private enum State{
        ChaseTarget,
        Attack
    }
    [SerializeField] private Transform gunFirePointTransform;
    private float speed = 10f;
    private float nextShootTime;
    private State state;
    private void Start(){
        state = State.ChaseTarget;
    }
    private void Update(){
        float distanceToPlayer = Vector3.Distance(transform.position, PlayerController.Instance.GetPosition());
        switch (state)
        {
            case State.ChaseTarget:
                // Enemy chase target state
                float attackRange = 15f;
                if(distanceToPlayer < attackRange){
                    state = State.Attack;
                }
                break;
            case State.Attack:
                // enemy attack
                attackRange = 15f;
                if(distanceToPlayer > attackRange)
                    state = State.ChaseTarget;
                break;
        }
    }
    private void FixedUpdate()
    {
        switch (state)
        {
            case State.ChaseTarget:
                transform.position = Vector3.MoveTowards(transform.position, PlayerController.Instance.GetPosition(), speed * Time.deltaTime);
                break;
            
            case State.Attack:
                if(Time.time > nextShootTime){
                    OnEnemyFire?.Invoke(this, new OnEnemyFireEventArgs{
                        gunFirePointPosition = gunFirePointTransform,
                        shootPosition = PlayerController.Instance.GetPosition()
                    });
                    float fireRate = 1f;
                    nextShootTime = Time.time + fireRate;
                }
                break;
        }
    }
}
