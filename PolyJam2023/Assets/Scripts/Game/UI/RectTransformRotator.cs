using UnityEngine;

public class RectTransformRotator : MonoBehaviour
{
	public float rotationSpeed = 10f;
	
	private RectTransform rectTransform;

	private void Awake()
	{
		rectTransform = GetComponent<RectTransform>();
	}

	private void Update()
	{
		rectTransform.Rotate(Vector3.forward*rotationSpeed);
	}
}