using System;
using System.Drawing;
using System.Windows.Forms;
using System.Collections.Generic;
using Nanook.QueenBee.Parser;
using System.Drawing.Imaging;

public partial class qdesign : Form
{
	public Zones z;
	public List<Element> elements;
	public Element clipboard = null;
	public ImageList elist_images;
	public qdesign()
	{
		InitializeComponent();
		z = new Zones("global.pak.xen", false);
		elements = new List<Element>();
		elist_images = new ImageList();
		foreach (Zones.RawImg i in z.images) // :/
			elist_images.Images.Add(i.NameStr, i.Image);
		foreach (Zones.RawImg g in z.gfx)
			elist_images.Images.Add("mat " + g.NameStr, g.Image);
		elementlist.SmallImageList = elist_images;
		((ToolStripDropDownMenu)this.menuFile.DropDown).ShowImageMargin = false;
	}

	// https://stackoverflow.com/a/12210258
	// stupidly dumb
	void add(Bitmap dst, Bitmap src)
	{
		unsafe
		{
			BitmapData bmpDataA = dst.LockBits(new Rectangle(0, 0, dst.Width, dst.Height), ImageLockMode.ReadOnly, dst.PixelFormat);
			BitmapData bmpDataB = src.LockBits(new Rectangle(0, 0, dst.Width, dst.Height), ImageLockMode.ReadOnly, dst.PixelFormat);
			byte* pBmpA = (byte*)bmpDataA.Scan0.ToPointer();
			byte* pBmpB = (byte*)bmpDataB.Scan0.ToPointer();
			int bytesPerPix = bmpDataA.Stride / dst.Width;
			for (int y = 0; y < dst.Height; y++)
			{
				for (int x = 0; x < dst.Width; x++, pBmpA += bytesPerPix, pBmpB += bytesPerPix)
				{
					*(pBmpA) = (byte)Math.Min(*pBmpA + *pBmpB, 255); // R
					*(pBmpA + 1) = (byte)Math.Min(*(pBmpA + 1) + *(pBmpB + 1), 255); // G
					*(pBmpA + 2) = (byte)Math.Min(*(pBmpA + 2) + *(pBmpB + 2), 255); // B
				}
			}
			dst.UnlockBits(bmpDataA);
			src.UnlockBits(bmpDataB);
		}
	}
	void mul(Bitmap dst, Bitmap src)
	{
		unsafe
		{
			BitmapData bmpDataA = dst.LockBits(new Rectangle(0, 0, dst.Width, dst.Height), ImageLockMode.ReadOnly, dst.PixelFormat);
			BitmapData bmpDataB = src.LockBits(new Rectangle(0, 0, dst.Width, dst.Height), ImageLockMode.ReadOnly, dst.PixelFormat);
			byte* pBmpA = (byte*)bmpDataA.Scan0.ToPointer();
			byte* pBmpB = (byte*)bmpDataB.Scan0.ToPointer();
			int bytesPerPix = bmpDataA.Stride / dst.Width;
			for (int y = 0; y < dst.Height; y++)
			{
				for (int x = 0; x < dst.Width; x++, pBmpA += bytesPerPix, pBmpB += bytesPerPix)
				{
					*pBmpA = (byte)(*(pBmpA) * ((float)*(pBmpB) / 255));
					*(pBmpA + 1) = (byte)(*(pBmpA + 1) * ((float)*(pBmpB + 1) / 255));
					*(pBmpA + 2) = (byte)(*(pBmpA + 2) * ((float)*(pBmpB + 2) / 255));
				}
			}
			dst.UnlockBits(bmpDataA);
			src.UnlockBits(bmpDataB);
		}
	}
	void mul(Bitmap dst, Color col)
	{
		if (col == Color.White)
			return;
		unsafe
		{
			BitmapData bmpDataA = dst.LockBits(new Rectangle(0, 0, dst.Width, dst.Height), ImageLockMode.ReadOnly, dst.PixelFormat);
			byte* pBmpA = (byte*)bmpDataA.Scan0.ToPointer();
			int bytesPerPix = bmpDataA.Stride / dst.Width;
			for (int y = 0; y < dst.Height; y++)
			{
				for (int x = 0; x < dst.Width; x++, pBmpA += bytesPerPix)
				{
					*pBmpA = (byte)(*pBmpA * ((float)col.B / 255));
					*(pBmpA + 1) = (byte)(*(pBmpA + 1) * ((float)col.G / 255));
					*(pBmpA + 2) = (byte)(*(pBmpA + 2) * ((float)col.R / 255));
					*(pBmpA + 3) = (byte)(*(pBmpA + 3) * ((float)col.A / 255));
				}
			}
			dst.UnlockBits(bmpDataA);
		}
	}
	//https://stackoverflow.com/a/12025915
	Bitmap RotateImage(Bitmap bmp, float angle)
	{
		Bitmap rotatedImage = new Bitmap(bmp.Width, bmp.Height);
		rotatedImage.SetResolution(bmp.HorizontalResolution, bmp.VerticalResolution);

		using (Graphics g = Graphics.FromImage(rotatedImage))
		{
			// Set the rotation point to the center in the matrix
			g.TranslateTransform(bmp.Width / 2, bmp.Height / 2);
			// Rotate
			g.RotateTransform(angle);
			// Restore rotation point in the matrix
			g.TranslateTransform(-bmp.Width / 2, -bmp.Height / 2);
			// Draw the image on the bitmap
			g.DrawImage(bmp, new Point(0, 0));
		}

		return rotatedImage;
	}

