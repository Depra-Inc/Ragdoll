// SPDX-License-Identifier: Apache-2.0
// © 2024 Nikolay Melnikov <n.melnikov@depra.org>

using UnityEngine;
using static Depra.Ragdoll.Module;

namespace Depra.Ragdoll.Body.States
{
	[DisallowMultipleComponent]
	[AddComponentMenu(menuName: MENU_PATH + nameof(AnimatedRagdollState), DEFAULT_ORDER)]
	public sealed class AnimatedRagdollState : RagdollState
	{
		[SerializeField] private Animator _animator;

		[ContextMenu(nameof(Enter))]
		public override void Enter() => _animator.enabled = true;

		[ContextMenu(nameof(Exit))]
		public override void Exit() => _animator.enabled = false;
	}
}