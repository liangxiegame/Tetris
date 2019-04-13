using Invert.Common.UI;
using UnityEditor;
using UnityEngine;

namespace QFramework.Editor
{
	public class PackageAdminView2 : GUIView,IPackageKitView
	{
		public IQFrameworkContainer Container { get; set; }

		public int RenderOrder
		{
			get { return 4; }
		}

		public bool Ignore { get; private set; }
		public bool Enabled
		{
			get { return true; }
		}

		private PackageInfosRequestCache mCache = null;
		
		public void Init(IQFrameworkContainer container)
		{
			mCache = PackageInfosRequestCache.Get();
		}

		public override void OnGUI()
		{
			base.OnGUI();

			if (GUIHelpers.DoToolbarEx("PackageAdminView2"))
			{
				GUILayout.BeginVertical("box");
				
				// draw tree
				mScrollPosition = EditorGUILayout.BeginScrollView(mScrollPosition);

				mCache.PackageDatas.ForEach(packageData =>
				{
					if (GUIHelpers.DoToolbarEx(packageData.Name))
					{
						packageData.PackageVersions.ForEach(version =>
						{
							GUILayout.BeginHorizontal();

							GUILayout.Space(20);
							GUILayout.Label(version.Version);

							if (GUILayout.Button("删除"))
							{
								EditorActionKit.ExecuteNode(new DeletePackage(version.Id)
								{
									OnEndedCallback = () =>
									{
										EditorActionKit.ExecuteNode(new GetAllRemotePackageInfo((datas) =>
										{
											mCache.PackageDatas = datas;
											mCache.Save();
											mCache = PackageInfosRequestCache.Get();

										}));
									}
								});
							}

							GUILayout.EndHorizontal();
						});
					}
				});
				EditorGUILayout.EndScrollView();

				GUILayout.EndVertical();
			}
		}
		
		
		private Vector2        mScrollPosition;
		private string         mSearchString;
	}
}