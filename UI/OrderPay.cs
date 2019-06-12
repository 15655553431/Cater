using Bll;
using Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace UI
{
    public partial class OrderPay : Form
    {
        private OrderPay()
        {
            InitializeComponent();
        }

        private static OrderPay op;
        public static OrderPay Create()
        {
            if (op == null || op.IsDisposed)
            {
                op = new OrderPay();
            }
            return op;
        }

        private OrderInfoBll oiBll = new OrderInfoBll();

        //当前餐桌编号，使用的会员编号，打折数，可以付的最大余额
        //这里我把这四个参数做成当前类的全局变量
        //这里尤其注意，payMoney不是真的实际付款金额，当余额小于应付金额时，pagMoney为余额，余额大于应付金额，pagMoney为应付金额
        private int tableId = 0;
        private int memberId = 0;
        private decimal discount = 1;   
        private decimal payMoney = 0;
        //补充一下全局变量,用来 做辅助的逻辑计算
        private decimal payShouldOmoney = 0;//这里需要存储客户打折后应该付的的金额
        private void OrderPay_Load(object sender, EventArgs e)
        {
            gbMember.Enabled = false;

            //根据餐桌编号获取餐桌名称和餐桌所属厅包的名称,在窗体上面进行提示！
            TableInfoBll tiBll = new TableInfoBll();
            TableInfo ti = new TableInfo();
            ti.TId = Convert.ToInt32(this.Tag);
            tableId = ti.TId;
            List<TableInfo> list = new List<TableInfo>();
            list = tiBll.GetList(ti);
            string tableTitleById = list[0].TTitle;
            string hallTypeById = list[0].HallType;
            this.Text = "【" + hallTypeById + "】【" + tableTitleById + "】号结账！";

            //查询消费金额,这里一定要注意，点菜之后要点击下单，否则结账的时候是无法查到消费金额
            lblConsumeMoney.Text = oiBll.GetMoneyByTid(ti.TId).ToString();
            //默认实际付款就是消费金额
            lblShouldMoney.Text = lblConsumeMoney.Text;
        }

        private void ckbMember_CheckedChanged(object sender, EventArgs e)
        {
            gbMember.Enabled = ckbMember.Checked;

            if (!ckbMember.Checked)
            {
                //如果没有选择会员选项
                 txtMname.Text = "";
                txtMphone.Text = "";
                lblMoney.Text = "0";
                lblType.Text = "普通会员";
                lblTypeDiscount.Text = "10折";
                lblShouldMoney.Text = lblConsumeMoney.Text;
                ckbMoney.Checked = false;
            }
            txtMname.ReadOnly = false;
            txtMphone.ReadOnly = false; 
            
            

        }

        private void GetMemberInfo()
        {
            if (txtMname.ReadOnly == false&&txtMphone.ReadOnly==false)//这里必须确定txt框是可输入状态下，否则不是人为的改变，则不做查询。
            {
                MemberInfo mi = new MemberInfo();
                mi.MName = txtMname.Text;
                mi.MPhone = txtMphone.Text;

                MemberInfoBll miBll = new MemberInfoBll();
                var list = miBll.GetList(mi);
                //当只查询出一个结果的时候
                if (list.Count == 1)
                {
                    //将会员编号和打折数记录下来
                    memberId = list[0].MId;
                    discount = list[0].TypeDiscount;
                    //将查询的结果显示出来
                    lblMoney.Text = list[0].MMoney.ToString();
                    lblTypeDiscount.Text = (list[0].TypeDiscount * 10).ToString() + "折";      
                    lblType.Text = list[0].TypeTitle;
                    //查询到结果之后，不许输入！并将正确结果显示
                    txtMname.ReadOnly = true;
                    txtMphone.ReadOnly = true;
                    txtMname.Text = list[0].MName;
                    txtMphone.Text = list[0].MPhone;

                    //计算实收金额,根据折扣更新实际收费
                    lblShouldMoney.Text = (Convert.ToDecimal(lblConsumeMoney.Text) * list[0].TypeDiscount).ToString();
                    payShouldOmoney = Convert.ToDecimal(lblShouldMoney.Text);//存下来，打折后应该实际收的钱。
                    //一旦查询到会员，就需要更新使用余额的状态
                    ckbMoney_CheckedChanged(null, null);
                    //重新计算找零
                    txtRealIncome_Leave(null, null);

                }
                else
                {
                    lblShouldMoney.Text = lblConsumeMoney.Text;
                }
            }
            
        }

        private void btnMemberInfo_Click(object sender, EventArgs e)
        {
            MemberList mil = MemberList.Create();
            mil.Show();
            mil.Focus();
        }

        private void txtMphone_TextChanged(object sender, EventArgs e)
        {
            GetMemberInfo();
           
        }

        private void txtMname_TextChanged(object sender, EventArgs e)
        {
            GetMemberInfo();
        }

        //重新查询会员
        private void btnSearch_Click(object sender, EventArgs e)
        {
            txtMname.Text = "";
            txtMphone.Text = "";
            //这里注意，必须先把txt的内容变成空的，才能改变只读状态，不然没用。一旦开启输入，text属性一变化，便开启了查询
            txtMname.ReadOnly = false;
            txtMphone.ReadOnly = false;
            lblMoney.Text = "0";
            lblType.Text = "普通会员";
            lblTypeDiscount.Text = "10折";
            lblShouldMoney.Text = lblConsumeMoney.Text;
           
        }



        private void txtRealIncome_Leave(object sender, EventArgs e)
        {
           
         //计算找零
         lblChange.Text = (Convert.ToDouble(txtRealIncome.Text) - Convert.ToDouble(lblShouldMoney.Text)).ToString();


            btnStatement.Enabled = true;
            btnStatement.Text = "确认结账";
            if (Convert.ToDouble(lblChange.Text) < 0)
            {
                btnStatement.Text = "金额错误！";
                btnStatement.Enabled = false;
            }

        }

        //结账按钮
        private void btnStatement_Click(object sender, EventArgs e)
        {
            //点击确认结账后要做的操作
            //看到这里，请移到OrderInfoDal.cs，看结账事务
            //1.更改订单状态  ispay=1
            //2.将餐桌状态更改为1，即空闲
            //3.如果使用余额付款结账，则更新会员余额
            //上面三件事在Dal层完成，下面这件事在Ui完成
            //4.更改结账的餐桌状态图片
            
            //分析：已知的数据：tableid。当前结账的餐桌编号
            //需要得到的数据：会员编号：进行余额扣除，折扣后金额
            //当前餐桌编号，使用的会员编号，打折数，可以付的最大余额
            //这里我把这四个参数做成当前类的全局变量
          
            //判断使用余额选项是否被按下
            //if(ckbMoney.Checked)
            //{
            //    //获得当前账户余额
            //    decimal totalMoney = decimal.Parse(lblMoney.Text);
            //    //获得当前应收金额
            //    decimal payshouldMoney = decimal.Parse(lblShouldMoney.Text);
            //    //判断,如果余额大于应付金额，余额充足
            //    if (totalMoney > payMoney)
            //    {
            //        //余额充足，全部使用余额支付
            //        payMoney = payshouldMoney;
            //    }
            //    else
            //    {
            //        //余额不足，那就把剩下的余额全部付了
            //        payMoney = totalMoney;
            //    }
            //    //给应收现金lbl进行更新
            //   lblShouldMoney.Text = (Convert.ToDecimal(lblShouldMoney.Text) - payMoney).ToString();

            //}
            if (oiBll.JieZhang(tableId, memberId, discount, payMoney))
            {
                //如果结账成功，更改结账的餐桌的状态图片，让出餐桌
                //这个时候遇到，在主菜单打开的结账窗体，在结账窗体中，需要操作主窗体的成员（改变状态图片）
                //使用事件，去主窗体定义一个方法
                SetTableFreeEvent();
                this.Close();
            }
            else
            {
                //结账失败，给个提示
                MessageBox.Show("未知错误，稍后重试！");
            }

        }

        //定义一个事件，当完成点餐的时候，去改变主窗体的餐桌状态
        public event Action SetTableFreeEvent;

        private void ckbMoney_CheckedChanged(object sender, EventArgs e)
        {
            if (memberId > 0)//必须要有会员编号，选择使用余额才有效，否则无效
            {
                if (ckbMoney.Checked)
                {
                    //获得当前账户余额
                    decimal totalMoney = decimal.Parse(lblMoney.Text);
                    //获得当前应收金额
                    decimal payshouldMoney = payShouldOmoney;
                    //判断,如果余额大于应付金额，余额充足
                    if (totalMoney > payshouldMoney)
                    {
                        //余额充足，全部使用余额支付
                        payMoney = payshouldMoney;
                    }
                    else
                    {
                        //余额不足，那就把剩下的余额全部付了，不够的继续付现金
                        payMoney = totalMoney;
                    }
                    //使用余额后，给应收现金lbl进行更新，
                    lblShouldMoney.Text = (payShouldOmoney - payMoney).ToString();

                }
                else
                {
                    //不使用余额了，那应收金额lbl就显示打折后的金额，全部付现金
                    lblShouldMoney.Text = payShouldOmoney.ToString();
                }
                //重新计算找零
                txtRealIncome_Leave(null, null);
            }
        }

        private void btnShowOrderDish_Click(object sender, EventArgs e)
        {
            OrderDishList odl = OrderDishList.Create();
            //给他餐桌编号，才能查询出已点菜品
            odl.Tag = tableId;
            odl.Show();
            odl.Focus();
        }




    }
}
