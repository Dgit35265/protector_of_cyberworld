using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapGenerator : MonoBehaviour
{
	private static int[,] mapData = null;
	private GameObject tile = null;
	private GameObject path = null;

	private void Awake()
	{
		tile = Resources.Load("Tile", typeof(GameObject)) as GameObject;
		path = Resources.Load("Path", typeof(GameObject)) as GameObject;
	}

    private void Start()
    {
		LoadMapData();
    }

	private void LoadMapData()
	{
		if (mapData == null)
		{
			TextAsset mapInfo = Resources.Load("MapData", typeof(TextAsset)) as TextAsset;
			string mapText = mapInfo.text;
			Debug.Log(mapText);
			char[] mapChar = mapText.ToCharArray();

			/* convert map data text into int and generate map
			for (int i = 2; i < mapChar[0]; i++)
			{
				for (int j = 0; j < mapChar[1]; j++)
				{
					//Depend on map text
				}
			}
			//*/
		}
		else
			return;
	}


	public static int GetTileType(int x, int y)
	{
		return mapData[x,y];
	}
	public static int GetTileType(float x, float y)
	{
		return mapData[(int)x, (int)y];
	}
	public static int GetTileType(Vector3 position)
	{
		return GetTileType(position.x, position.z);
	}
}