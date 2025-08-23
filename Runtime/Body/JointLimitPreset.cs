// SPDX-License-Identifier: Apache-2.0
// © 2024-2025 Depra <n.melnikov@depra.org>

using UnityEngine;

namespace Depra.Creature.Runtime.Ragdoll.Joints
{
	[System.Serializable]
	public class JointLimitPreset
	{
		[SerializeField] private float _limit;
		[Min(0f)] [SerializeField] private float _bounciness;
		[Min(0f)] [SerializeField] private float _contactDistance;

		public static implicit operator SoftJointLimit(JointLimitPreset self) => new()
		{
			limit = self._limit,
			bounciness = self._bounciness,
			contactDistance = self._contactDistance
		};

		public JointLimitPreset(float limit, float bounciness, float contactDistance)
		{
			_limit = limit;
			_bounciness = bounciness;
			_contactDistance = contactDistance;
		}

		public void CopyFrom(SoftJointLimit other)
		{
			_limit = other.limit;
			_bounciness = other.bounciness;
			_contactDistance = other.contactDistance;
		}
	}
}