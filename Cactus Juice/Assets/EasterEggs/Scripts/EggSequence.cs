using UnityEngine;
using System;
using System.Collections.Generic;

namespace EasterEgg {

	/// <summary>
	/// Egg sequence.
	/// </summary>
	public class EggSequence {

		/// <summary>
		/// The name of sequence (useful for pause and resume listener).
		/// </summary>
		private string _name = "";
		/// <summary>
		/// The callback we have to call after successful sequence.
		/// </summary>
		private Action _callback;
		/// <summary>
		/// The sequence of key codes.
		/// </summary>
		private List<KeyCode> _sequence;
		/// <summary>
		/// Is there listener for this sequence.
		/// </summary>
		private bool _isEnabled = true;
		/// <summary>
		/// The right pressed keys count for this sequence.
		/// </summary>
		private int _rightKeysCount = 0;

		/// <summary>
		/// Initializes a new instance of the <see cref="EasterEgg.EggSequence"/> class.
		/// </summary>
		/// <param name="sequence">Sequence.</param>
		/// <param name="callback">Callback.</param>
		public EggSequence(List<KeyCode> sequence, Action callback) {
			_sequence = sequence;
			_callback = callback;
		}

		/// <summary>
		/// Initializes a new instance of the <see cref="EasterEgg.EggSequence"/> class.
		/// </summary>
		/// <param name="name">Name.</param>
		/// <param name="sequence">Sequence.</param>
		/// <param name="callback">Callback.</param>
		public EggSequence(string name, List<KeyCode> sequence, Action callback) {
			_name = name;
			_sequence = sequence;
			_callback = callback;
		}

		/// <summary>
		/// Gets the name.
		/// </summary>
		/// <value>The name.</value>
		public string Name {
			get { return _name; }
		}

		/// <summary>
		/// Gets a value indicating whether this instance is enabled.
		/// </summary>
		/// <value><c>true</c> if this instance is enabled; otherwise, <c>false</c>.</value>
		public bool IsEnabled {
			get { return _isEnabled; }
		}

		/// <summary>
		/// Gets the sequence.
		/// </summary>
		/// <value>The sequence.</value>
		public List<KeyCode> Sequence {
			get { return _sequence; }
		}

		/// <summary>
		/// Gets the callback.
		/// </summary>
		/// <value>The callback.</value>
		public Action Callback {
			get { return _callback; }
		}

		/// <summary>
		/// Gets or sets the right keys count.
		/// </summary>
		/// <value>The right keys count.</value>
		public int RightKeysCount {
			get { return _rightKeysCount; }
			set { _rightKeysCount = value; }
		}

		/// <summary>
		/// Increase the right pressed keys count.
		/// </summary>
		public void Next() {
			_rightKeysCount++;
		}

		/// <summary>
		/// Reset this right pressed keys count.
		/// </summary>
		public void Reset() {
			_rightKeysCount = 0;
		}

		/// <summary>
		/// Check if it's a time to invoke a callback.
		/// </summary>
		public void Check() {
			if (_rightKeysCount == _sequence.Count) {
				Reset ();
				_callback ();
			}
		}

		/// <summary>
		/// Stops the sequence listener.
		/// </summary>
		public void StopListen() {
			_isEnabled = false;
		}

		/// <summary>
		/// Resumes the sequence listener.
		/// </summary>
		public void ResumeListen() {
			_isEnabled = true;
		}
	}
}

