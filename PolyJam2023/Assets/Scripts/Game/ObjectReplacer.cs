using UnityEngine;

public class ObjectReplacer : MonoBehaviour
{
	private GameObject currentModel;

	public GameObject InstantiateModel(GameObject model)
	{
		currentModel = ModelInstance(model);

		SetParentToModel(currentModel);
		ChangeModel(model);

		return currentModel;
	}

	private void ChangeModel(GameObject model)
	{
		GameObject go = ModelInstance(model);

		Destroy(currentModel);
		SetParentToModel(go);
		SetCurrentModel(go);
	}

	private GameObject ModelInstance(GameObject model) => Instantiate(model, transform.position, transform.rotation);
	private void SetParentToModel(GameObject model) => model.transform.parent = transform;
	private void SetCurrentModel(GameObject model) => currentModel = model;
}