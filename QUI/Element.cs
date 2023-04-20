using System;
using System.Collections.Generic;
using Nanook.QueenBee.Parser;
using System.Drawing;
using System.ComponentModel;

public abstract class Element : ICloneable
{
	public object Clone()
	{
		return this.MemberwiseClone();
	}
	
	public QbKey parent, id;
	[Category("General"), DisplayName("Color"), Description("Color of the element.")]
	public Color rgba { get; set; }
	[Category("General")]
	public PointF just, pos;
	[Category("General"), DisplayName("Scale"), Description("Scale multiplier that can grow or shrink the display of the element.")]
	public SizeF scale { get; set; }
	[Category("General"), DisplayName("Dimensions"), Description("Dimensions of the element.")]
	public SizeF dims { get; set; }
	[Category("General"), DisplayName("Z Order"), Description("Z order for placing an element on top of, between, or below others.")]
	public float z { get; set; }
	// should change since int and float is allowed
	[Category("General"), DisplayName("Angle"), Description("Rotation of the element in degrees.")]
	public float angle { get; set; }
	[Category("General"), DisplayName("Alpha"), Description("Opacity of the element. (0.0-1.0)")]
	public float alpha { get; set; }
	// indicates pair or single float
	[Browsable(false)]
	public bool scale2d { get { return scale.Width != scale.Height; } }
	[Browsable(false)]
	public bool stretchtype { get { return dims != nodims; } }
	// false = scale
	// true = dims
	[Category("General")]
	public QbItemArray event_handlers;
	
	// forgot i had to do this
	// cringe
	// enjoy the double items
	[Category("General"), Description("Justification of the element.")]
	public SizeF Just { get { return new SizeF(just); } set { just = new PointF(value.Width, value.Height); } }
	[Category("General"), Description("Position of the element..")]
	public SizeF Position { get { return new SizeF(pos); } set { pos = new PointF(value.Width, value.Height); } }
	[Category("General"), DisplayName("Parent"), Description("ID of an inheriting screen element. root_window is the base canvas for which screen elements are created.")]
	public string ParentStr
	{
		get { return Program.GetDebugName(parent); }
		set { parent = QbKey.Create(String2CRC(value)); }
	}
	[Category("General"), DisplayName("Name"), Description("Identifier of the element.")]
	public string IDStr
	{
		get { return Program.GetDebugName(id); }
		set { id = QbKey.Create(String2CRC(value)); }
	}
	private uint String2CRC(string a)
	{
		if (System.Text.RegularExpressions.Regex.IsMatch(a, "^[0-9a-fA-F]{8}$"))
			a = Program.GetDebugName(uint.Parse(a, System.Globalization.NumberStyles.HexNumber));
		QbKey q = QbKey.Create(a);
		try
		{
			Program.DebugNames.Add(q.Crc, q.Text);
		}
		catch { }
		return q.Crc;
	}

	internal readonly SizeF nodims = new SizeF(-1.0f, -1.0f);

	private static float just_base(float x, float y, float z)
	{
		// x = coordinate
		// y = just param
		// z = render size
		return x - ((y + 1) * z / 2);
	}
	public static PointF justify(Element a, SizeF size)
	{
		return new PointF(
			just_base(a.pos.X, a.just.X, size.Width),
			just_base(a.pos.Y, a.just.Y, size.Height));
	}

	public Element()
	{
		parent = QbKey.Create("root_window");
		id = QbKey.Create("new_element");
		rgba = Color.White;
		just = new PointF(-1.0f, -1.0f); // left left (?)
		pos = new PointF(0.0f, 0.0f);
		scale = new SizeF(1.0f, 1.0f);
		dims = nodims;
		z = 0.0f;
		alpha = 1.0f;
		angle = 0.0f; // degrees
		event_handlers = null; // modify later
	}

	public class ContainerElement : Element
	{
		public ContainerElement() : base()
		{
			dims = new SizeF(320.0f, 240.0f);
		}
	}
	public class SpriteElement : Element
	{
		[Category("Sprite"), DisplayName("Texture"), Description("The image to use from the zones' textures.")]
		public string TexStr
		{
			get { return Program.GetDebugName(texture); }
			set { texture = QbKey.Create(String2CRC(value)); }
		}
		[Category("Sprite"), DisplayName("Material"), Description("The material to use from the zones' highway textures. This is different from Texture.")]
		public string MatStr
		{
			get { return Program.GetDebugName(material); }
			set { material = QbKey.Create(String2CRC(value)); }
		}
		public QbKey texture;
		public QbKey material;
		[Category("Sprite"), DisplayName("Blend"), Description("The blending mode to use.")]
		public Zones.Scene.Blend blend { get; set; }
		[Browsable(false)]
		public bool sprite_type
		{
			get
			{
				return material.Crc != 0x806FFF30;
				// false = texture
				// true = material
			}
			set
			{
				material = QbKey.Create(0x151EE874); // sys_gem2d_green_sys_gem2d_green
				if (value)
					material = QbKey.Create(0x806FFF30);
			}
		}

		// render dims
		public static SizeF size(Element a, Zones.RawImg tex)
		{
			float w, h;
			if (a.stretchtype)
			{
				w = (a.dims.Width * (tex.widthScale / a.dims.Width));
				h = (a.dims.Height * (tex.heightScale / a.dims.Height));
			}
			else
			{
				w = (a.scale.Width * tex.widthScale);
				h = (a.scale.Height * tex.heightScale);
			}
			return new SizeF(w, h);
		}

		public SpriteElement() : base()
		{
			texture = QbKey.Create(0xCBBB28DC);
			material = QbKey.Create("none");
			blend = Zones.Scene.Blend.Blend;
		}
	}
	public class TextElement : Element
	{
		public QbKey font;
		[Category("Text"), DisplayName("Text"), Description("The text display.")]
		public string text { get; set; }
		[Browsable(false)]
		public PointF shadow_offs { get; set; }
		[Category("Text"), DisplayName("Shadow offset"), Description("Shadow position relevant to the element.")]
		public SizeF hatethis { get { return new SizeF(shadow_offs); } set { shadow_offs = new PointF(value.Width, value.Height); } }
		[Category("Text"), DisplayName("Shadow color"), Description("The color of the shadow.")]
		public Color shadow_rgba { get; set; }
		[Browsable(false)]
		public bool shadow { get { return shadow_rgba != Color.Transparent; } }
		[Category("Text"), DisplayName("Font"), Description("The font to display. Must be an existing one in the currently loaded zones.")]
		public string FontStr
		{
			get { return Program.GetDebugName(font); }
			set { font = QbKey.Create(String2CRC(value)); }
		}
		[Category("Text"), DisplayName("Spacing"), Description("Spacing of letters and symbols.")]
		public float font_spacing { get; set; }
		// rendered text size
		public static SizeF textsize(Zones.Font ff, string text, float spacing)
		{
			float w = 0, h = ff.height;
			for (int i = 0; i < text.Length; i++)
			{
				RectangleF gp = ff.glyphRect(text[i]);
				if (text[i] != ' ' || ff.glyphblock[' '] != 0)
				{
					w += gp.Width * spacing;
					h = Math.Max(h, gp.Height + ff[text[i]].vShift);
				}
				else
					w += ff.space_width * spacing;
			}
			return new SizeF(w, h + 20 /*??????*/);
		}

		public TextElement() : base()
		{
			text = "AaBbCcDdEeFf";
			font = QbKey.Create("text_a4");
			shadow_offs = new PointF(0.0f, 0.0f);
			shadow_rgba = Color.Transparent;
		}
	}
}
