// SPDX-License-Identifier: Apache-2.0
// © 2024-2025 Depra <n.melnikov@depra.org>

using UnityEngine;
using static Depra.Ragdoll.Module;

namespace Depra.Ragdoll
{
	[DisallowMultipleComponent]
	[AddComponentMenu(MENU_PATH + "Ragdoll Character Controller", DEFAULT_ORDER)]
	public sealed class RagdollCharacterController : ExternalRagdollPlugin
	{
		[SerializeField] private CharacterController _controller;

		protected override void OnEnabled() => _controller.enabled = false;

		protected override void OnDisabled() => _controller.enabled = false;
	}
}