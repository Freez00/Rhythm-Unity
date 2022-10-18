using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TarodevController;

public class DashController : MonoBehaviour
{
    // Start is called before the first frame update
    [Header("                   " +
        "                   " +
        "Controller\n")]
    [SerializeField] private PlayerController _controller;
    [Header("\n                   " +
        "                   " +
		"Dash Stuff\n")]
    [SerializeField] public float _dashingVelocity = 14f;
    [SerializeField] public float _dashingTime = 0.5f;
    [SerializeField] public Vector2 _dashingDir;
    [SerializeField] public bool _isDashing;
    [SerializeField] public bool _canDash = true;
    [SerializeField] public Rigidbody2D _rigidbody2d;

    [Header("\n                   " +
        "                   " +
		"Trail Renderer\n")]
    [SerializeField] public TrailRenderer _trailRenderer;

    void Start()
    {
        _trailRenderer = GetComponent<TrailRenderer>();
        _rigidbody2d = GetComponent<Rigidbody2D>();
        _controller = GetComponent<PlayerController>();
    }

    // Update is called once per frame
    void Update()
    {

		if (Input.GetButtonDown("Fire3") && _canDash)
		{
            _isDashing = true;
            _controller.SetDash(true);
            _canDash = false;
            _trailRenderer.emitting = true;
            _dashingDir = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));
            if (_dashingDir == Vector2.zero)
			{
                _dashingDir = new Vector2(transform.localScale.x, 0);
			}
            StartCoroutine(StopDashing());
        }
		if (_isDashing)
		{
            _rigidbody2d.velocity = _dashingDir.normalized * _dashingVelocity;
            return;
		}
		else
		{
            _rigidbody2d.velocity = Vector2.zero;
		}
		if (_controller.Grounded)
		{
            _canDash = true;
		}
    }
    public void SetDash(bool _canDash)
	{
        this._canDash = _canDash;
	}
    private IEnumerator StopDashing()
	{
        yield return new WaitForSeconds(_dashingTime);
        _isDashing = false;
        _controller.SetDash(false);
        _controller._currentVerticalSpeed = 0;
        _trailRenderer.emitting = false;
    }
}
