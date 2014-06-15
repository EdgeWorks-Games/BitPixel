﻿using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Threading;

namespace BitPixel
{
	public sealed class GameEngine : IDisposable
	{
		private readonly List<IEngineComponent> _components = new List<IEngineComponent>();
		private bool _keepRunning;

		public bool IsRunning { get; private set; }
		public TimeSpan TargetDelta { get; set; }

		public void Dispose()
		{
		}

		public void AddComponent(IEngineComponent component)
		{
			Debug.Assert(!_components.Contains(component), "Cannot add already added component.");
			_components.Add(component);
		}

		public void RemoveComponent(IEngineComponent component)
		{
			Debug.Assert(_components.Contains(component), "Cannot remove nonexistent component.");
			_components.Remove(component);
		}

		public void Start()
		{
			Debug.Assert(!IsRunning, "Cannot start if already started.");
			Trace.TraceInformation("Starting game loop...");

			IsRunning = true;
			_keepRunning = true;
			while (_keepRunning)
			{
				foreach (var component in _components)
					component.Update((float) TargetDelta.TotalSeconds);

				Thread.Sleep(TargetDelta);
			}

			Trace.TraceInformation("Game loop ended!");
		}

		public void Stop()
		{
			Debug.Assert(IsRunning);
			Trace.TraceInformation("Stop() called!");

			_keepRunning = false;
		}
	}
}