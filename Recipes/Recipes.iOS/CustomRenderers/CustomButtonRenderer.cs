﻿using System.ComponentModel;
using Recipes.CustomRederers;
using Recipes.iOS.CustomRederers;
using Xamarin.Forms;
using Xamarin.Forms.Platform.iOS;

[assembly: ExportRenderer(typeof(CustomButton), typeof(CustomButtonRenderer))]
namespace Recipes.iOS.CustomRederers
{
    public class CustomButtonRenderer : ButtonRenderer
    {
        
        protected override void OnElementChanged(ElementChangedEventArgs<Button> e)
        {
            base.OnElementChanged(e);
            var view = (CustomButton)Element;
            if (view == null) return;
            Paint(view);
        }

        protected override void OnElementPropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            base.OnElementPropertyChanged(sender, e);
            if (e.PropertyName == CustomButton.CustomBorderRadiusProperty.PropertyName ||
               e.PropertyName == CustomButton.CustomBorderColorProperty.PropertyName ||
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
            this.Layer.CornerRadius = (float)view.CustomBorderRadius;
            this.Layer.BorderColor = view.CustomBorderColor.ToCGColor();
            this.Layer.BackgroundColor = view.CustomBackgroundColor.ToCGColor();
            this.Layer.BorderWidth = (int)view.CustomBorderWidth;
        }
    }
}