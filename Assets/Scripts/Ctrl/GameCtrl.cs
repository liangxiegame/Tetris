using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace QFramework.Tetris
{
	public class GameCtrl : MonoSingleton<GameCtrl>
	{
		ResLoader mResLoader = ResLoader.Allocate();
		
		private bool IsPause = false;

		public ShapeCtrl[] Shapes;

		public Color[] Colors;

		private ShapeCtrl mCurrentShape;


		private void Awake()
		{
			var shapeNames = new[]
			{
				QAssetBundle.Shapes.SHAPE_1,
				QAssetBundle.Shapes.SHAPE_2,
				QAssetBundle.Shapes.SHAPE_3,
				QAssetBundle.Shapes.SHAPE_4,
				QAssetBundle.Shapes.SHAPE_5,
				QAssetBundle.Shapes.SHAPE_6,
				QAssetBundle.Shapes.SHAPE_7,
			};

			Shapes = shapeNames.Select(shapeName => mResLoader.LoadSync<GameObject>(shapeName)
				.GetComponent<ShapeCtrl>()).ToArray();


			Colors = new[]
			{
				"#4DD5B0FF".HtmlStringToColor(),
				"#ED954AFF".HtmlStringToColor(),
				"#98DC55FF".HtmlStringToColor(),
				"#DC6555FF".HtmlStringToColor(),
				"#DC6555FF".HtmlStringToColor(),
				"#43BA9AFF".HtmlStringToColor(),
				"#59CB86FF".HtmlStringToColor(),
			};
		}

		public void StartGame()
		{
			IsPause = false;
		}

		public void PauseGame()
		{
			IsPause = true;
		}
		
		// Update is called once per frame
		void Update()
		{
			if (IsPause) return;
			
			if (!mCurrentShape) SpawnShape();
		}

		void SpawnShape()
		{
			int index = Random.Range(0, Shapes.Length);
			int indexColor = Random.Range(0, Colors.Length);
			mCurrentShape = Shapes[index].Instantiate();
			mCurrentShape.Init(Colors[indexColor]);
		}
	}
}