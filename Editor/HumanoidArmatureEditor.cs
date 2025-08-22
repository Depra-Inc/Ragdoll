// SPDX-License-Identifier: Apache-2.0
// © 2024-2025 Depra <n.melnikov@depra.org>

using Depra.Ragdoll.Armature;
using UnityEditor;
using UnityEngine;

namespace Depra.Ragdoll.Editor
{
	[CustomEditor(typeof(HumanoidArmature))]
	internal sealed class HumanoidArmatureEditor : UnityEditor.Editor
	{
		private HumanoidArmature _armature;
		private SerializedProperty _pelvis, _torso, _head;
		private SerializedProperty _leftHip, _leftKnee;
		private SerializedProperty _rightHip, _rightKnee;
		private SerializedProperty _leftShoulder, _leftElbow;
		private SerializedProperty _rightShoulder, _rightElbow;
		private SerializedProperty _preset;

		private bool _spineFoldout = true;
		private bool _legsFoldout = true;
		private bool _armsFoldout = true;

		private void OnEnable()
		{
			_armature = (HumanoidArmature)target;

			_head = serializedObject.FindProperty("_head");
			_torso = serializedObject.FindProperty("_torso");
			_pelvis = serializedObject.FindProperty("_pelvis");

			_leftHip = serializedObject.FindProperty("_leftHip");
			_leftKnee = serializedObject.FindProperty("_leftKnee");
			_rightHip = serializedObject.FindProperty("_rightHip");
			_rightKnee = serializedObject.FindProperty("_rightKnee");

			_leftShoulder = serializedObject.FindProperty("_leftShoulder");
			_leftElbow = serializedObject.FindProperty("_leftElbow");
			_rightShoulder = serializedObject.FindProperty("_rightShoulder");
			_rightElbow = serializedObject.FindProperty("_rightElbow");

			_preset = serializedObject.FindProperty("_preset");
		}

		public override void OnInspectorGUI()
		{
			serializedObject.Update();

			DrawSpineSection();
			DrawLegsSection();
			DrawArmsSection();

			if (GUILayout.Button("Gather Bones"))
			{
				Undo.RecordObject(_armature, "Gather Bones");
				_armature.GatherBones();
				EditorUtility.SetDirty(_armature);
			}

			EditorGUILayout.Space(8);
			DrawPresetSection();

			serializedObject.ApplyModifiedProperties();
		}

		private void DrawSpineSection()
		{
			_spineFoldout = EditorGUILayout.BeginFoldoutHeaderGroup(_spineFoldout, "Spine & Head");
			if (_spineFoldout)
			{
				EditorGUILayout.PropertyField(_head);
				EditorGUILayout.PropertyField(_torso);
				EditorGUILayout.PropertyField(_pelvis);
			}

			EditorGUILayout.EndFoldoutHeaderGroup();
		}

		private void DrawLegsSection()
		{
			_legsFoldout = EditorGUILayout.BeginFoldoutHeaderGroup(_legsFoldout, "Legs");
			if (_legsFoldout)
			{
				EditorGUILayout.PropertyField(_leftHip);
				EditorGUILayout.PropertyField(_leftKnee);
				EditorGUILayout.PropertyField(_rightHip);
				EditorGUILayout.PropertyField(_rightKnee);
			}

			EditorGUILayout.EndFoldoutHeaderGroup();
		}

		private void DrawArmsSection()
		{
			_armsFoldout = EditorGUILayout.BeginFoldoutHeaderGroup(_armsFoldout, "Arms");
			if (_armsFoldout)
			{
				EditorGUILayout.PropertyField(_leftShoulder);
				EditorGUILayout.PropertyField(_leftElbow);
				EditorGUILayout.PropertyField(_rightShoulder);
				EditorGUILayout.PropertyField(_rightElbow);
			}

			EditorGUILayout.EndFoldoutHeaderGroup();
		}

		private void DrawPresetSection()
		{
			EditorGUILayout.PropertyField(_preset);
			if (_preset.objectReferenceValue == null)
			{
				return;
			}

			using (new EditorGUILayout.HorizontalScope())
			{
				if (GUILayout.Button("Apply Preset"))
				{
					Undo.RecordObject(_armature, "Apply Preset");
					_armature.ApplyPreset();
					EditorUtility.SetDirty(_armature);
				}

				if (GUILayout.Button("Save Preset"))
				{
					Undo.RecordObject(_armature, "Save Preset");
					_armature.SavePreset();
					EditorUtility.SetDirty(_armature);
				}
			}
		}
	}
}