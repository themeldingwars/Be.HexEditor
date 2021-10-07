using System;
using System.Drawing;
using System.Runtime.InteropServices;

namespace Be.Windows.Forms
{
	internal sealed class NativeMethods
	{
		static NativeMethods() {}

		// Border style definitions
		public const int WS_BORDER = 0x800000;		// FixedSingle
		public const int WS_EX_CLIENTEDGE = 0x200;	// Fixed3D

		// Caret definitions
		[DllImport("user32.dll", SetLastError=true)]
		public static extern bool CreateCaret(IntPtr hWnd, IntPtr hBitmap, int nWidth, int nHeight);

		[DllImport("user32.dll", SetLastError=true)]
		public static extern bool ShowCaret(IntPtr hWnd);

		[DllImport("user32.dll", SetLastError=true)]
		public static extern bool DestroyCaret();

		[DllImport("user32.dll", SetLastError=true)]
		public static extern bool SetCaretPos(int X, int Y);

		// Key definitions
		public const int WM_KEYDOWN = 0x100;
		public const int WM_KEYUP = 0x101;
		public const int WM_CHAR = 0x102;

		// Detecting visual styles enabled
		[StructLayout(LayoutKind.Sequential)]
		public struct DLLVersionInfo
		{
			public int cbSize;
			public int dwMajorVersion;
			public int dwMinorVersion;
			public int dwBuildNumber;
			public int dwPlatformID;
		}

		[DllImport("UxTheme.dll", CharSet=CharSet.Auto)]
		public static extern bool IsAppThemed();

		[DllImport("UxTheme.dll", CharSet=CharSet.Auto)]
		public static extern bool IsThemeActive();

		[DllImport("comctl32.dll", CharSet=CharSet.Auto)]
		public static extern int DllGetVersion(ref DLLVersionInfo version);

		// Draw background with themes

		[DllImport("uxtheme.dll", ExactSpelling=true, CharSet=CharSet.Unicode)]
		public static extern IntPtr OpenThemeData(IntPtr hWnd, String classList);

		[DllImport("uxtheme.dll", ExactSpelling=true)]
		public extern static Int32 CloseThemeData(IntPtr hTheme);

		[DllImport("uxtheme", ExactSpelling=true)]
		public extern static Int32 DrawThemeBackground(IntPtr hTheme, IntPtr hdc, int iPartId,
			int iStateId, ref RECT pRect, IntPtr pClipRect);

		public const int EP_EDITTEXT = 1;
		public const int ETS_DISABLED = 4;
		public const int ETS_NORMAL = 1;
		public const int ETS_READONLY = 6;

		#region RECT struct
		[Serializable, StructLayout(LayoutKind.Sequential)]
		public struct RECT 
		{
			public int Left;
			public int Top;
			public int Right;
			public int Bottom;

			public RECT(int left_, int top_, int right_, int bottom_) 
			{
				Left = left_;
				Top = top_;
				Right = right_;
				Bottom = bottom_;
			}

			public int Height { get { return Bottom - Top + 1; } }
			public int Width { get { return Right - Left + 1; } }
			public Size Size { get { return new Size(Width, Height); } }

			public Point Location { get { return new Point(Left, Top); } }

			// Handy method for converting to a System.Drawing.Rectangle
			public Rectangle ToRectangle() 
			{ return Rectangle.FromLTRB(Left, Top, Right, Bottom); }

			public static RECT FromRectangle(Rectangle rectangle) 
			{
				return new RECT(rectangle.Left, rectangle.Top, rectangle.Right, rectangle.Bottom);
			}

			public override int GetHashCode() 
			{
				return Left ^ ((Top << 13) | (Top >> 0x13))
					^ ((Width << 0x1a) | (Width >> 6))
					^ ((Height << 7) | (Height >> 0x19));
			}

			#region Operator overloads

			public static implicit operator Rectangle( RECT rect ) 
			{
				return Rectangle.FromLTRB(rect.Left, rect.Top, rect.Right, rect.Bottom);
			}

			public static implicit operator RECT( Rectangle rect ) 
			{
				return new RECT(rect.Left, rect.Top, rect.Right, rect.Bottom);
			}

			#endregion
		}
		#endregion
	}
}
