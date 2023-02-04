using UnityEngine;
using UnityEngine.UI;

public class FadeScreen : MonoBehaviour
{
	public float fadeDuration = 2f;
	public bool isFadingOut = true;

	private Image image;
	private float fadeTimer = 0f;

	private void Awake()
	{
		image = GetComponent<Image>();

		fadeTimer = fadeDuration;
	}

	private void Update()
	{
		Fade();
	}

	private void Fade()
	{
		Debug.Log(fadeTimer);

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

		color.a = fadeFactor();
		image.color = color;
	}

	private float fadeFactor() => fadeTimer / fadeDuration;
}