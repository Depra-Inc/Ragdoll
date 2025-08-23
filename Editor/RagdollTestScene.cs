using UnityEditor;
using UnityEditor.SceneManagement;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Depra.Ragdoll.Editor
{
	internal static class RagdollTestScene
	{
		private static string _previousScene;
		private static bool _needsSceneRestore;
		private static bool _enterPlayModeOptionsEnabled;
		private static EnterPlayModeOptions _enterPlayModeOptions;

		public static void Open(GameObject prefab)
		{
			_previousScene = SceneManager.GetActiveScene().path;
			EditorSceneManager.NewScene(NewSceneSetup.EmptyScene, NewSceneMode.Single);

			SpawnSceneLight();
			SpawnSceneCamera();
			SpawnSceneEnvironment();
			SpawnSceneController(prefab);

			_enterPlayModeOptions = EditorSettings.enterPlayModeOptions;
			_enterPlayModeOptionsEnabled = EditorSettings.enterPlayModeOptionsEnabled;

			EditorSettings.enterPlayModeOptionsEnabled = true;
			EditorSettings.enterPlayModeOptions = EnterPlayModeOptions.DisableDomainReload;

			EditorApplication.playModeStateChanged -= OnPlayModeStateChanged;
			EditorApplication.playModeStateChanged += OnPlayModeStateChanged;

			_needsSceneRestore = true;
			EditorApplication.EnterPlaymode();
		}

		public static void Quit()
		{
			if (EditorApplication.isPlaying)
			{
				EditorApplication.ExitPlaymode();
			}
			else
			{
				RestoreOriginalScene();
			}
		}

		private static void OnPlayModeStateChanged(PlayModeStateChange state)
		{
			if (_needsSceneRestore && state == PlayModeStateChange.EnteredEditMode)
			{
				EditorApplication.delayCall += RestoreOriginalScene;
			}
		}

		private static void SpawnSceneCamera()
		{
			var gameObject = new GameObject("Main Camera")
			{
				transform =
				{
					position = new Vector3(0, 1.5f, -5),
					rotation = Quaternion.Euler(10, 0, 0)
				}
			};

			gameObject.AddComponent<Camera>();
			gameObject.tag = "MainCamera";
		}

		private static void SpawnSceneEnvironment()
		{
			var ground = GameObject.CreatePrimitive(PrimitiveType.Plane);
			ground.transform.position = Vector3.zero;
			ground.name = "Ground";
		}

		private static void SpawnSceneLight()
		{
			var gameObject = new GameObject("Directional Light")
			{
				transform = { rotation = Quaternion.Euler(50, -30, 0) }
			};

			var light = gameObject.AddComponent<Light>();
			light.type = LightType.Directional;
			light.intensity = 1.5f;
		}

		private static void SpawnSceneController(GameObject prefab)
		{
			new GameObject("Ragdoll Test Controller").AddComponent<RagdollTestController>();
			RagdollTestController.Initialize(prefab, Quit);
		}

		private static void RestoreOriginalScene()
		{
			if (!_needsSceneRestore)
			{
				return;
			}

			EditorSettings.enterPlayModeOptions = _enterPlayModeOptions;
			EditorSettings.enterPlayModeOptionsEnabled = _enterPlayModeOptionsEnabled;

			EditorApplication.delayCall -= RestoreOriginalScene;
			EditorApplication.playModeStateChanged -= OnPlayModeStateChanged;

			RagdollTestController.Teardown();
			if (!string.IsNullOrEmpty(_previousScene))
			{
				EditorSceneManager.OpenScene(_previousScene, OpenSceneMode.Single);
			}

			_needsSceneRestore = false;
		}
	}
}