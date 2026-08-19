// SPDX-License-Identifier: Apache-2.0
// © 2024-2025 Depra <n.melnikov@depra.org>

using System;
using UnityEngine;
using static Depra.Ragdoll.Module;

namespace Depra.Ragdoll
{
	[DisallowMultipleComponent]
	[AddComponentMenu(MENU_PATH + "Humanoid Armature", DEFAULT_ORDER)]
	public sealed class HumanoidArmature : RagdollArmature
	{
		[SerializeField] private RagdollBone _head, _torso, _pelvis;
		[SerializeField] private RagdollBone _leftHip, _leftKnee;
		[SerializeField] private RagdollBone _rightHip, _rightKnee;
		[SerializeField] private RagdollBone _leftShoulder, _leftElbow;
		[SerializeField] private RagdollBone _rightShoulder, _rightElbow;

		[SerializeField] private HumanoidArmaturePreset _preset;

		[SerializeField] private RagdollBone[] _bones;

		internal HumanoidArmaturePreset Preset => _preset;

		public override ReadOnlySpan<RagdollBone> GatherBones() => _bones;

		private void OnValidate() => _bones = new[]
		{
			_head, _torso, _pelvis,
			_leftHip, _leftKnee, _rightHip, _rightKnee,
			_leftShoulder, _leftElbow, _rightShoulder, _rightElbow
		};

		internal void ApplyPreset()
		{
			if (!_preset)
			{
				return;
			}

			_preset.GetBone(HumanoidBoneType.HEAD).Apply(_head);
			_preset.GetBone(HumanoidBoneType.TORSO).Apply(_torso);
			_preset.GetBone(HumanoidBoneType.PELVIS).Apply(_pelvis);
			_preset.GetBone(HumanoidBoneType.LEFT_HIP).Apply(_leftHip);
			_preset.GetBone(HumanoidBoneType.LEFT_KNEE).Apply(_leftKnee);
			_preset.GetBone(HumanoidBoneType.RIGHT_HIP).Apply(_rightHip);
			_preset.GetBone(HumanoidBoneType.RIGHT_KNEE).Apply(_rightKnee);
			_preset.GetBone(HumanoidBoneType.LEFT_ARM).Apply(_leftShoulder);
			_preset.GetBone(HumanoidBoneType.LEFT_ELBOW).Apply(_leftElbow);
			_preset.GetBone(HumanoidBoneType.RIGHT_ARM).Apply(_rightShoulder);
			_preset.GetBone(HumanoidBoneType.RIGHT_ELBOW).Apply(_rightElbow);
		}

		internal void SavePreset()
		{
			if (!_preset)
			{
				return;
			}

			_preset.GetBone(HumanoidBoneType.HEAD).Capture(_head);
			_preset.GetBone(HumanoidBoneType.TORSO).Capture(_torso);
			_preset.GetBone(HumanoidBoneType.PELVIS).Capture(_pelvis);
			_preset.GetBone(HumanoidBoneType.LEFT_HIP).Capture(_leftHip);
			_preset.GetBone(HumanoidBoneType.LEFT_KNEE).Capture(_leftKnee);
			_preset.GetBone(HumanoidBoneType.RIGHT_HIP).Capture(_rightHip);
			_preset.GetBone(HumanoidBoneType.RIGHT_KNEE).Capture(_rightKnee);
			_preset.GetBone(HumanoidBoneType.LEFT_ARM).Capture(_leftShoulder);
			_preset.GetBone(HumanoidBoneType.LEFT_ELBOW).Capture(_leftElbow);
			_preset.GetBone(HumanoidBoneType.RIGHT_ARM).Capture(_rightShoulder);
			_preset.GetBone(HumanoidBoneType.RIGHT_ELBOW).Capture(_rightElbow);
		}

	}
}