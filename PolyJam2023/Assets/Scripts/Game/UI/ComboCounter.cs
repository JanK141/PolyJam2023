using TMPro;
using UnityEngine;

public class ComboCounter : MonoBehaviour
{
	public float increasedFontSize = 64f;
	public float fontSizeDecreaseSpeed = 10f;

	private TextMeshProUGUI text;
	private float initialFontSize;

	public void UpdateText()
	{
		int combo = GameManager.instance.PlayerCombo.Combo;
		
		text.text = combo > 0 ? string.Format("x{0}", combo) : string.Empty;
		text.fontSizeMin = text.fontSize;
		text.fontSize = text.fontSizeMax = increasedFontSize;
	}

	private void Awake()
	{
		text = GetComponent<TextMeshProUGUI>();
		initialFontSize = text.fontSize;
	}

	private void Start()
	{
		UpdateText();
	}

	private void Update()
	{
		if(text.fontSize > initialFontSize)
		{
			text.fontSize -= Time.deltaTime*fontSizeDecreaseSpeed;
		}
	}
}