using UnityEngine;

[RequireComponent(typeof(ObjectReplacer))]
public class TreeEvolution : MonoBehaviour
{
	public GameObject[] models;
	public GameObject evolutionEmitter;

	private GameObject currentModel;
	private ObjectScaler scaler;
	private ObjectReplacer replacer;
	
	private int currentModelIndex = 0;
	private bool evolved = false;

	private void Awake()
	{
		replacer = GetComponent<ObjectReplacer>();
	}

	private void Start()
	{
		SpawnNextModel();
	}

	private void Update()
	{
		if(scaler.HasReachedTargetScale() && !evolved)
		{
			Evolve();
		}
	}

	private void Evolve()
	{
		evolved = true;

		Instantiate(evolutionEmitter, transform.position, Quaternion.identity);
		SpawnNextModel();
	}

	private void SpawnNextModel()
	{
		if(NotReachedMaximumLevel())
		{
			GameObject nextModel = models[currentModelIndex++];
			GameObject instance = replacer.InstantiateModel(nextModel);

			DestroyCurrentModel();

			scaler = instance.GetComponent<ObjectScaler>();
			evolved = false;
			currentModel = instance;
		}
	}

	private bool NotReachedMaximumLevel() => currentModelIndex < models.Length;

	private void DestroyCurrentModel()
	{
		if(currentModel != null)
		{
			Destroy(currentModel);
		}
	}
}