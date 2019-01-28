using System;
using System.ComponentModel;
using Android.Content;
using Android.Graphics.Drawables;
using Android.Util;
using Recipes.CustomRederers;
using Recipes.Droid.CustomRederers;
using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;


[assembly: ExportRenderer(typeof(CustomButton), typeof(CustomButtonRenderer))]
namespace Recipes.Droid.CustomRederers
{
    public class CustomButtonRenderer : ButtonRenderer
    {
        private GradientDrawable gradientBackground;

        protected override void OnElementChanged(ElementChangedEventArgs<Xamarin.Forms.Button> e)
        {
            base.OnElementChanged(e);

            var view = (CustomButton)Element;
            if (view == null) return;

            Paint(view);
        }
        protected override void OnElementPropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            base.OnElementPropertyChanged(sender, e);
            if
               (e.PropertyName == CustomButton.CustomBorderColorProperty.PropertyName ||
                 e.PropertyName == CustomButton.CustomBorderRadiusProperty.PropertyName ||
                 e.PropertyName == CustomButton.CustomBorderWidthProperty.PropertyName)
            {

                if (Element != null)
                {
                    Paint((CustomButton)Element);
                }
            }
        }
        private void Paint(CustomButton view)
        {
            gradientBackground = new GradientDrawable();
            gradientBackground.SetShape(ShapeType.Rectangle);
            gradientBackground.SetColor(view.CustomBackgroundColor.ToAndroid());

            // Thickness of the stroke line
            gradientBackground.SetStroke((int)view.CustomBorderWidth, view.CustomBorderColor.ToAndroid());

            // Radius for the curves
            gradientBackground.SetCornerRadius(
                DpToPixels(this.Context, Convert.ToSingle(view.CustomBorderRadius)));

            // set the background of the label
            Control.SetBackground(gradientBackground);
        }

        public static float DpToPixels(Context context, float valueInDp)
        {
            DisplayMetrics metrics = context.Resources.DisplayMetrics;
            return TypedValue.ApplyDimension(ComplexUnitType.Dip, valueInDp, metrics);
        }
    }
}