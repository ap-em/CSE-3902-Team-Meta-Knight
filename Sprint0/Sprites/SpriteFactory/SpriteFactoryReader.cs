using System;

public class SpriteFactoryReader
{
	private readonly string _dataSheet;
	public SpriteFactoryReader(String dataSheet)
	{
		_dataSheet = dataSheet; 
	}
	public SpriteFactoryReader CreateFactoryReader()
    {
		return new SpriteFactoryReader(_dataSheet);
    }
}
