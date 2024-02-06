// SPDX-License-Identifier: Apache-2.0
// © 2024 Nikolay Melnikov <n.melnikov@depra.org>

using System.Collections.Generic;
using Depra.Ragdoll.Bones;
using Depra.Ragdoll.Parts;
using UnityEngine;

namespace Depra.Ragdoll.Armature
{
	public abstract class RagdollArmature : RagdollPart
	{
		public abstract IEnumerable<RagdollBone> GatherBones();

		public override void Enable()
		{
			var bones = GatherBones();
			foreach (var bone in bones)
			{
				bone.Enable();
			}
		}

		public override void Disable()
		{
			var bones = GatherBones();
			foreach (var bone in bones)
			{
				bone.Disable();
			}
		}

		/// <summary>
		/// Calculate center of mass of all the bones.
		/// </summary>
		public Vector3 CenterOfMass()
		{
			var centerOfMass = Vector3.zero;
			var sum = 0f;

			var bones = GatherBones();
			foreach (var bone in bones)
			{
				var mass = bone.Rigidbody.mass;
				centerOfMass += bone.transform.position * mass;
				sum += mass;
			}

			centerOfMass /= sum;
			return centerOfMass;
		}
	}
}