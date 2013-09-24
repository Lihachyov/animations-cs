using System;
using Windows.Foundation;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Media.Animation;

namespace AnimationsCS
{
    public static class Animations
    {
        #region EnterContent animation metrics
        private static readonly TimeSpan EnterContentTranslateAnimationDuration = new TimeSpan(0, 0, 0, 0, 1000);
        private static readonly TimeSpan EnterContentOpacityAnimationDelay = new TimeSpan(0, 0, 0, 0, 160);
        private static readonly TimeSpan EnterContentOpacityAnimationDuration = new TimeSpan(0, 0, 0, 0, 400);
        #endregion
        public static Storyboard EnterContent(FrameworkElement element, int offsetX, int offsetY)
        {
            var storyboard = new Storyboard();

            element.RenderTransform = new TranslateTransform
            {
                X = offsetX,
                Y = offsetY
            };

            //First animation - Translation
            storyboard.AddTranslateAnimations(element.RenderTransform,
                EnterContentTranslateAnimationDuration,
                offsetX, offsetY);

            //Second animation - Opacity
            storyboard.AddOpacityAnimation(element, EnterContentOpacityAnimationDuration,
                EnterContentOpacityAnimationDelay);

            storyboard.Begin();

            return storyboard;
        }

        //overloaded method for animation without opacity
        public static Storyboard EnterContent(FrameworkElement element, int offsetX, int offsetY, bool animateOpacity)
        {
            var storyboard = new Storyboard();

            element.RenderTransform = new TranslateTransform
            {
                X = offsetX,
                Y = offsetY
            };

            //First animation - Translation
            storyboard.AddTranslateAnimations(element.RenderTransform,
                EnterContentTranslateAnimationDuration,
                offsetX, offsetY);

            //Second animation - Opacity
            if (animateOpacity)
                storyboard.AddOpacityAnimation(element, EnterContentOpacityAnimationDuration,
                    EnterContentOpacityAnimationDelay);

            storyboard.Begin();

            return storyboard;
        }

        #region EnterPage animation metrics
        private static readonly TimeSpan EnterPageOpacityDelay = new TimeSpan(0);
        private static readonly TimeSpan EnterPageOpacityDuration = new TimeSpan(0, 0, 0, 0, 170);
        #endregion
        public static Storyboard EnterPage(FrameworkElement element, int offsetX, int offsetY)
        {
            var storyboard = new Storyboard();

            element.RenderTransform = new TranslateTransform
            {
                X = offsetX,
                Y = offsetY
            };

            //First animation - Translation
            storyboard.AddTranslateAnimations(element.RenderTransform, EnterContentTranslateAnimationDuration,
                offsetX, offsetY);

            //Second animation - Opacity
            storyboard.AddOpacityAnimation(element, EnterPageOpacityDuration, EnterPageOpacityDelay);

            storyboard.Begin();

            return storyboard;
        }

        #region PeekAnimation metrics
        private static readonly TimeSpan PeekAnimationDuration = new TimeSpan(0, 0, 0, 0, 2000);
        #endregion
        public static Storyboard PeekAnimation(FrameworkElement element, int offsetX, int offsetY)
        {
            var storyboard = new Storyboard();

            element.RenderTransform = new TranslateTransform
            {
                X = offsetX,
                Y = offsetY
            };

            storyboard.AddTranslateAnimations(element.RenderTransform, PeekAnimationDuration,
                offsetX, offsetY);

            storyboard.Begin();

            return storyboard;
        }

        #region ShowEdgeUI metrics
        private static readonly TimeSpan ShowEdgeUIDuration = new TimeSpan(0, 0, 0, 0, 367);
        #endregion
        public static Storyboard ShowEdgeUI(FrameworkElement element, int offsetX, int offsetY)
        {
            var storyboard = new Storyboard();

            element.RenderTransform = new TranslateTransform
            {
                X = offsetX,
                Y = offsetY
            };

            storyboard.AddTranslateAnimations(element.RenderTransform, ShowEdgeUIDuration,
                offsetX, offsetY);

            storyboard.Begin();

            return storyboard;
        }

        #region ShowPanel metrics
        private static readonly TimeSpan ShowPanelDuration = new TimeSpan(0, 0, 0, 0, 550);
        #endregion
        public static Storyboard ShowPanel(FrameworkElement element, int offsetX, int offsetY)
        {
            var storyboard = new Storyboard();

            element.RenderTransform = new TranslateTransform
            {
                X = offsetX,
                Y = offsetY
            };

            storyboard.AddTranslateAnimations(element.RenderTransform, ShowPanelDuration,
                offsetX, offsetY);

            storyboard.Begin();

            return storyboard;
        }

