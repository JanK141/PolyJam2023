using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MainMenuManager : MonoBehaviour
{
	public Image mainMenuPanel, creditsPanel;
	
	public void OnStartGameClick()
	{
		SceneManager.LoadScene("LevelTest");
	}

	public void OnCreditsClick()
	{
		mainMenuPanel.gameObject.SetActive(false);
		creditsPanel.gameObject.SetActive(true);
	}

	public void OnBackToMainMenuClick()
	{
		mainMenuPanel.gameObject.SetActive(true);
		creditsPanel.gameObject.SetActive(false);
	}

	public void OnQuitClick()
	{
		Application.Quit();
	}

	private void Start()
	{
		OnBackToMainMenuClick();
	}
}