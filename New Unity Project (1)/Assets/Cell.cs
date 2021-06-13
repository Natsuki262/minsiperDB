using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Cell : MonoBehaviour
{
    // Start is called before the first frame update
    /// <summary>
    /// 地雷をも持っているか　初期は持ってない
    /// </summary>
    bool isMineBuried = false;
    /// <summary>
    /// ゲットで地雷の情報を渡す
    ///セッターで引数を代入
    /// </summary>
    public bool IsMineBuried
    {

        get
        {
            return isMineBuried;
        }
        set
        {
            isMineBuried = value;
        }
    }
    /// <summary>
    /// 爆弾の状態を示すテキスト
    /// </summary>
    [SerializeField]
    Text mineStatusTxt;
    /// <summary>
    /// ボタンセルをユーザに押してもらうため
    /// </summary>
    [SerializeField]
    GameObject button = null;

    [SerializeField]
    public Image mineImage;

    private Sprite sprite;

    [SerializeField]
    public Image flagImg;
    //周囲の地雷の数のデータ
    public int nearMineCountData = 0;

   public GameManeger gameManeger=null;//GameOver処理用

    void Start()
    {

        if (isMineBuried == true)
        {
            //mineStatusTxt.text = "X";
            mineImage.gameObject.SetActive(true);
            

        }
        else
        {
            
            mineStatusTxt.text = nearMineCountData.ToString();
            if (nearMineCountData == 0)
            {
                mineStatusTxt.text = " ";
            }
        }
    }

    // Update is called once per frame
    void Update()
    {

    }
    /// <summary>
    /// ユーザがタッチしたらシェルを開く
    /// </summary>
  //イベントトリガーに変更するかも
    public void CellTouchOpen()
    {
        Debug.Log("動いたよ！");
        if (Input.GetMouseButtonDown(0))
        {
            button.SetActive(false);
            if(IsMineBuried==true)
            {
                //げーむおーばー呼び出し
                gameManeger.GameOver();
                
            }
           

        }
        else if (Input.GetMouseButtonDown(1))
        {

            flagImg.gameObject.SetActive(true);

        }


        
    }
}
