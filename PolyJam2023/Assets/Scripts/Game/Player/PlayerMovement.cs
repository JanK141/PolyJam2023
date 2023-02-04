using UnityEngine;
using UnityEngine.InputSystem;
using static UnityEditor.Searcher.SearcherWindow.Alignment;

[RequireComponent(typeof(CharacterController))]
[RequireComponent(typeof(PlayerInput))]
public class PlayerMovement : MonoBehaviour
{
	[SerializeField] private float gravity = -20f;
	[SerializeField] private float movementSpeed = 10f;
	[SerializeField] private float jumpHeight = 5f;
	[SerializeField] private LayerMask ground;

	private CharacterController contr;
	private Animator animator;
	private bool isGrounded;
	private Vector2 currentInput;
	private Vector3 velocity;
	private InputAction action;

	private void Awake()
	{
		contr = GetComponent<CharacterController>();
		animator = GetComponentInChildren<Animator>();
		action = GetComponent<PlayerInput>().actions["Move"];
	}

	/*public void OnMove(InputValue iv)
	{
		Vector2 movementVector = iv.Get<Vector2>();
		Vector3 dir = new Vector3(
            movementVector.y * Mathf.Sqrt(1 - movementVector.x * movementVector.x * 0.5f),
			0,
            movementVector.x * Mathf.Sqrt(1 - movementVector.y * movementVector.y * 0.5f)
		);
        dir =
                Quaternion.AngleAxis(
                    Vector3.SignedAngle(Vector3.forward,
                        Vector3.ProjectOnPlane(transform.forward, Vector3.up),
                        Vector3.up), Vector3.up) * dir;
		velocity += dir * movementSpeed;
		print("ON Move");
	}*/

	public void OnJump(InputValue iv)
	{
		if (isGrounded) velocity.y = Mathf.Sqrt(jumpHeight * -2f * gravity);

    }

	private void FixedUpdate()
	{
		isGrounded = Physics.CheckSphere(transform.position, 0.4f, ground);
	}

	private void Update()
	{
		Vector2 moveInput = action.ReadValue<Vector2>();
		Vector2 smoothedInput = Vector2.zero;
		currentInput = Vector2.SmoothDamp(currentInput, moveInput * movementSpeed, ref smoothedInput, 0.5f);
		velocity = new Vector3(smoothedInput.x, velocity.y, smoothedInput.y);
        if (isGrounded && velocity.y < 0) velocity.y = -2f;
		else velocity.y += gravity * Time.deltaTime;
		contr.Move(velocity * Time.deltaTime);
        print("SPEED IS: " + Mathf.Sqrt(contr.velocity.x * contr.velocity.x + contr.velocity.z * contr.velocity.z));
        animator.SetFloat("VerticalVelocity", contr.velocity.y);
        animator.SetFloat("HorizontalVelocity", Mathf.Sqrt(contr.velocity.x * contr.velocity.x + contr.velocity.z * contr.velocity.z));
		animator.SetBool("IsGrounded", isGrounded);
	}

}