using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace EasterEgg {
	/// <summary>
	/// Egg class (Singleton).
	/// </summary>
	public class Egg : Singleton<Egg> {
		/// <summary>
		/// All created sequences.
		/// </summary>
		private List<EggSequence> _sequences = new List<EggSequence>();

		/// <summary>
		/// Listen the sequence and invoke callback if it needed.
		/// </summary>
		/// <param name="sequence">Sequence of key codes.</param>
		/// <param name="callback">Callback that will be invoked.</param>
		public void ListenTo(List<KeyCode> sequence, Action callback) {
			_sequences.Add(new EggSequence(sequence, callback));
		}

		/// <summary>
		/// Listen the sequence and invoke callback if it needed.
		/// </summary>
		/// <param name="name">Sequence name (useful for stop and resume listener).</param>
		/// <param name="sequence">Sequence of key codes..</param>
		/// <param name="callback">Callback that will be invoked.</param>
		public void ListenTo(String name, List<KeyCode> sequence, Action callback) {
			_sequences.Add(new EggSequence(name, sequence, callback));
		}

		/// <summary>
		/// Pause (remove) listener by the sequence name.
		/// </summary>
		/// <param name="name">Sequence name.</param>
		public void StopListen(String name) {
			foreach (var seq in _sequences) {
				if (seq.Name == name)
					seq.StopListen ();
			}
		}

		/// <summary>
		/// Resume listener by the sequence name.
		/// </summary>
		/// <param name="name">Sequence name.</param>
		public void ResumeListen(String name) {
			foreach (var seq in _sequences) {
				if (seq.Name == name)
					seq.ResumeListen ();
			}
		}

		/// <summary>
		/// Listen input and check the active sequences.
		/// </summary>
		void Update () {
			if (Input.anyKeyDown) {
				foreach (var seq in _sequences) {
					// This sequence isn't active now
					if (!seq.IsEnabled)
						continue;

					// Ignore pressed SHIFT key (for example 'e' and 'E' are equal)
					if (Input.GetKeyDown(KeyCode.LeftShift) || Input.GetKeyDown(KeyCode.RightShift))
						continue;

					var key = seq.Sequence [seq.RightKeysCount];

					if (Input.GetKeyDown (key)) {
						// The right key is pressed
						seq.Next();
					} else {
						// The wrong key is pressed
						seq.Reset();
					}

					// Check if it's the time to invoke a callback
					seq.Check ();
				}
			}
		}
	}
}