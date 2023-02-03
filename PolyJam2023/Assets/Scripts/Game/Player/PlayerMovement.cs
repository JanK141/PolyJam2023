using UnityEngine;
using UnityEngine.InputSystem;

[RequireComponent(typeof(Rigidbody))]
public class PlayerMovement : MonoBehaviour
{
	public float movementSpeed = 10f;

	private Rigidbody rb;
	private float movementX, movementY;

	private void Awake()
	{
		rb = GetComponent<Rigidbody>();
	}

	public void OnMove(InputValue iv)
	{
		Vector2 movementVector = iv.Get<Vector2>();

		movementX = movementVector.x;
		movementY = movementVector.y;
	}

	private void FixedUpdate()
	{
		Move();
	}

	private void Move()
	{
		Vector3 direction = new Vector3(movementX, 0, movementY);
		
		rb.AddForce(direction*movementSpeed);
	}
}