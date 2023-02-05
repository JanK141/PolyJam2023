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
		GameManager.instance.SoundtrackManager.SetMelodyVolume(1);
		combo += n;
		comboModulus += n;

		if(ReachedRequiredForRadialAttack())
		{
			GameManager.instance.SoundtrackManager.UpdateTrack(1);

			comboModulus = 0;
		}

		GameManager.instance.OnComboChange();
	}

	public void ResetCombo()
	{
		combo = comboModulus = 0;

		GameManager.instance.OnComboChange();
        GameManager.instance.SoundtrackManager.SetMelodyVolume(0);
        GameManager.instance.SoundtrackManager.UpdateTrack(-1);
    }

	private bool ReachedRequiredForRadialAttack() => comboModulus == Constants.RADIAL_ATTACK_REQUIRED_COMBO;
}