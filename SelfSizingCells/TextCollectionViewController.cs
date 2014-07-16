using System;
using System.Drawing;
using MonoTouch.Foundation;
using MonoTouch.UIKit;

namespace SelfSizingCells
{
	public class TextCollectionViewController : UICollectionViewController
	{
		static readonly NSString cellId = new NSString ("TextCell");

        string[] words = { "one", "two", "three", "four", "five", "six seven eight", "nine ten eleven twelve thirteen",
            "the quick brown fox", "jumped", "over\r\nthe lazy\r\ndog"};

//        FlowLayoutDelegate flowDelegate;

		public TextCollectionViewController (UICollectionViewLayout layout) : base (layout)
		{
			CollectionView.ContentSize = UIScreen.MainScreen.Bounds.Size;
            CollectionView.BackgroundColor = UIColor.Black;

//            flowDelegate = new FlowLayoutDelegate (words);
//            CollectionView.Delegate = flowDelegate;
		}

		public override void ViewDidLoad ()
		{
			base.ViewDidLoad ();
              
			CollectionView.RegisterClassForCell (typeof(TextCell), cellId);
		}

		public override int GetItemsCount (UICollectionView collectionView, int section)
		{
            return words.Length;
		}

		public override UICollectionViewCell GetCell (UICollectionView collectionView, NSIndexPath indexPath)
		{
            var textCell = (TextCell)collectionView.DequeueReusableCell (cellId, indexPath);

            textCell.Text = words [indexPath.Row];

			return textCell;
		}  

        class FlowLayoutDelegate : UICollectionViewDelegateFlowLayout
        {
            string[] items;
            UIStringAttributes attr;

            public FlowLayoutDelegate (string[] items)
            {
                this.items = items;

                attr = new UIStringAttributes {
                    Font = new UILabel ().Font
                };
            }

            public override SizeF GetSizeForItem (UICollectionView collectionView, UICollectionViewLayout layout, NSIndexPath indexPath)
            {
                string text = items [indexPath.Row];

                return new NSString (text).GetSizeUsingAttributes (attr);
            }
        }
	}
}