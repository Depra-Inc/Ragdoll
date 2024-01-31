// SPDX-License-Identifier: Apache-2.0
// © 2024 Nikolay Melnikov <n.melnikov@depra.org>

using Depra.Ragdoll.Armature;
using UnityEngine;

namespace Depra.Ragdoll.Body.States
{
	public sealed class ActiveRagdollState : RagdollState
	{
		[SerializeField] private RagdollArmatureBaker _armature;

		private RagdollArmature _bakedArmature;

		public override void Initialize(RagdollBody body) => _bakedArmature = _armature.Bake();

		[ContextMenu(nameof(Enter))]
		public override void Enter()
		{
			foreach (var bone in _bakedArmature.Bones)
			{
				bone.Rigidbody.useGravity = true;
				bone.Rigidbody.isKinematic = false;
			}
		}

		[ContextMenu(nameof(Exit))]
		public override void Exit()
		{
			foreach (var bone in _bakedArmature.Bones)
			{
				bone.Rigidbody.useGravity = false;
				bone.Rigidbody.isKinematic = true;
			}
		}
	}
}