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
    [SerializeField]
    public GameObject Ui;


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
                //ここで実態データを代入理由Cellでゲームマネージャーの関数でーたの実態必要だから
                cellArray[r, c].gameManeger = this;

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
            //cellArray[tmp, tmp2].nearMineCountData = -1;
        }
        for (int r = 0; r < rows; r++)
        {
            for (int c = 0; c < columns; c++)
            {
                FindCountNearMine(r, c);
            }
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
        //周囲地雷の数を数える変数
        int mineCount = 0;

        /*調べたい指定したセルの八方向に地雷があるかどうか
        あるなら地雷のカウントを増やす*/
        if (IsMine(r + 1, c) == true) mineCount++;      //右隣
        if (IsMine(r - 1, c) == true) mineCount++;      //左隣     
        if (IsMine(r, c - 1) == true) mineCount++;      //上
        if (IsMine(r, c + 1) == true) mineCount++;      //下
        if (IsMine(r + 1, c - 1) == true) mineCount++;  //右上
        if (IsMine(r - 1, c - 1) == true) mineCount++;  //左上
        if (IsMine(r + 1, c + 1) == true) mineCount++;  //右下
        if (IsMine(r - 1, c + 1) == true) mineCount++;  //左下
       
        if (cellArray[r, c].IsMineBuried)
        {
           
            cellArray[r, c].nearMineCountData =-1;
        }
        else
        {
            cellArray[r, c].nearMineCountData = mineCount;
        }
    }

    /// <summary>
    /// セルに地雷あるかどうかを調べる関数
    /// </summary>
    /// <param name="r">列</param>
    /// <param name="c">行</param>
    /// <returns>爆弾があるかないか</returns>
    bool IsMine(int r, int c)
    {
        //セルがない場合
        if (r >= rows || r < 0)
        {
            return false;
        }
        //セルがない場合
        if (c >= columns || c < 0)
        {
            return false;
        }
        //地雷がある場合
        if (cellArray[r, c].IsMineBuried == true)
        {
            return true;
        }
        //ない場合
        else
        {
            return false;

        }
    }
    /// <summary>
    /// 隣接する空白のマスを空ける関数
    /// </summary>
    void AdjacentblankOpen(int r, int c)
    {
        if (cellArray[r + 1, c].nearMineCountData == 0)//右隣り
        {
            cellArray[r  +1, c].ChengeSetActive();
        }
        if (cellArray[r - 1, c].nearMineCountData == 0)//左隣り
        {
            cellArray[r - 1, c].ChengeSetActive();
        }
        if (cellArray[r  , c-1].nearMineCountData == 0)//上
        {
            cellArray[r  , c-1].ChengeSetActive();
        }
        if (cellArray[r, c +1].nearMineCountData == 0)//下
        {
            cellArray[r, c +1].ChengeSetActive();
        }
        if (cellArray[r+1 ,c - 1].nearMineCountData == 0)//右上
        {
            cellArray[r+1, c - 1].ChengeSetActive();
        }
        if (cellArray[r-1, c - 1].nearMineCountData == 0)//左上
        {
            cellArray[r-1, c- 1].ChengeSetActive();
        }
        if (cellArray[r + 1, c + 1].nearMineCountData == 0)//右下
        {
            cellArray[r + 1, c + 1].ChengeSetActive();
        }
        if (cellArray[r - 1, c + 1].nearMineCountData == 0)//左下
        {
            cellArray[r - 1, c + 1].ChengeSetActive();
        }
    }

    public void GameOver()
    {
        Debug.Log("げーむおーばーおっさんに絡まれた！");
        Ui.SetActive(true);
        Debug.Log(Ui);
    }
}
