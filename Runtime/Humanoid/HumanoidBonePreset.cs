// SPDX-License-Identifier: Apache-2.0
// © 2024-2025 Depra <n.melnikov@depra.org>

using UnityEngine;

namespace Depra.Ragdoll
{
	[System.Serializable]
	public sealed class HumanoidBonePreset
	{
		[SerializeField] private HumanoidBoneType _type;
		[SerializeField] private BonePhysicsPreset _physics;
		[SerializeField] private CharacterJointPreset _attachment;

		public HumanoidBonePreset(HumanoidBoneType type)
		{
			_type = type;
			_physics = new BonePhysicsPreset();
			_attachment = new CharacterJointPreset();
		}

		public HumanoidBoneType Type => _type;

		public void Apply(RagdollBone bone)
		{
			if (!bone)
			{
				return;
			}

			if (bone.Rigidbody)
			{
				_physics.Apply(bone.Rigidbody);
			}

			if (bone.Collider)
			{
				_physics.Apply(bone.Collider);
			}

			if (bone.Joint && bone.Joint is CharacterJoint characterJoint)
			{
				_attachment.Apply(characterJoint);
			}
		}

		public void Capture(RagdollBone bone)
		{
			if (!bone)
			{
				return;
			}

			if (bone.Rigidbody)
			{
				_physics.Capture(bone.Rigidbody);
			}

			if (bone.Collider)
			{
				_physics.Capture(bone.Collider);
			}

			if (bone.Joint && bone.Joint is CharacterJoint characterJoint)
			{
				_attachment.Capture(characterJoint);
			}
		}
	}
}