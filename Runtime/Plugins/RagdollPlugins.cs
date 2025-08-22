// SPDX-License-Identifier: Apache-2.0
// © 2024-2025 Depra <n.melnikov@depra.org>

using System;
using UnityEngine;
using static Depra.Ragdoll.Module;

namespace Depra.Ragdoll.Parts
{
	[DisallowMultipleComponent]
	[AddComponentMenu(MENU_PATH + "Ragdoll Plugins", DEFAULT_ORDER)]
	public sealed class RagdollPlugins : RagdollPart
	{
		public event Action Enabled;
		public event Action Disabled;

		public override void Enable() => Enabled?.Invoke();

		public override void Disable() => Disabled?.Invoke();
	}
}