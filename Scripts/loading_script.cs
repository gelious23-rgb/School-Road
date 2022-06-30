using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

public class loading_script : MonoBehaviour {
	[SerializeField] private TextMeshProUGUI _prompt;
	[SerializeField] private string _promptText;
	[SerializeField] private string scene;
	[SerializeField] private int _random;
	[SerializeField] private Sprite[] _downloadImages;
	void Start () {
		Time.timeScale = 1;
		StartCoroutine (AsyncLoad());
		_random = Random.Range (1, 4);
		if (_random == 1) {
			_promptText = "School buses have no seat belts.";
		}
		if (_random == 2) {
			_promptText = "School buses are 70% safer than other vehicles.";
		}
		if (_random == 3) {
			_promptText = "School buses aren’t just “yellow”.";
		}
		if (_random == 4) {
			_promptText = "Air disc brakes have made a big difference for school bus safety.";
		}
Debug.Log(_promptText);
		_prompt.GetComponent<TextMeshProUGUI>().text = _promptText;
		_random = Random.Range (1, _downloadImages.Length);
		GetComponent<Image>().sprite = _downloadImages[_random - 1];
		

	}
	IEnumerator AsyncLoad()
	{
		SceneManager.LoadSceneAsync(scene);
		yield return null;
	}
}

