using Assets.Scripts.GameClasses;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TetrisGrid : MonoBehaviour
{


    private int gridWidth = 18;
    private int gridHeight = 20;

    private TetrisGameGrid myGrid;

    public GameObject greenBlock;

    // Use this for initialization
    void Start()
    {

        myGrid = new TetrisGameGrid(gridHeight, gridWidth);

        

    }

    // Update is called once per frame
    void Update()
    {


        for (int x = 0; x < gridWidth; x++)
        {
            for (int y = 0; y < gridHeight; y++)
            {
        
            myGrid.gridSpaces[0, 0] = new Block(0, 0, BlockColor.Green);
            GameObject newnewGreenBlock = GameObject.Instantiate(greenBlock, new Vector3(0, 0, -1), Quaternion.identity);
            newnewGreenBlock.transform.Translate(x,y,0);
              
            }
            
        }
        break;

    }
}
