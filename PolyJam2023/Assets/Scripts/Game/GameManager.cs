using TMPro;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using Random = UnityEngine.Random;

public class GameManager : MonoBehaviour
{
	public static GameManager instance = null;

	public PlayerFire PlayerFire
	{
		get
		{
			return playerFire;
		}
	}
	public PlayerCombo PlayerCombo
	{
		get
		{
			return playerCombo;
		}
	}

	public SoundtrackManager SoundtrackManager
	{
		get
		{
			return soundtrackManager;
		}
	}

	public ComboCounter comboCounter;
	public FadeScreen fadeScreen;
	public Image gameOverPanel;
	public TextMeshProUGUI gameOverText;
	public Image gameplayPanel;

	private PlayerFire playerFire;
	private PlayerCombo playerCombo;
	private bool randomisedLeftHalf = false;
	private bool lostTheGame = false;
	private float endTimer = 0f;
	private int endSignal = 0;

	private SoundtrackManager soundtrackManager;

	public bool RandomisedLeftHalf() => randomisedLeftHalf;

	public void OnComboChange()
	{
		comboCounter.UpdateText();
	}

	public void OnNextCastInterval()
	{
		randomisedLeftHalf = Random.Range(0, 2) < 0.5f;

		if(GameObject.FindGameObjectsWithTag("Tree").Length == 0 && Time.timeSinceLevelLoad > 5f)
		{
			OnGameEnd();
		}
	}

	public void OnGameEnd()
	{
		if(lostTheGame)
		{
			return;
		}
		
		lostTheGame = true;
		endTimer = 5f;
		gameplayPanel.gameObject.SetActive(false);
		
		UpdateGameOverPanelAlpha();
		UpdateGameOverTextAlpha();
	}
	
	private void Awake()
	{
		CheckSingleton();
		AssignComponents();
	}

	private void CheckSingleton()
	{
		if(instance == null)
		{
			instance = this;
		}
		else if(instance != this)
		{
			Destroy(gameObject);
		}
	}

	private void Update()
	{
		if(lostTheGame)
		{
			if(endTimer > 0f)
			{
				endTimer -= Time.deltaTime;
			}
			else if(endSignal == 0)
			{
				++endSignal;
				endTimer = fadeScreen.fadeDuration;

				fadeScreen.InverseDirection();
			}
			else if(endSignal == 1)
			{
				++endSignal;

				SceneManager.LoadScene("MainMenu");
			}
		}
	}

	private void UpdateGameOverPanelAlpha()
	{
		Color color = gameOverPanel.color;

		color.a = 1;

		gameOverPanel.color = color;
	}

	private void UpdateGameOverTextAlpha()
	{
		Color color = gameOverText.color;

		color.a = 1;

		gameOverText.color = color;
	}

	private void AssignComponents()
	{
		GameObject player = GameObject.FindGameObjectWithTag("Player");
		
		playerFire = player.GetComponent<PlayerFire>();
		playerCombo = player.GetComponent<PlayerCombo>();
		soundtrackManager = FindObjectOfType<SoundtrackManager>();
	}
}