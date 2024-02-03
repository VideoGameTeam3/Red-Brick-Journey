using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;


public class MoveJumpController : MonoBehaviour
{

    Rigidbody2D rb;
    [SerializeField] int jumppower;
    [SerializeField] public Transform GroundCheck;
    [SerializeField] public LayerMask GroundLayer;
    [SerializeField] public float FallMultiplier;
    [SerializeField] public float speed;
    [SerializeField] InputAction moveHorizontal = new InputAction(type: InputActionType.Button);
    [SerializeField] InputAction Jump = new InputAction(type: InputActionType.Button);
    Vector2 VecGracity;

    void OnEnable()
    {
        moveHorizontal.Enable();
        Jump.Enable();
    }

    void OnDisable()
    {
        moveHorizontal.Disable();
        Jump.Disable();
    }

    void FixedUpdate()
    {

        float horizontal = moveHorizontal.ReadValue<float>();
        rb.velocity = new Vector2(horizontal * speed,rb.velocity.y);
    }

    void Start()
    {
        VecGracity= new Vector2(0,-Physics2D.gravity.y);
        rb=GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        float Jumper = Jump.ReadValue<float>();
        if(Jumper > 0 && IsGrounded())
            rb.velocity = new Vector2(rb.velocity.x,jumppower);

        if(rb.velocity.y < 0)
        rb.velocity -= VecGracity * FallMultiplier * Time.deltaTime;
    }

    bool IsGrounded(){
        return Physics2D.OverlapCapsule(GroundCheck.position,new Vector2(1f,0.2f),CapsuleDirection2D.Horizontal,0,GroundLayer);
    }
}
