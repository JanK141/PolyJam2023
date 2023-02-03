using UnityEngine;

public class PlayerCombo : MonoBehaviour
{
	public int Combo
	{
		get
		{
			return combo;
		}
	}
	
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

		GameManager.instance.OnComboChange();
	}

	public void ResetCombo()
	{
		combo = comboModulus = 0;

		GameManager.instance.OnComboChange();
	}

	private bool ReachedRequiredForRadialAttack() => comboModulus == Constants.RADIAL_ATTACK_REQUIRED_COMBO;
}