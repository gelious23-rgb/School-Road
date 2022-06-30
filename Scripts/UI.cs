using DG.Tweening;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class UI : MonoBehaviour
{
    public AudioMixer volume;
    
    [SerializeField] private Button _volumeButton;
    [SerializeField] private Sprite _volumeON;
    [SerializeField] private Sprite _volumeOFF;
    [SerializeField] private Material _busMat;
   

    public float activationTime;
    public bool immortality;
   

   private bool isActive = true;

   public void Start()
   {
       activationTime = 0;
       immortality = false;
       volume.SetFloat("volume", 1f);
   }

   public void Update()
   {
       activationTime += Time.deltaTime;
       
       if (immortality && activationTime >= 3)
       {
           immortality = false;
           _busMat.color = Color.white;
       }
   }

   public void ButtonVolume()
    {
        Debug.Log("gdfddfdhdhdhdghd");

        if (isActive)
        {
            _volumeButton.GetComponent<Image>().sprite = _volumeOFF;
            volume.SetFloat("volume", 0f);
           
        }
        else
        {
            _volumeButton.GetComponent<Image>().sprite = _volumeON;
           
            volume.SetFloat("volume", 1f);
        }
        isActive = !isActive;
    }

   public void Cor( bool immortal, float activation)
   {
       
       for (int i = 3; i >= 0; i--) 
       {
           if (i == 0)
           {
               activationTime = activation;
               immortality = immortal;
            

               //col.GetComponent<Collider>().enabled = false;
               _busMat.DOColor(Color.black, 0.9f).OnComplete(() =>
               {   
                   _busMat.DOColor(Color.white, 0.9f);
               }).SetLoops(3).SetEase(Ease.Linear);
        
               Debug.Log("sfkgjhfdks");

           }
       }
   }

   public void ButtonPause()
    {
        Time.timeScale = 0;
    }
    public void ButtonReturn()
    {
        Time.timeScale = 1;
    }
    public void ButtonExit()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene(0);
    }

    public void Aid()
    {
        GameOver.gameOver = false;
        Time.timeScale = 1;
        Cor(true, 0);
        


    }

}