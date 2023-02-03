using UnityEngine;

public class PlayerCombo : MonoBehaviour
{
	private int combo = 0;
	private int comboModulus = 0;

	public void IncreaseComboBy(int n)
	{
		combo += n;
		comboModulus += n;

		if(ReachedRequiredForRadialAttack())
		{
			Debug.Log("RADIAL ATTACK!");

			comboModulus = 0;
		}

		Debug.Log("Combo: " + combo);
	}

	public void ResetCombo()
	{
		combo = comboModulus = 0;
	}

	private bool ReachedRequiredForRadialAttack() => comboModulus == Constants.RADIAL_ATTACK_REQUIRED_COMBO;
}