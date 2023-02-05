using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Grow : MonoBehaviour, IDamagable
{
    [SerializeField] float HP;
    [SerializeField] float damagePerHit;
    [SerializeField] IntVariable BPM;
    [SerializeField] float InitScale = 0.1f;
    [SerializeField] float ScalePerBit = 0.5f;
    [SerializeField] float TargetScale = 5f;
    [SerializeField] GameObject NextStage;

    private bool grow = true;
    private float _time = 0f;
    private float _currentScale;

    public float Health { get; set; }

    public void ReceiveHit()
    {
        Health -= damagePerHit;
        transform.DOShakePosition(0.2f);

        if(Health < 0)
        {
            Destroy(gameObject);
        }
    }

    private void Start()
    {
        Health = HP;
        _currentScale = InitScale;
        transform.localScale = new Vector3(_currentScale, _currentScale, _currentScale);
    }

    void Update()
    {
        _time+=Time.deltaTime;
        if(_time >= 60f / BPM.Value && grow)
        {
            _currentScale += ScalePerBit;
            transform.DOScale(_currentScale, 120f/BPM.Value).SetEase(Ease.InBounce);
            _time -= 60f / BPM.Value;
            if (_currentScale >= TargetScale) LevelUp();
        }
    }

    private void LevelUp()
    {
        if (NextStage != null)
        {
            var tmp = Instantiate(NextStage);
            tmp.transform.SetPositionAndRotation(transform.position, transform.rotation);
            Destroy(this.gameObject);
        }
        else
        {
            grow = false;
        }
    }

    public void ReceiveBoost()
    {
        transform.DOScale(_currentScale+2*ScalePerBit, 240 / BPM.Value).SetEase(Ease.InBounce);
    }
}
