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

		[SerializeField] private bool _useGravity = true;
		[SerializeField] private PhysicMaterial _material;

		public void Apply(Rigidbody to)
		{
			to.mass = _mass;
			to.drag = _drag;
			to.angularDrag = _angularDrag;
			to.useGravity = _useGravity;
		}

		public void Capture(Rigidbody from)
		{
			_mass = from.mass;
			_drag = from.drag;
			_angularDrag = from.angularDrag;
			_useGravity = from.useGravity;
		}
	}
}