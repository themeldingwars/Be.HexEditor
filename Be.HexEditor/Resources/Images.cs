// ---------------------------------------------------------
// Windows Forms CommandBar Control
// Copyright (C) 2001-2003 Lutz Roeder. All rights reserved.
// http://www.aisto.com/roeder
// roeder@aisto.com
// ---------------------------------------------------------
/////////////////////////////////////////////////////////////////////
/////////////////////////////////////////////////////////////////////
//
// Copyright (c) 2004, O&O Services GmbH.
// Am Borsigturm 48
// 13507 Berlin
// GERMANY
// Tel: +49 30 43 03 43-03, Fax: +49 30 43 03 43-99
// E-mail: info@oo-services.com
// Web: http://www.oo-services.com
// All rights reserved.
//
// Redistribution and use in source and binary forms, with or without 
// modification, are permitted provided that the following conditions are met:
//
// * Redistributions of source code must retain the above copyright notice, 
//   this list of conditions and the following disclaimer.
// * Redistributions in binary form must reproduce the above copyright notice, 
//   this list of conditions and the following disclaimer in the documentation 
//   and/or other materials provided with the distribution.
// * Neither the name of O&O Services GmbH nor the names of its contributors 
//   may be used to endorse or promote products derived from this software
//   without specific prior written permission.
//
// THIS SOFTWARE IS PROVIDED BY THE COPYRIGHT HOLDERS AND CONTRIBUTORS "AS IS" 
// AND ANY EXPRESS OR IMPLIED WARRANTIES, INCLUDING, BUT NOT LIMITED TO, 
// THE IMPLIED WARRANTIES OF MERCHANTABILITY AND FITNESS FOR A PARTICULAR
// PURPOSE ARE DISCLAIMED. IN NO EVENT SHALL THE COPYRIGHT OWNER OR 
// CONTRIBUTORS BE LIABLE FOR ANY DIRECT, INDIRECT, INCIDENTAL, SPECIAL, 
// EXEMPLARY, OR CONSEQUENTIAL DAMAGES (INCLUDING, BUT NOT LIMITED TO, 
// PROCUREMENT OF SUBSTITUTE GOODS OR SERVICES; LOSS OF USE, DATA, OR PROFITS; 
// OR BUSINESS INTERRUPTION) HOWEVER CAUSED AND ON ANY THEORY OF LIABILITY, 
// WHETHER IN CONTRACT, STRICT LIABILITY, OR TORT (INCLUDING NEGLIGENCE OR 
// OTHERWISE) ARISING IN ANY WAY OUT OF THE USE OF THIS SOFTWARE, 
// EVEN IF ADVISED OF THE POSSIBILITY OF SUCH DAMAGE.
//
///////////////////////////////////////////////////////////////////////////
//////////////////////////////////////////////////////////////////////////////
// Sources Code by...
//
// Michael Ganss - Images on XP-Style Buttons
// http://www.codeproject.com/cs/miscctrl/MgXpImageButton.asp
// BE: I used the ListView alpha-channel workaround
//
// Lutz Roeder - CommandBar for .NET
// http://www.aisto.com/roeder/dotnet/
// BE: I used the images
//
// Thank you very much!
//


using System;
using System.Drawing;
using System.Drawing.Imaging;
using System.Windows.Forms;
namespace Be.HexEditor.Resources
{
	class Images
	{
		#region Lutz Roeder´s source code
		private static Bitmap[] images = null;
	
		// ImageList.Images[int index] does not preserve alpha channel.
		static Images()
		{
			// TODO alpha channel PNG loader is not working on .NET Service RC1
			
			Bitmap bitmap = new Bitmap(
				System.Reflection.Assembly.GetExecutingAssembly().GetManifestResourceStream(
				"Be.HexEditor.Resources.ImageList16.png"));
			int count = (int) (bitmap.Width / bitmap.Height);
			images = new Bitmap[count];
			Rectangle rectangle = new Rectangle(0, 0, bitmap.Height, bitmap.Height);
			for (int i = 0; i < count; i++)
			{
				images[i] = bitmap.Clone(rectangle, bitmap.PixelFormat);
				rectangle.X += bitmap.Height;
			}
		}	

