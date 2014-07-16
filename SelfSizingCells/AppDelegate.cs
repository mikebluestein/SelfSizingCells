using System;
using System.Collections.Generic;
using System.Linq;

using MonoTouch.Foundation;
using MonoTouch.UIKit;
using System.Drawing;

namespace SelfSizingCells
{
	[Register ("AppDelegate")]
	public partial class AppDelegate : UIApplicationDelegate
	{
		UIWindow window;
        TextCollectionViewController textController;
		UICollectionViewFlowLayout flowLayout;

		public override bool FinishedLaunching (UIApplication app, NSDictionary options)
		{
			window = new UIWindow (UIScreen.MainScreen.Bounds);

//			flowLayout = new UICollectionViewFlowLayout (){
//                SectionInset = new UIEdgeInsets (25,5,10,5),
//                MinimumInteritemSpacing = 5,
//                MinimumLineSpacing = 5,
//				ItemSize = new SizeF (100, 100)
//			};

            flowLayout = new UICollectionViewFlowLayout (){
                EstimatedItemSize = new SizeF (44, 144)
            };
		
			textController = new TextCollectionViewController (flowLayout);

			window.RootViewController = textController;
			window.MakeKeyAndVisible ();
			
			return true;
		}
	}
}

