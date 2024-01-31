// SPDX-License-Identifier: Apache-2.0
// © 2024 Nikolay Melnikov <n.melnikov@depra.org>

using Depra.Stateful.Abstract;

namespace Depra.Ragdoll.Body
{
	public readonly struct EmptyRagdollState : IState
	{
		void IState.Enter() { }

		void IState.Exit() { }
	}
}