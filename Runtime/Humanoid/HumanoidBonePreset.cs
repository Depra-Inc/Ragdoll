// SPDX-License-Identifier: Apache-2.0
// © 2024-2025 Depra <n.melnikov@depra.org>

using Depra.Ragdoll.Parts;
using UnityEngine;

namespace Depra.Ragdoll.Armature
{
	[System.Serializable]
	public sealed class HumanoidBonePreset
	{
		[SerializeField] private HumanoidBoneType _type;
		[SerializeField] private BonePhysicsPreset _physics;
		[SerializeField] private BoneAttachmentPreset _attachment;

		public HumanoidBonePreset(HumanoidBoneType type)
		{
			_type = type;
			_physics = new BonePhysicsPreset();
			_attachment = new BoneAttachmentPreset();
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

			if (bone.Joint)
			{
				_attachment.Apply(bone.Joint);
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

			if (bone.Joint)
			{
				_attachment.Capture(bone.Joint);
			}
		}
	}
}