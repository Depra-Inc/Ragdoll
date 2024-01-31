// SPDX-License-Identifier: Apache-2.0
// © 2024 Nikolay Melnikov <n.melnikov@depra.org>

using Depra.Stateful.Abstract;
using UnityEngine;

namespace Depra.Ragdoll.Body.States
{
	public abstract class RagdollState : MonoBehaviour, IState
	{
		// ReSharper disable once Unity.RedundantEventFunction
		protected virtual void Start() { }

		public abstract void Initialize(RagdollBody body);

		public abstract void Enter();

		public abstract void Exit();
	}
}