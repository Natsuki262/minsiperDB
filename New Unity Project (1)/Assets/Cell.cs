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
    Button button = null;
    public Image mineImage;
    private Sprite sprite;

    void Start()
    {
        if (isMineBuried == true)
        {
            //mineStatusTxt.text = "X";
            sprite = Resources.Load<Sprite>("bom");
            mineImage = this.GetComponent<Image>();
            mineImage.sprite = sprite;

        }
        else
        {
            mineStatusTxt.text = " ";
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
    public  void CellTouchOpen()
    {
        button.gameObject.SetActive(false);
        var img = GetComponent<Image>();
        //mg.sprite
    }
}
