// SPDX-License-Identifier: Apache-2.0
// © 2024-2025 Depra <n.melnikov@depra.org>

using Depra.Creature.Runtime.Ragdoll.Joints;
using UnityEngine;

namespace Depra.Ragdoll
{
	[System.Serializable]
	public class BoneAttachmentPreset
	{
		[field: SerializeField] public JointLimitPreset LowTwist { get; internal set; } = new(-20f, 0f, 0f);
		[field: SerializeField] public JointLimitPreset HighTwist { get; internal set; } = new(70f, 0f, 0f);
		[field: SerializeField] public JointLimitPreset Swing1 { get; internal set; } = new(30f, 0f, 0f);
		[field: SerializeField] public JointLimitPreset Swing2 { get; internal set; } = new(0f, 0f, 0f);

		public void Apply(Joint joint)
		{
			if (joint is CharacterJoint characterJoint)
			{
				Apply(characterJoint);
			}
		}

		public void Apply(CharacterJoint to)
		{
			to.lowTwistLimit = LowTwist;
			to.highTwistLimit = HighTwist;
			to.swing1Limit = Swing1;
			to.swing2Limit = Swing2;
		}

		public void Capture(Joint joint)
		{
			if (joint is CharacterJoint characterJoint)
			{
				Capture(characterJoint);
			}
		}

		public void Capture(CharacterJoint from)
		{
			LowTwist = from.lowTwistLimit;
			HighTwist = from.highTwistLimit;
			Swing1 = from.swing1Limit;
			Swing2 = from.swing2Limit;
		}
	}
}