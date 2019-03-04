using System.Collections.Generic;
using UnityEngine;

public class TaskCardGenerator : MonoBehaviour
{

    public CardData Data;

    public List<Texture> Scores;

    private MeshRenderer[,] tiles;

    private MeshRenderer[] requirements;

    private MeshRenderer score;

    private MaterialPropertyBlock propBlock;

    // Use this for initialization
    void Start()
    {
        Data.colors.Sort();
        propBlock = new MaterialPropertyBlock();

        tiles = new MeshRenderer[3, 3];
        for (int i = 0; i < 3; ++i)
            for (int j = 0; j < 3; ++j)
            {
                tiles[i, j] = transform.GetChild(0).Find("Tile(" + i + "," + j + ")").GetComponent<MeshRenderer>();
                tiles[i, j].GetPropertyBlock(propBlock);
                propBlock.SetColor("_Color", Data.GetCells()[i, j] ? Color.gray : Color.white);
                tiles[i, j].SetPropertyBlock(propBlock);
            }

        requirements = new MeshRenderer[4];

        for (int i = 0; i < 4; ++i)
        {
            requirements[i] = transform.GetChild(0).Find("Requirement(" + i + ")").GetComponent<MeshRenderer>();
            if (i >= Data.colors.Count)
            {
                requirements[i].gameObject.SetActive(false);
                continue;
            }
            requirements[i].GetPropertyBlock(propBlock);
            Color color = Color.white;
            switch (Data.colors[i])
            {
                case BrickColor.Red:
                    color = Color.red;
                    break;
                case BrickColor.Blue:
                    color = Color.blue;
                    break;
                case BrickColor.Yellow:
                    color = Color.yellow;
                    break;
            }
            propBlock.SetColor("_Color", color);
            requirements[i].SetPropertyBlock(propBlock);
        }
        switch (Data.colors.Count)
        {
            case 2:
                requirements[0].transform.localPosition = new Vector3(requirements[0].transform.localPosition.x,
                    (requirements[0].transform.localPosition.y + requirements[2].transform.localPosition.y) / 2.0f,
                    requirements[0].transform.localPosition.z);
                requirements[1].transform.localPosition = new Vector3(requirements[1].transform.localPosition.x,
                    (requirements[1].transform.localPosition.y + requirements[3].transform.localPosition.y) / 2.0f,
                    requirements[1].transform.localPosition.z);
                break;
            case 3:
                requirements[2].transform.localPosition = new Vector3((requirements[0].transform.localPosition.x + requirements[1].transform.localPosition.x) / 2.0f,
                    requirements[2].transform.localPosition.y,
                    requirements[2].transform.localPosition.z);
                break;

        }
        score = transform.GetChild(0).Find("Score").GetComponent<MeshRenderer>();
        score.GetPropertyBlock(propBlock);
        switch (Data.score)
        {
            case 2:
                propBlock.SetTexture("_MainTex", Scores[0]);
                break;
            case 3:
                propBlock.SetTexture("_MainTex", Scores[1]);
                break;
            case 5:
                propBlock.SetTexture("_MainTex", Scores[2]);
                break;
            default:
                Debug.LogError("Error! Card data score: " + Data.score + " doesn't exist!");
                break;
        }
        score.SetPropertyBlock(propBlock);
    }

    // Update is called once per frame
    void Update()
    {

    }
}
