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
    [SerializeField]
    private int bombCount = 0;



    /// <summary>
    /// 行、列二次元配列
    /// </summary>
    Cell[,] cellArray;

    void Start()
    {
        //ここで配列の中にrowsとcoulumsのデータ配列を定義生成
        cellArray = new Cell[rows, coulums];

        var parent = gridLayoutGroup.gameObject.transform;
        //ぐりっとレイアウトグループのステータス設定
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
        //列形成
        for (var r = 0; r < rows; r++)
        {
            for (var c = 0; c < coulums; c++)
            {

                Cell cell = Instantiate(Cellprefab);
                //cellArray配列に要素番号をあてはめつつ、実態データを代入
                cellArray[r, c] = cell;
                //cell.IsMineBuried = true;
                cell.transform.SetParent(parent);

            }

        }
        //ランダムに爆弾を埋め込む
        for (int i = 0; i < bombCount; i++)
        {
            int tmp = 0;
            int tmp2 = 0;
            for (int p = 0; p < int.MaxValue; p++)
            {
                tmp = Random.Range(0, rows);
                tmp2 = Random.Range(0, coulums);
                if (p < bombCount)
                {
                    break;
                }

            }


            if (cellArray[tmp, tmp2].IsMineBuried == true)
            {

                int tmp3 = Random.Range(0, rows);
                int tmp4 = Random.Range(0, coulums);
                cellArray[tmp3, tmp4].IsMineBuried = true;
            }
            cellArray[tmp, tmp2].IsMineBuried = true;
        }



    }

    // Update is called once per frame
    void Update()
    {

    }
}
