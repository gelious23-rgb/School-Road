using System.Collections;
using DG.Tweening;
using UnityEngine;
public class Immortality : MonoBehaviour
{
    [SerializeField] private Material _busMat;
    [SerializeField]private Collider _col;


    public float activationTime;
    public bool immortality;


    // ReSharper disable Unity.PerformanceAnalysis
    public IEnumerator Flashing(  )
    {
        activationTime = 0;
        immortality = true;
        _busMat.DOColor(Color.black, 0.9f).OnComplete(() =>
        {   
            _busMat.DOColor(Color.white, 0.9f);
        }).SetLoops(-1).SetEase(Ease.Linear);
        yield return new WaitForSeconds(1f);
    }

    public void Start()
    {   
        _col.isTrigger = true;
        activationTime = 0;
        immortality = false;
    }

    public void Update()
    {
        
        activationTime += Time.deltaTime;
        if (immortality & activationTime >= 3)
        {
            immortality = false;
            

        }
    }
    

}
