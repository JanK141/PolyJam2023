using UnityEngine;
using UnityEngine.UI;

public class TipsManager : MonoBehaviour
{
	public Image movementTipPanel, fireTipPanel, failureConditionTipPanel;

	private float timer = 0f;

	private void Start()
	{
		movementTipPanel.gameObject.SetActive(true);
		fireTipPanel.gameObject.SetActive(false);
		failureConditionTipPanel.gameObject.SetActive(false);
	}

	private void Update()
	{
		timer += Time.deltaTime;

		if(timer > 10f && movementTipPanel.gameObject.activeSelf)
		{
			movementTipPanel.gameObject.SetActive(false);
			fireTipPanel.gameObject.SetActive(true);
		}
		else if(timer > 25f && fireTipPanel.gameObject.activeSelf)
		{
			fireTipPanel.gameObject.SetActive(false);
			failureConditionTipPanel.gameObject.SetActive(true);
		}
		else if(timer > 35f && failureConditionTipPanel.gameObject.activeSelf)
		{
			failureConditionTipPanel.gameObject.SetActive(false);
		}
	}
}