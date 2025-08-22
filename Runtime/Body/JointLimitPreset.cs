// SPDX-License-Identifier: Apache-2.0
// © 2024-2025 Depra <n.melnikov@depra.org>

using UnityEngine;

namespace Depra.Creature.Runtime.Ragdoll.Joints
{
	[System.Serializable]
	public struct JointLimitPreset
	{
		[Min(0f)] [SerializeField] private float _limit;
		[Min(0f)] [SerializeField] private float _bounciness;
		[Min(0f)] [SerializeField] private float _contactDistance;

		public static implicit operator SoftJointLimit(JointLimitPreset self) => self.Convert();

		public static implicit operator JointLimitPreset(SoftJointLimit self) =>
			new(self.limit, self.bounciness, self.contactDistance);

		public JointLimitPreset(float limit, float bounciness, float contactDistance)
		{
			_limit = limit;
			_bounciness = bounciness;
			_contactDistance = contactDistance;
		}

		public SoftJointLimit Convert() => new()
		{
			limit = _limit,
			bounciness = _bounciness,
			contactDistance = _contactDistance
		};
	}
}