// SPDX-License-Identifier: Apache-2.0
// © 2024-2025 Depra <n.melnikov@depra.org>

using Depra.Creature.Runtime.Ragdoll.Joints;
using UnityEngine;

namespace Depra.Ragdoll
{
	[System.Serializable]
	public sealed class CharacterJointPreset
	{
		[SerializeField] private JointLimitPreset _lowTwist = new(-20f, 0f, 0f);
		[SerializeField] private JointLimitPreset _highTwist = new(70f, 0f, 0f);
		[SerializeField] private JointLimitPreset _swing1 = new(30f, 0f, 0f);
		[SerializeField] private JointLimitPreset _swing2 = new(0f, 0f, 0f);

		public void Apply(CharacterJoint to)
		{
			to.lowTwistLimit = _lowTwist;
			to.highTwistLimit = _highTwist;
			to.swing1Limit = _swing1;
			to.swing2Limit = _swing2;
		}

		public void Capture(CharacterJoint from)
		{
			_lowTwist.CopyFrom(from.lowTwistLimit);
			_highTwist.CopyFrom(from.highTwistLimit);
			_swing1.CopyFrom(from.swing1Limit);
			_swing2.CopyFrom(from.swing2Limit);
		}
	}
}