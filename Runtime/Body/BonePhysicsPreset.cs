// SPDX-License-Identifier: Apache-2.0
// © 2024-2025 Depra <n.melnikov@depra.org>

using UnityEngine;

namespace Depra.Ragdoll
{
	[System.Serializable]
	public class BonePhysicsPreset
	{
		[Min(0f)] [SerializeField] private float _mass = 3.125f;
		[Min(0f)] [SerializeField] private float _drag;
		[Min(0f)] [SerializeField] public float _angularDrag = 0.05f;
		[SerializeField] private CollisionDetectionMode _collisionDetection = CollisionDetectionMode.ContinuousDynamic;

		[SerializeField] private bool _useGravity = true;
		[SerializeField] private PhysicsMaterial _material;

		public void Apply(Rigidbody to)
		{
			to.mass = _mass;
			to.linearDamping = _drag;
			to.angularDamping = _angularDrag;
			to.useGravity = _useGravity;
			to.collisionDetectionMode = _collisionDetection;
		}

		public void Apply(Collider to) => to.material = _material;

		public void Capture(Rigidbody from)
		{
			_mass = from.mass;
			_drag = from.linearDamping;
			_angularDrag = from.angularDamping;
			_useGravity = from.useGravity;
			_collisionDetection = from.collisionDetectionMode;
		}

		public void Capture(Collider from) => _material = from.material;
	}
}