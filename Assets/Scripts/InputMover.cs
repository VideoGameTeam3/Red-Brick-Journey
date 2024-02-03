using System.Collections;
using UnityEngine;
using UnityEngine.InputSystem;

public class InputMover : MonoBehaviour
{
    [Tooltip("Speed of movement, in meters per second")]
    [SerializeField] float speed = 10f;

    [SerializeField] InputAction moveHorizontal = new InputAction(type: InputActionType.Button);

    void OnEnable()
    {
        moveHorizontal.Enable();
    }

    void OnDisable()
    {
        moveHorizontal.Disable();
    }

    void Update()
    {
            float horizontal = moveHorizontal.ReadValue<float>();
            Vector3 movementVector = new Vector3(horizontal, 0, 0) * speed * Time.deltaTime;
            transform.position += movementVector;    
    }
}
