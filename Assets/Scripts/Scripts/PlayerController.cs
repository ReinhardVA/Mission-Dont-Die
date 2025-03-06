using UnityEngine;

public class PlayerController : MonoBehaviour{
    public static PlayerController Instance {get; private set;}
    private float moveSpeed = 10.0f;
    private enum State{
        Normal,
        Dashing,
    }
    [SerializeField] private Rigidbody2D rb2D;
    private Vector3 moveDir;
    private Vector3 dashDir;
    private float dashSpeed;
    private State state;

    private void Awake()
    {
        Instance = this;
        state = State.Normal;
    }
    private void Update(){
        switch (state)
        {
            case State.Normal:
                float moveX = 0f;
                float moveY = 0f;
                if(Input.GetKey(KeyCode.W)){
                    moveY = 1f;
                }
                if(Input.GetKey(KeyCode.S)){
                    moveY = -1f;
                }
                if(Input.GetKey(KeyCode.A)){
                    moveX = -1f;
                }
                if(Input.GetKey(KeyCode.D)){
                    moveX = +1f;
                }
                if(Input.GetKeyDown(KeyCode.Space)){
                    dashDir = moveDir;
                    dashSpeed = 100f;
                    state = State.Dashing;
                }
                moveDir = new Vector3(moveX, moveY).normalized;
                break;
            
            case State.Dashing:
                float dashSpeedDropMultiplier = 5f;
                dashSpeed -= dashSpeed * dashSpeedDropMultiplier * Time.deltaTime;

                float dashSpeedMinimum = 50f;
                    if(dashSpeed < dashSpeedMinimum){
                        state = State.Normal;
                    }
                break;
        }
    }

    private void FixedUpdate(){
        switch (state)
        {
            case State.Normal:
                rb2D.linearVelocity = moveDir * moveSpeed; 
                break;
            case State.Dashing:
                rb2D.linearVelocity = dashDir * dashSpeed;
                break;
        }
    }
    public void SetMoveSpeed(float newMoveSpeed){
        moveSpeed = newMoveSpeed;
    }
    public Vector3 GetPosition(){
        return transform.position;
    }
}
