using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "CardData", menuName = "Card", order = 1)]
public class CardData : ScriptableObject {

[SerializeField]
	public TaskType cardType;
	[SerializeField]
	public int score;
	[SerializeField]
	public List<BrickColor> colors;

	private const int defaultGridSize = 3;
	[SerializeField]
    [Range(1, 5)]
    private int gridSize = defaultGridSize;
	public int GridSize { get { return gridSize; } }
	[SerializeField]
    private CellRow[] cells = new CellRow[defaultGridSize];
	public bool[,] GetCells()
    {
        bool[,] ret = new bool[gridSize, gridSize];

        for (int i = 0; i < gridSize; i++)
        {
            for (int j = 0; j < gridSize; j++)
            {
                ret[i, j] = cells[i].Row[j];
            }
        }

        return ret;
    }

	[System.Serializable]
    public class CellRow
    {
        [SerializeField]
        private bool[] row = new bool[defaultGridSize];

        public bool[] Row { get { return row; } }
    }

}