		public static Image New               { get { return images[0];  } }
		public static Image Open              { get { return images[1];  } }
		public static Image Save              { get { return images[2];  } }
		public static Image Cut               { get { return images[3];  } }
		public static Image Copy              { get { return images[4];  } }
		public static Image Paste             { get { return images[5];  } }
		public static Image Delete            { get { return images[6];  } }
		public static Image Properties        { get { return images[7];  } }
		public static Image Undo              { get { return images[8];  } }
		public static Image Redo              { get { return images[9];  } }
		public static Image Preview           { get { return images[10]; } }
		public static Image Print             { get { return images[11]; } }
		public static Image Search            { get { return images[12]; } }
		public static Image ReSearch          { get { return images[13]; } }
		public static Image Help              { get { return images[14]; } }
		public static Image ZoomIn            { get { return images[15]; } }
		public static Image ZoomOut           { get { return images[16]; } }
		public static Image Back              { get { return images[17]; } }
		public static Image Forward           { get { return images[18]; } }
		public static Image Favorites         { get { return images[19]; } }
		public static Image AddToFavorites    { get { return images[20]; } }
		public static Image Stop              { get { return images[21]; } }
		public static Image Refresh           { get { return images[22]; } }
		public static Image Home              { get { return images[23]; } }
		public static Image Edit              { get { return images[24]; } }
		public static Image Tools             { get { return images[25]; } }
		public static Image Tiles             { get { return images[26]; } }
		public static Image Icons             { get { return images[27]; } }
		public static Image List              { get { return images[28]; } }
		public static Image Details           { get { return images[29]; } }
		public static Image Pane              { get { return images[30]; } }
		public static Image Culture           { get { return images[31]; } }
		public static Image Languages         { get { return images[32]; } }
		public static Image History           { get { return images[33]; } }
		public static Image Mail              { get { return images[34]; } }
		public static Image Parent            { get { return images[35]; } }
		public static Image FolderProperties  { get { return images[36]; } }
		#endregion

		public static ImageList GenerateImageList()
		{
			return GenerateImageList(images);
		}
		
		#region Michael Ganss´s source code
		public static ImageList GenerateImageList(Bitmap[] images)
		{
			ImageList il = new ImageList();
			il.ColorDepth = ColorDepth.Depth32Bit;

			if (images.Length > 0)
			{
				il.ImageSize = new Size(images[0].Width, images[0].Height);

				foreach (Bitmap image in images)
				{
					il.Images.Add(image);
					Bitmap bm = (Bitmap)il.Images[il.Images.Count - 1];

					// copy pixel data from original Bitmap into ImageList
					// to work around a bug in ImageList:
					// adding an image to an ImageList destroys the alpha channel

					//					for (int x = 0; x < bm.Width; x++)
					//					{
					//						for (int y = 0; y < bm.Height; y++)
					//						{
					//							bm.SetPixel(x, y, image.GetPixel(x, y));
					//						}
					//					}

					// code below contributed by Richard Deeming
					// requires /unsafe compiler flag
					// does the same as the code above, albeit a lot faster
					Rectangle rc = new Rectangle(new Point(0, 0), image.Size);
					BitmapData src = image.LockBits(rc, ImageLockMode.ReadOnly, image.PixelFormat);
					BitmapData dst = bm.LockBits(rc, ImageLockMode.WriteOnly, image.PixelFormat);
            
					try
					{
						unsafe
						{
							int* pSrc = (int*)src.Scan0;
							int* pDst = (int*)dst.Scan0;
                    
							for(int row=0; row < bm.Height; row++)
							{
								for(int col=0; col < bm.Width; col++)
								{
									pDst[col] = pSrc[col];
								}
                        
								pSrc += src.Stride >> 2;
								pDst += dst.Stride >> 2;
							}
						}
					}
					finally
					{
						bm.UnlockBits(dst);
						image.UnlockBits(src);
					}
				}
			}

			return il;
		}
		#endregion
	}
}
