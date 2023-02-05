using UnityEngine;

public class GameMusic : MonoBehaviour
{
	//public MusicFader loop1, comboRising, melody1, comboMaxIntensity;
	public AudioSource loop1, comboRising, melody1, comboMaxIntensity;

	public void StartMusic()
	{
		AdjustMusic();
	}

	private void Start()
	{
		//loop1.SwitchFadeDirection();
		//melody1.SwitchFadeDirection();
	}

	private void Update()
	{
		ControlTimer();
	}

	private void ControlTimer()
	{
		if(GameManager.instance.PlayerFire.IntervalReachedEnd())
		{
			AdjustMusic();
		}
	}

	private void AdjustMusic()
	{
		int combo = GameManager.instance.PlayerCombo.Combo;

		if(combo == 0)
		{
			if(!loop1.isPlaying)
			{
				loop1.PlayScheduled(AudioSettings.dspTime);
			}
			
			melody1.PlayScheduled(AudioSettings.dspTime);
			StopMusicIfIsPlaying(comboRising);
			StopMusicIfIsPlaying(comboMaxIntensity);
		}
		else if(combo == Constants.COMBO_RISING_REQUIRED_COMBO)
		{
			comboRising.PlayScheduled(AudioSettings.dspTime);
			StopMusicIfIsPlaying(loop1);
		}
		else if(combo > Constants.COMBO_RISING_REQUIRED_COMBO && !comboRising.isPlaying)
		{
			StopMusicIfIsPlaying(comboRising);
			comboMaxIntensity.PlayScheduled(AudioSettings.dspTime);
			StopMusicIfIsPlaying(melody1);
		}
	}

	private void StopMusicIfIsPlaying(AudioSource _as)
	{
		if(_as.isPlaying)
		{
			_as.Stop();
		}
	}
}