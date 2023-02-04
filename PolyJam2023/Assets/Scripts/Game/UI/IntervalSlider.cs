using UnityEngine;
using UnityEngine.UI;

public class IntervalSlider : MonoBehaviour
{
	public Image bgImage;

	private Slider slider;
	private PlayerFire playerFire;

	private void Awake()
	{
		slider = GetComponent<Slider>();
		slider.maxValue = Constants.INTERVAL_DELAY;
	}

	private void Start()
	{
		playerFire = GameManager.instance.PlayerFire;
	}

	private void Update()
	{
		slider.value = (float)playerFire.IntervalDelay;

		SetBackgroundColor();
	}

	private void SetBackgroundColor()
	{
		Color color = playerFire.IntervalDelayIsSufficientlySmall() ? Constants.INTERVAL_SLIDER_BACKGROUND_SIGNAL_COLOR : Constants.INTERVAL_SLIDER_BACKGROUND_NORMAL_COLOR;

		bgImage.color = color;
	}
}