        #region UpdateBadge metrics
        private static readonly TimeSpan UpdateBadgeOpacityDelay = new TimeSpan(0);
        private static readonly TimeSpan UpdateBadgeOpacityDuration = new TimeSpan(0, 0, 0, 0, 367);
        private static readonly TimeSpan UpdateBadgeTranslateAnimationDuration = new TimeSpan(0, 0, 0, 0, 1333);
        #endregion
        public static Storyboard UpdateBadge(FrameworkElement element, int offsetX, int offsetY)
        {
            var storyboard = new Storyboard();

            element.RenderTransform = new TranslateTransform
            {
                X = offsetX,
                Y = offsetY
            };

            //First animation - Translation
            storyboard.AddTranslateAnimations(element.RenderTransform, UpdateBadgeTranslateAnimationDuration,
                offsetX, offsetY);

            //Second animation - Opacity
            storyboard.AddOpacityAnimation(element, UpdateBadgeOpacityDuration, UpdateBadgeOpacityDelay);

            storyboard.Begin();

            return storyboard;
        }

        #region Animation constructor methods

        public static void AddTranslateAnimations(this Storyboard storyboard, DependencyObject target, TimeSpan duration, int offsetX, int offsetY)
        {
            if (offsetX != 0)
            {
                var translationAnimationX = CreateEnterContentTranslateAnimationWithKeyFrames(duration);
                Storyboard.SetTarget(translationAnimationX, target);
                Storyboard.SetTargetProperty(translationAnimationX, "X");
                storyboard.Children.Add(translationAnimationX);
            }
            if (offsetY != 0)
            {
                var translationAnimationY = CreateEnterContentTranslateAnimationWithKeyFrames(duration);
                Storyboard.SetTarget(translationAnimationY, target);
                Storyboard.SetTargetProperty(translationAnimationY, "Y");
                storyboard.Children.Add(translationAnimationY);
            }
        }

        public static void AddOpacityAnimation(this Storyboard storyboard, FrameworkElement element, TimeSpan duration, TimeSpan delay)
        {
            var opacityAnimation = new DoubleAnimationUsingKeyFrames
            {
                EnableDependentAnimation = true,
                Duration = duration,
                BeginTime = delay
            };
            opacityAnimation.KeyFrames.Add(new SplineDoubleKeyFrame
            {
                KeySpline = new KeySpline
                {
                    ControlPoint1 = new Point(
                        TransitionBezierConrolPoint1X,
                        TransitionBezierConrolPoint1Y),
                    ControlPoint2 = new Point(
                        TransitionBezierConrolPoint2X,
                        TransitionBezierConrolPoint2Y)
                },
                KeyTime = KeyTime.FromTimeSpan(duration),
                Value = 1
            });
            Storyboard.SetTarget(opacityAnimation, element);
            Storyboard.SetTargetProperty(opacityAnimation, "Opacity");
            storyboard.Children.Add(opacityAnimation);

            element.Opacity = 0;
        }

        private static DoubleAnimationUsingKeyFrames CreateEnterContentTranslateAnimationWithKeyFrames(TimeSpan duration)
        {
            var translationAnimation = new DoubleAnimationUsingKeyFrames
            {
                EnableDependentAnimation = true,
                Duration = new Duration(duration)
            };
            translationAnimation.KeyFrames.Add(new SplineDoubleKeyFrame
            {
                KeySpline = new KeySpline
                {
                    ControlPoint1 = new Point(
                        TransitionBezierConrolPoint1X,
                        TransitionBezierConrolPoint1Y),
                    ControlPoint2 = new Point(
                        TransitionBezierConrolPoint2X,
                        TransitionBezierConrolPoint2Y)
                },
                KeyTime = KeyTime.FromTimeSpan(duration),
                Value = 0
            });

            return translationAnimation;
        }

        #endregion

        #region Animation bezier control points //same for all animations

        private const double TransitionBezierConrolPoint1X = 0.10000000149011612;
        private const double TransitionBezierConrolPoint1Y = 0.89999997615811421;
        private const double TransitionBezierConrolPoint2X = 0.20000000298023224;
        private const double TransitionBezierConrolPoint2Y = 1;

        #endregion
    }
}
