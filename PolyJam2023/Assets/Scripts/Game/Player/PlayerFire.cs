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

	private void Awake()
	{
		playerCombo = GetComponent<PlayerCombo>();
	}

	public void OnFire(InputValue iv)
	{
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