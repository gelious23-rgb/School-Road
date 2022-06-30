using System.Collections;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] private AudioSource _audioSource;    
    [SerializeField] private AudioSource Engine;
    [SerializeField] private AudioClip crash;
    [SerializeField] private Record _record;
    [SerializeField] public float forwardSpeed = 15f;
    [SerializeField] private UI _ui;
    public float _maxSpeed = 100f;
    public  static float _risingSpeed = 0.01f;

    void Update()
    {
        SpeedRising();
    }

 
    public void SpeedRising()
    {
        if (forwardSpeed < _maxSpeed)
        {
            forwardSpeed += (_risingSpeed * Time.deltaTime) * 65;
        }
    }
    
    private IEnumerator OnTriggerEnter(Collider col)
    {
        if (col.TryGetComponent(out cars cars))
        {
            if (_ui.immortality)
                yield break;
            
            _audioSource.clip = crash;
            _audioSource.loop = false;
            _audioSource.Play();
            Engine.Stop();
            if (_record.Value > PlayerPrefs.GetInt("_SCORE_"))
            {
                PlayerPrefs.SetInt("_SCORE_", _record.Value);
               
            }

            GameOver.gameOver = true;
        }
    }
    

}
