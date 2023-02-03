using UnityEngine;
using UnityEngine.InputSystem;

[RequireComponent(typeof(PlayerInput))]
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
	
	public void OnFire(InputValue iv)
	{
		if(IntervalDelayIsSufficientlySmall())
		{
			Debug.Log("Pressed in the right moment!");
		}
		else
		{
			Debug.Log("WRONG!");
		}	
	}

	public bool IntervalDelayIsSufficientlySmall() => intervalDelay <= Constants.HIT_ERROR;

	private void Update()
	{
		ControlIntervalDelay();
	}

	private void ControlIntervalDelay()
	{
		if(intervalDelay <= 0)
		{
			intervalDelay = Constants.INTERVAL_DELAY;
		}
		else
		{
			intervalDelay -= Time.deltaTime;
		}
	}
}