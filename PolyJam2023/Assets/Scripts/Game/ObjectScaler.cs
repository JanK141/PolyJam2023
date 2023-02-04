using UnityEngine;

public class ObjectScaler : MonoBehaviour
{
	public float initialScale = 0.01f;
	public float targetScale = 1f;
	public float scaleDuration = 60f;

	private float growDuration = 0.0f;

	private void Start()
	{
		SetScale(initialScale);
	}

	private void Update()
	{
		IncreaseScale();
	}

	private void IncreaseScale()
	{
		if(HasNotGrownUpYet())
		{
			growDuration += Time.deltaTime;

			SetScale(ScaleFactor());
		}
	}

	private bool HasNotGrownUpYet() => transform.localScale.x < targetScale && transform.localScale.y < targetScale && transform.localScale.z < targetScale;
	private void SetScale(float factor) => transform.localScale = Vector3.one*factor;
	private float ScaleFactor() => (growDuration > 0.0f) ? (growDuration / scaleDuration)*targetScale : initialScale;
}