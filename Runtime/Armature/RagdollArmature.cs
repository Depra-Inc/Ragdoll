﻿using System.Collections.Generic;
using Depra.Ragdoll.Bones;
using UnityEngine;

namespace Depra.Ragdoll.Armature
{
	public class RagdollArmature
	{
		public RagdollArmature(IEnumerable<RagdollBone> bones) => Bones = bones;

		public IEnumerable<RagdollBone> Bones { get; }

		/// <summary>
		/// Calculate center of mass of all the bones.
		/// </summary>
		public Vector3 CenterOfMass()
		{
			var centerOfMass = Vector3.zero;
			var sum = 0f;

			foreach (var bone in Bones)
			{
				var mass = bone.Rigidbody.mass;
				centerOfMass += bone.Position * mass;
				sum += mass;
			}

			centerOfMass /= sum;
			return centerOfMass;
		}
	}
}