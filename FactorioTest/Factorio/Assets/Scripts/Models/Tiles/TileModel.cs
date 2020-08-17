using System.Collections;
using System.Collections.Generic;
using System;
using Assets.Scripts.Enums;
using Assets.Scripts.Models.Buildings;

public class TileModel
{
	public int Row { get; set; }

	public int Col { get; set; }

	public TileType TileType { get; set; }

	public BuildingModel Building { get; set; }

	public TileModel(int row, int col, TileType tileType)
	{
		Row = row;
		Col = col;
		TileType = tileType;
	}
}
