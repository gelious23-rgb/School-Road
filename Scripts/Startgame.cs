using System.Collections;
using UnityEngine;

public class Startgame : MonoBehaviour
{
	
	[SerializeField] private AudioClip _engineStart;
	[SerializeField] private AudioClip _engineSound;
	[SerializeField] private AudioSource _audioSource;
	[SerializeField] private Camera _mainCamera;
	[SerializeField] private Animation _cameraAnimation;
	[SerializeField] private AnimationClip _cameraAnimationClip;
	[SerializeField] private GameObject _bus;
	[SerializeField] private GameObject _menuPanel;
	[SerializeField] private GameObject _gamePanel;
	[SerializeField] private Record _record;
	
	void Start()
	{
		_cameraAnimation = GetComponent<Animation>();
		PlayerPrefs.SetInt("IS_Start", 0);
	}

	void Update()
	{
		RaycastHit[] hits;
		Ray myray = _mainCamera.ScreenPointToRay(Input.mousePosition);
		Debug.DrawRay(transform.position, myray.direction * 10);
		if (Input.GetKeyDown(KeyCode.Mouse0))
		{
			hits = Physics.RaycastAll(myray);
			foreach (RaycastHit hit in hits)
			{
				if (hit.transform.tag == "Bus")
				{
					if (PlayerPrefs.GetInt("IS_Start") == 0)
					{

						StartCoroutine(GameStart());
						StartCoroutine(AfterEngineSound());
						

					}
				}
			}
		}
	}

	[ContextMenu("Game Start!")]
	public void GameStartVoid()
	{
		StartCoroutine(GameStart());
	}

	IEnumerator GameStart()
	{
		yield return new WaitForSeconds(0.8f);

		StartCoroutine(_record.Distance());
		_cameraAnimation.Play(_cameraAnimationClip.name);
		_bus.GetComponent<PlayerController>().enabled = true;
		_menuPanel.SetActive(false);
		_gamePanel.SetActive(true);
		PlayerPrefs.SetInt("IS_Start", 1);
	}
	
	IEnumerator AfterEngineSound()
	{
		_audioSource.clip = _engineStart;
		_audioSource.Play();
		
		yield return new WaitForSeconds(_audioSource.clip.length);
		_audioSource.clip = _engineSound;
		_audioSource.loop = true;
		_audioSource.Play();
	}
}



		
			
	

