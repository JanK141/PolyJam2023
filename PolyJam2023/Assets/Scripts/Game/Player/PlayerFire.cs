using UnityEngine;
using UnityEngine.InputSystem;

[RequireComponent(typeof(PlayerInput))]
[RequireComponent(typeof(PlayerCombo))]
public class PlayerFire : MonoBehaviour
{
	[SerializeField] private IntVariable BPM;
	[SerializeField] private float errorAllowance = 0.25f;
	[SerializeField] private ParticleSystem Projectile;

	private float Interval => 60f / BPM.Value;

	public float Progression => 1 - (_time/Interval);

	private float _time = 0f;
	private PlayerCombo playerCombo;
	private Animator animator;
	private Camera cam;

	private void Awake()
	{
		playerCombo = GetComponent<PlayerCombo>();
		animator = GetComponentInChildren<Animator>();
		cam = Camera.main;
	}

	private void Update()
	{
		_time += Time.deltaTime;
		if (_time >= Interval + errorAllowance)
		{
			_time -= Interval;
			playerCombo.ResetCombo();
		}
	}


	public void OnFire(InputValue iv)
	{
		animator.SetTrigger("Attack");
		if(_time >= Interval - errorAllowance && _time <= Interval + errorAllowance)
		{
            _time -= Interval;
			playerCombo.IncreaseComboBy(1);
            RaycastHit info;
            Vector3 target = Vector3.zero;
            if (Physics.Raycast(cam.transform.position, cam.transform.forward, out info, 100f))
            {
                target = info.point;
				if (info.transform.TryGetComponent<Grow>(out var grow))
				{
					grow.ReceiveBoost();
				}
            }
            else
            {
                target = cam.transform.position + (100 * cam.transform.forward);
            }
            transform.LookAt(new Vector3(target.x, transform.position.y, target.z));
            Projectile.transform.LookAt(target);
			Projectile.Emit(1);
        }
		else
		{
            _time -= Interval;
			_time = _time%Interval;
			playerCombo.ResetCombo();
        }
	}

	public bool IntervalReachedEnd() => Interval <= 0;







}