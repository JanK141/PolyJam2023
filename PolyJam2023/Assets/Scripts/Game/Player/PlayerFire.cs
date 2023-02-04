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
	private bool started = false;
	private bool pressed = false;
	
	public bool IntervalDelayIsSufficientlySmall() => intervalDelay <= Constants.HIT_ERROR;
	public bool IntervalDelayReachedEnd() => intervalDelay <= 0;

	public void OnFire(InputValue iv)
	{
		CheckPress();
	}

	private void Awake()
	{
		playerCombo = GetComponent<PlayerCombo>();
	}

	private void CheckPress()
	{
		if(!started)
		{
			started = true;
		}
		else if(!pressed)
		{
			pressed = true;

			if(IntervalDelayIsSufficientlySmall())
			{
				playerCombo.IncreaseComboBy(1);
			}
			else
			{
				playerCombo.ResetCombo();
			}
		}
	}
	
	private void Update()
	{
		if(started)
		{
			ControlIntervalDelay();
		}
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
	
	private void ResetPress()
	{
		if(pressed)
		{
			pressed = false;
		}
	}
}