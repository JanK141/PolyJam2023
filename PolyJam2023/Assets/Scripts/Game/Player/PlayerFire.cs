using UnityEngine;
using UnityEngine.InputSystem;

[RequireComponent(typeof(PlayerInput))]
[RequireComponent(typeof(PlayerCombo))]
public class PlayerFire : MonoBehaviour
{
	public double IntervalDelay
	{
		get
		{
			return intervalDelay;
		}
	}
	
	private double intervalDelay = 0.0;
	private PlayerCombo playerCombo;
	private Animator animator;
	private bool pressed = false;
	
	public bool IntervalDelayIsSufficientlySmall() => intervalDelay <= Constants.HIT_ERROR;

	public void OnFire(InputValue iv)
	{
		CheckPress();
	}

	private void Awake()
	{
		playerCombo = GetComponent<PlayerCombo>();
		animator = GetComponentInChildren<Animator>();
	}

	private void CheckPress()
	{
		if(!pressed)
		{
			pressed = true;
			animator.SetTrigger("Attack");

			if(IntervalDelayIsSufficientlySmall())
			{
				Debug.Log("Pressed in the right moment!");
				playerCombo.IncreaseComboBy(1);
			}
			else
			{
				Debug.Log("WRONG!");
				playerCombo.ResetCombo();
			}
		}
	}
	
	private void Update()
	{
		ControlIntervalDelay();
	}

	private void ControlIntervalDelay()
	{
		if(IntervalDelayReachedEnd())
		{
			intervalDelay = Constants.INTERVAL_DELAY;

			ResetPress();
		}
		else
		{
			intervalDelay -= Time.deltaTime;
		}
	}

	private bool IntervalDelayReachedEnd() => intervalDelay <= 0;

	private void ResetPress()
	{
		if(pressed)
		{
			pressed = false;
		}
	}
}