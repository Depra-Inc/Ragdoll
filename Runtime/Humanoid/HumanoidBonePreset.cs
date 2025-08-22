// SPDX-License-Identifier: Apache-2.0
// © 2024-2025 Depra <n.melnikov@depra.org>

using Depra.Ragdoll.Parts;
using UnityEngine;

namespace Depra.Ragdoll.Armature
{
	[System.Serializable]
	public sealed class HumanoidBonePreset
	{
		[field: SerializeField] public HumanoidBoneType Type { get; set; }
		[field: SerializeField] public BonePhysicsPreset Physics { get; private set; }
		[field: SerializeField] public BoneAttachmentPreset Attachment { get; private set; }

		public HumanoidBonePreset(HumanoidBoneType type)
		{
			Type = type;
			Physics = new BonePhysicsPreset();
			Attachment = new BoneAttachmentPreset();
		}

		public void Apply(RagdollBone bone)
		{
			if (!bone)
			{
				return;
			}

			if (bone.Rigidbody)
			{
				Physics.Apply(bone.Rigidbody);
			}

			if (bone.Joint)
			{
				Attachment.Apply(bone.Joint);
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
				Physics.Capture(bone.Rigidbody);
			}

			if (bone.Joint)
			{
				Attachment.Capture(bone.Joint);
			}
		}
	}
}