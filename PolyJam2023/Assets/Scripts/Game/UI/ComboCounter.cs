using TMPro;
using UnityEngine;

public class ComboCounter : MonoBehaviour
{
	private TextMeshProUGUI text;

	public void UpdateText()
	{
		text.text = string.Format("{0}: {1}", Constants.COMBO_COUNTER_TEXT, GameManager.instance.PlayerCombo.Combo);
	}

	private void Awake()
	{
		text = GetComponent<TextMeshProUGUI>();
	}

	private void Start()
	{
		UpdateText();
	}
}