// SPDX-License-Identifier: Apache-2.0
// © 2024 Nikolay Melnikov <n.melnikov@depra.org>

using Depra.Ragdoll.Armature;
using UnityEngine;
using static Depra.Ragdoll.Module;

namespace Depra.Ragdoll.Body.States
{
	[DisallowMultipleComponent]
	[AddComponentMenu(menuName: MENU_PATH + nameof(ActiveRagdollState), DEFAULT_ORDER)]
	public sealed class ActiveRagdollState : RagdollState
	{
		[SerializeField] private RagdollArmatureBaker _armature;

		private RagdollArmature _bakedArmature;

		private RagdollArmature BakedArmature => _bakedArmature ??= _armature.Bake();

		[ContextMenu(nameof(Enter))]
		public override void Enter()
		{
			foreach (var bone in BakedArmature.Bones)
			{
				if (bone.Joint)
				{
					bone.Joint.enableCollision = true;
				}

				bone.Rigidbody.useGravity = true;
				bone.Rigidbody.isKinematic = false;
				bone.Rigidbody.detectCollisions = true;
				bone.Rigidbody.velocity = Vector3.zero;
			}
		}

		[ContextMenu(nameof(Exit))]
		public override void Exit()
		{
			foreach (var bone in BakedArmature.Bones)
			{
				if (bone.Joint)
				{
					bone.Joint.enableCollision = false;
				}

				bone.Rigidbody.useGravity = false;
				bone.Rigidbody.isKinematic = true;
				bone.Rigidbody.detectCollisions = false;
			}
		}
	}
}