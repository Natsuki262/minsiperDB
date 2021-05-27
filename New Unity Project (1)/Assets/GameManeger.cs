using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class GameManeger : MonoBehaviour
{
    // Start is called before the first frame update
    /// <summary>
    /// 行
    /// </summary>
    [SerializeField]
    private int rows = 1;
    /// <summary>
    /// 列
    /// </summary>
    [SerializeField]
    private int coulums = 1;

    [SerializeField]
    private GridLayoutGroup gridLayoutGroup = null;

    [SerializeField]
    private Cell Cellprefab = null;

    /// <summary>
    /// 行、列二次元配列
    /// </summary>
    Cell[,] array;
    
    void Start()
    {
        var parent = gridLayoutGroup.gameObject.transform;
        if (coulums < rows)
        {
            gridLayoutGroup.constraint = GridLayoutGroup.Constraint.FixedColumnCount;
            gridLayoutGroup.constraintCount = coulums;
        }
        else
        {
            gridLayoutGroup.constraint = GridLayoutGroup.Constraint.FixedRowCount;
            gridLayoutGroup.constraintCount = rows;
        }

        for (var r = 0; r < rows; r++)
        {
            for (var c = 0; c < coulums; c++)
            {

                var cell = Instantiate(Cellprefab);
                cell.IsMineBuried = true;
                cell.transform.SetParent(parent);



            }
        }
    }

    // Update is called once per frame
    void Update()
    {

    }
}
