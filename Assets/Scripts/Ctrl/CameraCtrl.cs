using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;

namespace QFramework.Tetris
{
	[RequireComponent(typeof(Camera))]
	public class CameraCtrl : MonoSingleton<CameraCtrl>
	{
		private Camera mCamera;
		
		private void Awake()
		{
			mCamera = GetComponent<Camera>();
		}


		public void ZoomIn()
		{
			mCamera.DOOrthoSize(14f, 0.5f);
		}

		public void ZoomOut()
		{
			mCamera.DOOrthoSize(18.48f, 0.5f);

		}
	}
}