	public void redrawScreen()
	{
		if (elementdraw.Image != null)
			elementdraw.Image.Dispose();
		elementlist.Items.Clear();
		Bitmap screen = new Bitmap(1280, 720);
		Graphics g = Graphics.FromImage(screen);
		g.Clear(Color.Black);
		Font errfont = new Font("Microsoft Sans Serif", 20f, FontStyle.Bold, GraphicsUnit.Pixel);
		List<Element> z_sorted = new List<Element>(elements);
		z_sorted.Sort(delegate(Element c1, Element c2) { return c1.z.CompareTo(c2.z); });
		foreach (Element e in z_sorted)
			// cheap maybe, but hopefully it's just the
			// basic class items copied and not stuff like images or whatever
		{
			ListViewItem li = new ListViewItem();
			li.Text = e.IDStr;
			if (e is Element.SpriteElement)
			{
				Element.SpriteElement ee = (e as Element.SpriteElement);
				if (ee.alpha > 0 && ee.rgba.A > 0)
				{
					try {
						Zones.RawImg img;
						Bitmap sprite;
						if (!ee.sprite_type)
						{
							li.ImageKey = ee.texture.Text;
							img = z.GetImage(ee.texture);
						}
						else
						{
							li.ImageKey = "mat " + ee.material.Text;
							int ii = z.gfx.IndexOf(ee.material.Crc);
							if (ii == -1)
								continue;
							img = z.gfx[ii];
						}
						sprite = (Bitmap)img.Image.Clone();
						Color alpha2 = ee.rgba;
						if (ee.alpha != 1f)
							alpha2 = Color.FromArgb((byte)(ee.rgba.A * ee.alpha), ee.rgba.R, ee.rgba.G, ee.rgba.B);
						if (alpha2 != Color.White)
							mul(sprite, alpha2);
						SizeF rendersize = Element.SpriteElement.size(ee, img);
						PointF just = Element.justify(ee, rendersize);
						g.DrawImage(sprite, just.X, just.Y, rendersize.Width, rendersize.Height);
						sprite.Dispose();
					}
					catch (Exception ex) {
						g.DrawString(ex.ToString(), errfont, Brushes.Red, ee.pos.X, ee.pos.Y);
					}
				}
			}
			else if (e is Element.TextElement)
			{
				Element.TextElement ee = (e as Element.TextElement);
				if (ee.alpha > 0 && ee.rgba.A > 0)
				{
					try {
						Zones.Font ff = z.GetFont(ee.font);
						if (ff != null)
						{
							//Console.WriteLine(ff.texture.NameStr);
							float xx = 0, yy = ff.height;
							float spacing = 1 + (1/8) + ((ee.font_spacing + ff.spacing) / 8);
							SizeF size = Element.TextElement.textsize(ff, ee.text, spacing);
							Bitmap rendered_text = new Bitmap((int)size.Width, (int)size.Height);
							Graphics td = Graphics.FromImage(rendered_text);
							for (int i = 0; i < ee.text.Length; i++)
							{
								Zones.Font.Glyph gg = ff[ee.text[i]];
								RectangleF gr = ff.glyphRect(ee.text[i]);
								if (ee.text[i] != ' ' || ff.glyphblock[' '] != 0)
								{
									//Console.WriteLine(gg.vShift);
									td.DrawImage(ff.texture.Image,
										xx + gg.hShift, yy - gr.Height + gg.vShift, gr, GraphicsUnit.Pixel);
									xx += gr.Width * spacing;
								}
								else
									xx += ff.space_width * spacing;
							}
							size.Width *= ee.scale.Width;
							size.Height *= ee.scale.Height;
							PointF just = Element.justify(ee, size);
							//SizeF scaled = Element.SpriteElement.size(ee, ff.texture);
							//g.DrawRectangle(new Pen(Color.Red), 
								//just.X, just.Y, size.Width, size.Height);
							//td.DrawLine(new Pen(Color.Red), 0, ff.baseline, size.Width, ff.baseline);
							if (ee.shadow_rgba != Color.Transparent)
							{
								Bitmap shadow = (Bitmap)rendered_text.Clone();
								mul(shadow, ee.shadow_rgba);
								g.DrawImage(shadow,
									just.X + (ee.shadow_offs.X * ee.scale.Width),
									just.Y + (ee.shadow_offs.Y * ee.scale.Height) + ff.baseline, size.Width, size.Height);
							}
							Color alpha2 = ee.rgba;
							if (ee.alpha != 1f)
								alpha2 = Color.FromArgb((byte)(ee.rgba.A * ee.alpha), ee.rgba.R, ee.rgba.G, ee.rgba.B);
							if (alpha2 != Color.White)
								mul(rendered_text, alpha2);
							g.DrawImage(rendered_text,
								just.X, just.Y + ff.baseline, size.Width, size.Height);
							rendered_text.Dispose();
						}
						else
							g.DrawString("Font cannot be found.", errfont, Brushes.Red, ee.pos.X, ee.pos.Y);
					}
					catch (Exception ex) {
						g.DrawString(ex.ToString(), errfont, Brushes.Red, ee.pos.X, ee.pos.Y);
					}
				}
			}
			elementlist.Items.Add(li);
		}
		g.Dispose();
		elementdraw.Image = screen;
		//elementdraw.Image = new Bitmap(screen, new Size(1280, 720));
		//screen.Dispose();
	}

