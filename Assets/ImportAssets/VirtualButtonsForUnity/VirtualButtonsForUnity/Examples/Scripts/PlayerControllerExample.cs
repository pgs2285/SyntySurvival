using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerControllerExample : MonoBehaviour
{

    [SerializeField] private float playerSpeed = 2.0f;
    [SerializeField] private float jumpHeight = 1.0f;
    [SerializeField] private float gravityValue = -9.81f;

    protected CharacterController controller;
    protected PlayerActionsExample playerInput;
    private Vector3 playerVelocity;
    private Animator _animator;
    private bool groundedPlayer;
    private int HashMove = Animator.StringToHash("Move");
    private int HashJump = Animator.StringToHash("Jump");
    public float groundCheckDistance = 0.3f;
    public LayerMask groundLayer;
    bool isGround = false;
    private void Awake()
    {
        controller = GetComponent<CharacterController>();
        playerInput = new PlayerActionsExample();
        _animator = GetComponent<Animator>();
    }

    private void Update()
    {
        groundedPlayer = isCheckGround();
        if (groundedPlayer && playerVelocity.y < 0)
        {
            playerVelocity.y = 0f;
        }

        Vector2 movement = playerInput.Player.Move.ReadValue<Vector2>();
        Vector3 move = new Vector3(movement.x, 0, movement.y);
        controller.Move(move * Time.deltaTime * playerSpeed);

        if (move != Vector3.zero)
        {
            gameObject.transform.forward = move;
            _animator.SetBool(HashMove, true);

        }
        else
        {
            _animator.SetBool(HashMove, false);
        }

        
        bool jumpPress = playerInput.Player.Jump.triggered;
        if (jumpPress && groundedPlayer)
        {
            playerVelocity.y += Mathf.Sqrt(jumpHeight * -3.0f * gravityValue);
            _animator.SetTrigger(HashJump);
            
        }
        

        playerVelocity.y += gravityValue * Time.deltaTime;
        controller.Move(playerVelocity * Time.deltaTime);
    }

    private void OnEnable()
    {
        playerInput.Enable();
    }

    private void OnDisable()
    {
        playerInput.Disable();
    }

    public bool isCheckGround()
    {
        RaycastHit hit;
        #if UNITY_EDITOR
        Debug.DrawLine(transform.position + Vector3.up * 0.1f,  // 0.1f는 땅에서 캐릭터가 떨어져있는 거리
            transform.position + (Vector3.up * 0.1f) + (Vector3.down * groundCheckDistance),
            Color.red);
        #endif
        if (Physics.Raycast(transform.position + (Vector3.up * 0.1f),
                Vector3.down,
                out hit,
                groundCheckDistance,
                groundLayer)) isGround = true;
        else isGround = false;

        return isGround;
    }
    
}
