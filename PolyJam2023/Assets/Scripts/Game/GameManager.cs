using UnityEngine;

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

	private PlayerFire playerFire;
	private PlayerCombo playerCombo;
	private SoundtrackManager soundtrackManager;

	public void OnComboChange()
	{
		comboCounter.UpdateText();
	}

	public void OnGameEnd()
	{
		fadeScreen.InverseDirection();
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

	private void AssignComponents()
	{
		GameObject player = GameObject.FindGameObjectWithTag(Constants.PLAYER_TAG);
		
		playerFire = player.GetComponent<PlayerFire>();
		playerCombo = player.GetComponent<PlayerCombo>();
		soundtrackManager = FindObjectOfType<SoundtrackManager>();
	}
}