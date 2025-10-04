// SPDX-License-Identifier: Apache-2.0
// © 2024-2025 Depra <n.melnikov@depra.org>

using System;
using System.Collections;
using System.Collections.Generic;
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

		internal HumanoidArmaturePreset Preset => _preset;

		public override IEnumerable<RagdollBone> GatherBones() => new Enumerator(this);

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

		private struct Enumerator : IEnumerable<RagdollBone>, IEnumerator<RagdollBone>
		{
			private readonly HumanoidArmature _armature;
			private int _index;

			public Enumerator(HumanoidArmature armature)
			{
				_armature = armature;
				_index = -1;
			}

			public RagdollBone Current => _index switch
			{
				0 => _armature._head,
				1 => _armature._torso,
				2 => _armature._pelvis,
				3 => _armature._leftHip,
				4 => _armature._leftKnee,
				5 => _armature._rightHip,
				6 => _armature._rightKnee,
				7 => _armature._leftShoulder,
				8 => _armature._leftElbow,
				9 => _armature._rightShoulder,
				10 => _armature._rightElbow,
				_ => null
			};

			object IEnumerator.Current => Current;

			bool IEnumerator.MoveNext() => ++_index < 11;
			void IEnumerator.Reset() => _index = -1;
			void IDisposable.Dispose() { }

			IEnumerator<RagdollBone> IEnumerable<RagdollBone>.GetEnumerator() => this;
			IEnumerator IEnumerable.GetEnumerator() => this;
		}
	}
}