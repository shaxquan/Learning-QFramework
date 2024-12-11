using System;
using UnityEngine;
using QFramework;

namespace shaxquan.Survivor
{
	public partial class Enemy : ViewController
	{
		public float MovementSpeed = 2.0f;
		void Start()
		{
			// Code Here
		}

		private void Update()
		{
			if (Player == null) return;
			var direction = (Player.position - transform.position).normalized;
			transform.Translate(direction * (Time.deltaTime * MovementSpeed));
		}
	}
}
