// SPDX-License-Identifier: Apache-2.0
// © 2024-2025 Depra <n.melnikov@depra.org>

using UnityEngine;

namespace Depra.Ragdoll
{
	[System.Serializable]
	public class BonePhysicsPreset
	{
		[field: Min(0f), SerializeField] public float Mass { get; internal set; } = 3.125f;
		[field: Min(0f), SerializeField] public float Drag { get; internal set; }
		[field: Min(0f), SerializeField] public float AngularDrag { get; internal set; } = 0.05f;

		[field: SerializeField] public bool UseGravity { get; internal set; } = true;
		[field: SerializeField] public PhysicMaterial Material { get; internal set; }

		public void Apply(Rigidbody to)
		{
			to.mass = Mass;
			to.drag = Drag;
			to.angularDrag = AngularDrag;
			to.useGravity = UseGravity;
		}

		public void Capture(Rigidbody from)
		{
			Mass = from.mass;
			Drag = from.drag;
			AngularDrag = from.angularDrag;
			UseGravity = from.useGravity;
		}
	}
}