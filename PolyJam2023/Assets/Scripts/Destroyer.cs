using UnityEngine;

public class Destroyer : MonoBehaviour
{
	public float destroyDelay = 3f;

	private void Start()
	{
		Destroy(gameObject, destroyDelay);
	}
}