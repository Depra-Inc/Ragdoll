// SPDX-License-Identifier: Apache-2.0
// © 2024-2025 Depra <n.melnikov@depra.org>

using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

namespace Depra.Ragdoll.Editor
{
	internal sealed class RagdollSandboxWindow : EditorWindow
	{
		private Vector2 _scrollPosition;
		private GameObject[] _availablePrefabs;

		public static void ShowWindow(HumanoidArmaturePreset preset)
		{
			var window = GetWindow<RagdollSandboxWindow>(true, "Ragdoll Sandbox", true);
			window.minSize = new Vector2(200, 100);
			window.maxSize = new Vector2(200, 300);
			window._availablePrefabs = GetPrefabsUsingPreset(preset);
			window.Show();
		}

		private void OnGUI()
		{
			if (_availablePrefabs == null || _availablePrefabs.Length == 0)
			{
				EditorGUILayout.HelpBox("No prefabs found using this preset.", MessageType.Info);
				if (GUILayout.Button("Close"))
				{
					Close();
				}

				return;
			}

			EditorGUILayout.LabelField("Select prefab to test:", EditorStyles.boldLabel);
			_scrollPosition = EditorGUILayout.BeginScrollView(_scrollPosition);

			foreach (var prefab in _availablePrefabs)
			{
				if (GUILayout.Button(prefab.name))
				{
					RagdollSandboxScene.Open(prefab);
					Close();
				}
			}

			EditorGUILayout.EndScrollView();
			if (GUILayout.Button("Cancel"))
			{
				Close();
			}
		}

		private static GameObject[] GetPrefabsUsingPreset(HumanoidArmaturePreset preset)
		{
			var guids = AssetDatabase.FindAssets("t:prefab", new[] { "Assets" });
			var list = new List<GameObject>();
			foreach (var guid in guids)
			{
				var path = AssetDatabase.GUIDToAssetPath(guid);
				var prefab = AssetDatabase.LoadAssetAtPath<GameObject>(path);
				if (!prefab)
				{
					continue;
				}

				var armatures = prefab.GetComponentsInChildren<HumanoidArmature>(false);
				foreach (var armature in armatures)
				{
					if (armature.Preset == preset && !list.Contains(prefab))
					{
						list.Add(prefab);
					}
				}
			}

			return list.ToArray();
		}
	}
}