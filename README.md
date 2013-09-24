Animations-cs
=============

Easy-to-use Windows 8 system animations for C#. Run animations from C# code with one line of code, like WinJS Animations.

Animation names are same as in WinJS. Preview animations on http://msdn.microsoft.com/en-us/library/windows/apps/hh465165.aspx

Install
=============

Just place Animation.cs in your project or install via nuget 

<code>PM> Install-Package Animations-CS</code>

How to use:
=============

Animations.EnterContent(FrameworkElement element, int offsetX, int offsetY);

Animations.EnterPage(FrameworkElement element, int offsetX, int offsetY);

Animations.PeekAnimation(FrameworkElement element, int offsetX, int offsetY);

Animations.ShowEdgeUI(FrameworkElement element, int offsetX, int offsetY);

Animations.ShowPanel(FrameworkElement element, int offsetX, int offsetY);

Animations.UpdateBadge(FrameworkElement element, int offsetX, int offsetY);

Methods return animations’ Storyboard, but the animation is already began.
