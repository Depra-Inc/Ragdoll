// SPDX-License-Identifier: Apache-2.0
// © 2024 Nikolay Melnikov <n.melnikov@depra.org>

using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Depra.Ragdoll.Parts;
using UnityEngine;
using static Depra.Ragdoll.Module;
#if UNITY_EDITOR
using UnityEditor;
#endif

namespace Depra.Ragdoll.Body
{
	[AddComponentMenu(MENU_PATH + nameof(RagdollBody), DEFAULT_ORDER)]
	public sealed class RagdollBody : MonoBehaviour
	{
		[SerializeField] private List<RagdollPart> _parts;

		public bool IsEnabled { get; private set; }

		private void Reset() => GatherParts();

		[ContextMenu(nameof(Enable))]
		public void Enable()
		{
			if (IsEnabled)
			{
				return;
			}

			EnableParts();
			IsEnabled = true;

#if UNITY_EDITOR
			EditorUtility.SetDirty(this);
#endif
		}

		[ContextMenu(nameof(Disable))]
		public void Disable()
		{
			if (IsEnabled == false)
			{
				return;
			}

			DisableParts();
			IsEnabled = false;

#if UNITY_EDITOR
			EditorUtility.SetDirty(this);
#endif
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		private void EnableParts()
		{
			foreach (var part in _parts)
			{
				part.Enable();
			}
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		private void DisableParts()
		{
			foreach (var part in _parts)
			{
				part.Disable();
			}
		}

		[ContextMenu(nameof(GatherParts))]
		private void GatherParts()
		{
			foreach (var part in GetComponentsInChildren<RagdollPart>())
			{
				if (_parts.Contains(part) == false)
				{
					_parts.Add(part);
				}
			}
		}
	}
}