using System;
using Depra.Ragdoll.Body;
using UnityEngine;

namespace Depra.Ragdoll
{
	[DisallowMultipleComponent]
	internal sealed class RagdollTestController : MonoBehaviour
	{
		private const float CHARGE_SPEED = 100f;

		private static Action _onQuit;
		private static GameObject _prefab;

		public static void Initialize(GameObject prefab, Action onQuit)
		{
			_prefab = prefab;
			_onQuit = onQuit;
		}

		public static void Teardown()
		{
			_prefab = null;
			_onQuit = null;
		}

		private Camera _camera;
		private GameObject _dolly;

		private bool _isCharging;
		private float _chargeAmount;
		private Vector3 _pendingHitPoint;
		private Vector3 _pendingDirection;
		private Rigidbody _pendingRigidbody;
		private RagdollBody _pendingRagdollBody;
		private Vector3 _lastAppliedForce;

		private void Start()
		{
			_camera = Camera.main;
			SpawnDolly();
		}

		private void Update()
		{
			if (Input.GetKeyDown(KeyCode.R))
			{
				Reset();
				return;
			}

			if (Input.GetKeyDown(KeyCode.Escape) || Input.GetKeyDown(KeyCode.Q))
			{
				_onQuit?.Invoke();
				return;
			}

			if (Input.GetMouseButtonDown(0))
			{
				StartCharge();
			}

			if (Input.GetMouseButton(0) && _isCharging)
			{
				_chargeAmount += CHARGE_SPEED * Time.deltaTime * (1f + _chargeAmount * 0.01f);
			}

			if (Input.GetMouseButtonUp(0))
			{
				StopCharge();
			}
		}

		private void FixedUpdate()
		{
			if (!_pendingRigidbody || !_pendingRagdollBody)
			{
				return;
			}

			_pendingRagdollBody.Enable();
			_lastAppliedForce = _pendingDirection * _chargeAmount;
			_pendingRigidbody.AddForceAtPosition(_lastAppliedForce, _pendingHitPoint, ForceMode.Impulse);

			ResetCharge();
			_pendingRigidbody = null;
			_pendingRagdollBody = null;
		}

		private void Reset()
		{
			_isCharging = false;
			if (_dolly)
			{
				Destroy(_dolly);
			}

			SpawnDolly();
		}

		private void SpawnDolly()
		{
			if (!_prefab)
			{
				Debug.LogError("Prefab is null. Cannot spawn dolly.");
				return;
			}

			_dolly = Instantiate(_prefab);
			_dolly.transform.position = Vector3.zero;
			_dolly.transform.rotation = new Quaternion(0, 180, 0, 0);
			_dolly.name = _prefab.name + " Dolly";
		}

		private void StartCharge()
		{
			_isCharging = true;
			_chargeAmount = 0f;
		}

		private void StopCharge()
		{
			var ray = _camera.ScreenPointToRay(Input.mousePosition);
			if (!Physics.Raycast(ray, out var hit))
			{
				ResetCharge();
				return;
			}

			var attachedRigidbody = hit.collider.attachedRigidbody;
			if (!attachedRigidbody)
			{
				ResetCharge();
				return;
			}

			var ragdollBody = attachedRigidbody.GetComponentInParent<RagdollBody>();
			if (!ragdollBody)
			{
				ResetCharge();
				return;
			}

			_pendingRagdollBody = ragdollBody;
			_pendingRigidbody = attachedRigidbody;
			_pendingHitPoint = hit.point;
			_pendingDirection = ray.direction.normalized;
		}

		private void ResetCharge()
		{
			_isCharging = false;
			_chargeAmount = 0f;
		}

		private void OnGUI()
		{
			GUI.backgroundColor = Color.black;
			GUI.BeginGroup(new Rect(10, 10, 200, 200));
			if (GUI.Button(new Rect(0, 0, 200, 30), "Reset (R)"))
			{
				Reset();
			}

			if (GUI.Button(new Rect(0, 40, 200, 30), "Quit (Esc/Q)"))
			{
				_onQuit?.Invoke();
			}

			GUI.Label(new Rect(0, 80, 200, 30), $"Last Force: {_lastAppliedForce}", GUI.skin.button);
			GUI.Label(new Rect(0, 120, 200, 30), $"Charging: {_chargeAmount:F1}", GUI.skin.button);

			GUI.EndGroup();
		}
	}
}