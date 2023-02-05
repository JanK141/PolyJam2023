using UnityEngine;
using UnityEngine.UI;

public class FadeScreen : MonoBehaviour
{
	public float fadeDuration = 2f;

	private RawImage image;
	private float fadeTimer = 0f;
	private bool isFadingOut = true;

	public void InverseDirection()
	{
		isFadingOut = !isFadingOut;
	}

	private void Awake()
	{
		image = GetComponent<RawImage>();

		fadeTimer = fadeDuration;
	}

	private void Update()
	{
		Fade();
	}

	private void Fade()
	{
		UpdateTimer();
		UpdateAlpha();
	}

	private void UpdateTimer()
	{
		if(isFadingOut && fadeTimer > 0f)
		{
			fadeTimer -= Time.deltaTime;
		}
		else if(!isFadingOut && fadeTimer < fadeDuration)
		{
			fadeTimer += Time.deltaTime;
		}
	}

	private void UpdateAlpha()
	{
		Color color = image.color;

		color.a = FadeFactor();
		image.color = color;
	}

	private float FadeFactor() => fadeTimer / fadeDuration;
}