# **飞机模型**
* ## 作品简介
  　　该程序设计了一个简易的战斗机模型，通过方向键可以模拟操控飞机的移动，并且可以控制飞机发射子弹，飞机和子弹都由特殊符号代替。

* ## 运行环境
   * Visual Studio 2017
* ## 操作方法
   * 用visual studio打开文件“飞机模型.sln”，点击运行按钮，弹出游戏窗体。
   * 通过方向键可以控制飞机上下左右移动。
   * 按下空格键控制飞机发射子弹。
* ## 主要代码
```C#
    class PlaneClass
    {
        int x, y;

        public void iniplane(Form frm, Label lb)
        {
            x= frm.Width / 2;
            y= frm.Height - 100;
            lb.Location = new Point(x, y);
        }

        public void keycontrol(Form frm, KeyEventArgs e, Label lb1)
        {
            if (e.KeyCode == Keys.Up)
            {
                if (y >= 10)
                {
                    y -= 10;
                    lb1.Location = new Point(x, y);
                }
            }
            if (e.KeyCode == Keys.Down)
            {
                if (y <= frm.Height - 80)
                {
                    y += 10;
                    lb1.Location = new Point(x, y);
                }
            }
            if (e.KeyCode == Keys.Left)
            {
                if (x >= 10)
                {
                    x -= 10;
                    lb1.Location = new Point(x, y);
                }
            }
            if (e.KeyCode == Keys.Right)
            {
                if (x <= frm.Width - 80)
                {
                    x += 10;
                    lb1.Location = new Point(x, y);
                }
            }
            if(e.KeyCode==Keys.Space)
            {
                Label lbl=new Label();
                lbl.Location=new Point(x+14,y-15);
                lbl.Text = "*";
                lbl.Font = new Font("宋体", 16, System.Drawing.FontStyle.Bold);
                frm.Controls.Add(lbl);
            }
        }

       public void move(Form frm)
        {
            foreach(Control item in frm.Controls)
            {
                if (item.Name != "label1")
                {
                    int a = item.Location.X, b =(item .Location.Y - 10);
                    item.Location = new Point(a,b);
                    if (b < 0)
                    {
                        frm.Controls.Remove(item);
                    }
                }
            }
        }


    }
 ```
 * ## 运行界面
    ![游戏界面](https://github.com/ttyyhh/tang/blob/master/1.png)
 
