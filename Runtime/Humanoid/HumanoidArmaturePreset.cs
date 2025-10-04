// SPDX-License-Identifier: Apache-2.0
// © 2024-2025 Depra <n.melnikov@depra.org>

using UnityEngine;
using static Depra.Ragdoll.Module;

namespace Depra.Ragdoll
{
	[CreateAssetMenu(menuName = MENU_PATH + FILE_NAME, order = DEFAULT_ORDER)]
	public sealed class HumanoidArmaturePreset : ScriptableObject
	{
		[SerializeField]
		private HumanoidBonePreset[] _bones =
		{
			new(HumanoidBoneType.HEAD),
			new(HumanoidBoneType.TORSO),
			new(HumanoidBoneType.PELVIS),
			new(HumanoidBoneType.LEFT_HIP),
			new(HumanoidBoneType.LEFT_KNEE),
			new(HumanoidBoneType.RIGHT_HIP),
			new(HumanoidBoneType.RIGHT_KNEE),
			new(HumanoidBoneType.LEFT_ARM),
			new(HumanoidBoneType.LEFT_ELBOW),
			new(HumanoidBoneType.RIGHT_ARM),
			new(HumanoidBoneType.RIGHT_ELBOW)
		};

		private const string FILE_NAME = "Humanoid Armature";

		public HumanoidBonePreset GetBone(HumanoidBoneType type)
		{
			for (var index = 0; index < _bones.Length; index++)
			{
				var bone = _bones[index];
				if (bone.Type == type)
				{
					return bone;
				}
			}

			return new HumanoidBonePreset(type);
		}
	}
}