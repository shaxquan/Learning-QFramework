using System;
using UnityEngine;
using UnityEngine.UI;
using QFramework;

namespace shaxquan.Survivor
{
	// Generate Id:6c9dd96c-bc60-4a68-a67e-db71ccbe24bd
	public partial class UIHomePanel
	{
		public const string Name = "UIHomePanel";
		
		
		private UIHomePanelData mPrivateData = null;
		
		protected override void ClearUIComponents()
		{
			
			mData = null;
		}
		
		public UIHomePanelData Data
		{
			get
			{
				return mData;
			}
		}
		
		UIHomePanelData mData
		{
			get
			{
				return mPrivateData ?? (mPrivateData = new UIHomePanelData());
			}
			set
			{
				mUIData = value;
				mPrivateData = value;
			}
		}
	}
}
