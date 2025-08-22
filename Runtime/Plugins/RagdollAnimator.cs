// SPDX-License-Identifier: Apache-2.0
// © 2024-2025 Depra <n.melnikov@depra.org>

using UnityEngine;
using static Depra.Ragdoll.Module;

namespace Depra.Ragdoll.Parts
{
	[DisallowMultipleComponent]
	[AddComponentMenu(MENU_PATH + "Ragdoll Animator", DEFAULT_ORDER)]
	public sealed class RagdollAnimator : RagdollPart
	{
		[SerializeField] private Animator _animator;

		private void OnValidate() => _animator ??= GetComponentInChildren<Animator>();

		public override void Enable() => _animator.enabled = false;

		public override void Disable() => _animator.enabled = true;
	}
}