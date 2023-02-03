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

	private PlayerFire playerFire;
	
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
	}
}