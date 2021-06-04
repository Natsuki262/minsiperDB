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
    private int columns = 1;

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
        //ここで配列の中にrowsとcolumnsのデータ配列を定義生成
        cellArray = new Cell[rows, columns];

        var parent = gridLayoutGroup.gameObject.transform;
        //ぐりっとレイアウトグループのステータス設定
        if (columns < rows)
        {
            gridLayoutGroup.constraint = GridLayoutGroup.Constraint.FixedColumnCount;
            gridLayoutGroup.constraintCount = columns;
        }
        else
        {
            gridLayoutGroup.constraint = GridLayoutGroup.Constraint.FixedRowCount;
            gridLayoutGroup.constraintCount = rows;
        }
        //列形成
        for (var r = 0; r < rows; r++)
        {
            for (var c = 0; c < columns; c++)
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

            tmp = Random.Range(0, rows);
            tmp2 = Random.Range(0, columns);
            //再抽選開始rows*columnsが二倍なのはダブりを防ぐため
            for (int d = 0; d < rows * columns * 2; d++)
            {　　//セルがもうすでに爆弾のフラグがtrueなら
                if (cellArray[tmp, tmp2].IsMineBuried == true)
                {

                    //再抽選
                    tmp = Random.Range(0, rows);
                    tmp2 = Random.Range(0, columns);

                    //cellArray[tmp, tmp2].IsMineBuried = true;

                }
                //再抽選する必要がない場合はループを抜ける
                else
                {
                    break;
                }

            }
            cellArray[tmp, tmp2].IsMineBuried = true;
        }



    }

    // Update is called once per frame
    void Update()
    {

    }
    /// <summary>
    /// 周囲の地雷を探して数える
    /// </summary>
    void FindCountNearMine(int r, int c)
    {
        r = 1;
        c = 2;
        //調べたい対象の右隣に爆弾があるかどうか
        if(cellArray[r+1, c].IsMineBuried==true)
        {

        }
    }
    bool MineInCellTrueOrFalse(int r, int c)
    {
        if(r>=rows||r<0)
        {
            return false;
        }
        if(c>=columns||c<0)
        {
            return false;
        }
        if (cellArray[r, c].IsMineBuried == true)
        {
            return true;
        }
        else  
        {
            return false;

        }
    }
}
