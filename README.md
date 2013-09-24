Animations-cs
=============

Easy-to-use Windows 8 system animations for C#. Run animations from C# code with one line of code, like WinJS Animations.

Windows 8 XAML are confusing, you can't run animation from code when you update UI without pain.

Animation names are same as in WinJS. Preview animations on http://msdn.microsoft.com/en-us/library/windows/apps/hh465165.aspx

Animations are exactly same, with exact bezier timeline points and durations, GPU-accelerated, just like it needs to be. Animations are created via Storyboard.

Install
=============

Just place Animation.cs in your project or install via nuget 

<code>PM> Install-Package Animations-CS</code>

How to use:
=============

Animations.EnterContent(FrameworkElement element, int offsetX, int offsetY);

Animations.EnterContent(FrameworkElement element, int offsetX, int offsetY, bool animateOpacity); //overloaded animation to do animation without opacity

Animations.EnterPage(FrameworkElement element, int offsetX, int offsetY);

Animations.PeekAnimation(FrameworkElement element, int offsetX, int offsetY);

Animations.ShowEdgeUI(FrameworkElement element, int offsetX, int offsetY);

Animations.ShowPanel(FrameworkElement element, int offsetX, int offsetY);

Animations.UpdateBadge(FrameworkElement element, int offsetX, int offsetY);

Methods return animations’ Storyboard, but the animation is already began.
