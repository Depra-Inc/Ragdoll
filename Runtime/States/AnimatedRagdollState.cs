// SPDX-License-Identifier: Apache-2.0
// © 2024 Nikolay Melnikov <n.melnikov@depra.org>

using UnityEngine;

namespace Depra.Ragdoll.Body.States
{
	public sealed class AnimatedRagdollState : RagdollState
	{
		[SerializeField] private Animator _animator;

		public override void Initialize(RagdollBody body) { }

		[ContextMenu(nameof(Enter))]
		public override void Enter() => _animator.enabled = true;

		[ContextMenu(nameof(Exit))]
		public override void Exit() => _animator.enabled = false;
	}
}