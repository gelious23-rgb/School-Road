using System.Collections;
using System.Net.Mime;
using TMPro;
using UnityEditor;
using UnityEngine;
using UnityEngine.UI;


public class Record : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _hiscoreText;
    [SerializeField] private TextMeshProUGUI _scoreText;
    [SerializeField] private Image tropheyIcon;
    
    private static float _hiScoreCount; 
    public int Value;
    


    private void Start()
    {
        _hiScoreCount = PlayerPrefs.GetInt("_SCORE_");
        _hiscoreText.text = _hiScoreCount.ToString() + "m";
        
    }

    public IEnumerator Distance()
    {

        yield return new WaitForSeconds(0.25f);
        Value++;
        _scoreText.text = Value.ToString() + "m";
        if (Value > _hiScoreCount)
        {
            tropheyIcon.gameObject.SetActive(true);
        }

        StartCoroutine(Distance());
    }
}