	void layout_mmove(object sender, MouseEventArgs e)
	{
		
	}

	void selecteditem(object sender, EventArgs e)
	{
		toolbar.Enabled = elementlist.SelectedIndices.Count > 0;
		if (toolbar.Enabled) // lol
			elementprops.SelectedObject = elements[elementlist.SelectedIndices[0]];
		else
			elementprops.SelectedObject = null;
	}
	
	void selitemchange(object sender, ListViewItemSelectionChangedEventArgs e)
	{
		selecteditem(null,null);
	}

	void updateProps(object s, PropertyValueChangedEventArgs e)
	{
		redrawScreen();
	}
	
	float lastz()
	{
		float lastzz = 0;
		foreach(Element e in elements)
			lastzz = Math.Max(lastzz, e.z); // ez
		return lastzz;
	}
	void AddElement(Element ee)
	{
		ee.z = lastz() + 1;
		elements.Add(ee);
		redrawScreen();
	}
	
	void addSprite(object sender, EventArgs e)
	{
		AddElement(new Element.SpriteElement());
	}
	void addText(object sender, EventArgs e)
	{
		AddElement(new Element.TextElement());
	}
	
	void gotz(object sender, System.ComponentModel.CancelEventArgs e)
	{
		z.Dispose();
		z = new Zones(zonesDiag.FileName, true);
		redrawScreen();
	}
	
	void clickOpenZ(object sender, EventArgs e)
	{
		zonesDiag.ShowDialog();
	}
	
	void dele(object sender, EventArgs e)
	{
		if (elementlist.SelectedIndices.Count > 0)
		{
			elements.RemoveAt(elementlist.SelectedIndices[0]);
			redrawScreen();
		}
	}
	// uhhh
	void cute(object sender, EventArgs e)
	{
		if (elementlist.SelectedIndices.Count > 0)
		{
			clipboard = elements[elementlist.SelectedIndices[0]];
			dele(null, null);
		}
	}
	
	void copye(object sender, EventArgs e)
	{
		clipboard = (Element)elements[elementlist.SelectedIndices[0]].Clone();
		menuPaste.Enabled = clipboard != null;
		redrawScreen();
	}
	
	void pastee(object sender, EventArgs e)
	{
		clipboard.pos.X += 10;
		clipboard.pos.Y += 10;
		clipboard.z++;
		elements.Add((Element)clipboard.Clone());
		redrawScreen();
	}
}
