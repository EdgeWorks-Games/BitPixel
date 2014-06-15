﻿using System;
using System.Diagnostics;
using System.Threading;

namespace BitPixel
{
	public sealed class GameEngine : IDisposable
	{
		private bool _keepRunning;

		public GameEngine()
		{
			Components = new EngineComponentCollection();
		}

		public bool IsRunning { get; private set; }
		public TimeSpan TargetDelta { get; set; }
		public EngineComponentCollection Components { get; private set; }

		public void Dispose()
		{
		}

		public void Start()
		{
			Debug.Assert(!IsRunning, "Cannot start if already started.");
			Trace.TraceInformation("Starting game loop...");

			IsRunning = true;
			_keepRunning = true;
			while (_keepRunning)
			{
				foreach (var component in Components)
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