using System;
using System.Collections.Generic;
using System.IO;
using System.Text.Json;

public class SpriteFactoryReader
{
	/*
	private readonly string _dataSheet;
	private int height;
	private int width;
	private int x;
	private int y;
	private String SpriteSheet;
	*/
	private readonly String json;
	private readonly String jsonPropertyname;



	public SpriteFactoryReader(String dataSheet)
	{
		json = dataSheet;

	}

	public SpriteFactoryReader CreateFactoryReader()
    {
		return new SpriteFactoryReader(json);
    }
}
