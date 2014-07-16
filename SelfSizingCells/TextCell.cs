using System;
using System.Drawing;
using MonoTouch.Foundation;
using MonoTouch.UIKit;

namespace SelfSizingCells
{
    public class TextCell : UICollectionViewCell
    {
        UILabel label;

        public string Text {
            get {
                return label.Text;
            }
            set {
                label.Text = value;
                SetNeedsDisplay ();
            }
        }

        [Export ("initWithFrame:")]
        TextCell (RectangleF frame) : base (frame)
        {      
            label = new UILabel (RectangleF.Empty);
            label.BackgroundColor = UIColor.Gray;
            label.TextColor = UIColor.Blue;
            label.Lines = 10;

            label.Frame = ContentView.Frame;

            ContentView.BackgroundColor = UIColor.Green;
            ContentView.AddSubview (label);
        }

        public override SizeF SizeThatFits (SizeF size)
        {
            label.Frame = new RectangleF (new PointF (0, 0), label.AttributedText.Size);
            return label.AttributedText.Size;
        }

//        public override UICollectionViewLayoutAttributes PreferredLayoutAttributesFittingAttributes (UICollectionViewLayoutAttributes layoutAttributes)
//        {
//            var newLayoutAttributes = (UICollectionViewLayoutAttributes)layoutAttributes.Copy ();
//
//            if (layoutAttributes.IndexPath.Row % 2 == 0) {
//                label.TextColor = UIColor.Red;
//                ContentView.BackgroundColor = UIColor.LightGray;
//                var attr = new NSAttributedString (Text, UIFont.SystemFontOfSize (28.0f));
//                label.Font = UIFont.SystemFontOfSize (28.0f);
//               
//                newLayoutAttributes.Frame = new RectangleF (new PointF (0, 0), attr.Size);
//                label.Frame = new RectangleF (new PointF (0, 0), attr.Size);
//            } else {
//                newLayoutAttributes.Frame = new RectangleF (new PointF (0, 0), label.AttributedText.Size);
//                label.Frame = new RectangleF (new PointF (0, 0), label.AttributedText.Size);
//            }
//
//            return newLayoutAttributes;
//        }
    }
}