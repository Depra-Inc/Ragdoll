// SPDX-License-Identifier: Apache-2.0
// © 2024 Nikolay Melnikov <n.melnikov@depra.org>

using UnityEngine;
using static Depra.Ragdoll.Module;

namespace Depra.Ragdoll.Plugins
{
	[DisallowMultipleComponent]
	[AddComponentMenu(MENU_PATH + nameof(RagdollCharacterController), DEFAULT_ORDER)]
	public sealed class RagdollCharacterController : ExternalRagdollPlugin
	{
		[SerializeField] private CharacterController _controller;

		protected override void OnEnabled() => _controller.enabled = false;

		protected override void OnDisabled() => _controller.enabled = false;
	}
}