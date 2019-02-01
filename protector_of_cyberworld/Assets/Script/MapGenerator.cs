using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapGenerator : MonoBehaviour
{
	private static int[,] mapData = null;
	private GameObject[] tile = null;

	private void Awake()
	{
		tile = new GameObject[2];
		tile[0] = Resources.Load("Tile", typeof(GameObject)) as GameObject;
		tile[1] = Resources.Load("Path", typeof(GameObject)) as GameObject;
	}

    private void Start()
    {
		LoadMapData();
    }

	private void LoadMapData()
	{
		if (mapData == null)
		{
			TextAsset mapCSV = Resources.Load("MapData", typeof(TextAsset)) as TextAsset;
			string[] column = mapCSV.text.Split('\n');
			string[] row = column[0].Split(',');
			mapData = new int[column.Length,row.Length];

			//* convert map data text into int and generate map
			for (int i = 0; i < column.Length; i++)
			{
				row = column[i].Split(',');
				for (int j = 0; j < row.Length; j++)
				{
					mapData[i, j] = int.Parse(row[j]);
					GameObject temp = (GameObject)Instantiate(tile[mapData[i,j]], new Vector3(j, 0, i), tile[mapData[i,j]].transform.rotation);
					temp.transform.parent = transform;
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