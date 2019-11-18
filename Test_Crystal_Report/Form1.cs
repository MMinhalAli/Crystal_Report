using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Test_Crystal_Report
{
    public partial class Form1 : Form
    {
        public int Total { get; set; }
        public Form1()
        {
            InitializeComponent();
        }

        private void CheckOut_Click(object sender, EventArgs e)
        {
            int i = 0;
            string recieptid = "",buyerid="",merchandiserName="",soldDate="",itemid="",quantity="",amount="";
            ReceiptItems[] ri = new ReceiptItems[10];
            List<Dictionary<String, String>> data = DataBaseManager.runSelectQuery("Select Reciept.RecieptID,Reciept.BuyerID,Reciept.MerchandiserName,Reciept.SoldDate,RecieptItems.ItemID,RecieptItems.Quantity,RecieptItems.Amount from Reciept Inner Join RecieptItems ON  Reciept.RecieptID=RecieptItems.RecieptID and Reciept.BuyerID='vicky'");
                foreach (Dictionary<String, String> valueMap in data)
                {
                    valueMap.TryGetValue(Constants.RECIEPT_ID, out recieptid);
                    valueMap.TryGetValue(Constants.BUYER_ID, out buyerid);
                    valueMap.TryGetValue(Constants.MERCHANDISER_NAME, out merchandiserName);
                    valueMap.TryGetValue(Constants.SOLD_DATE, out soldDate);
                    valueMap.TryGetValue(Constants.ITEM_ID, out itemid);
                    valueMap.TryGetValue(Constants.QUANTITY, out quantity);
                    valueMap.TryGetValue(Constants.AMOUNT, out amount);
                    ri[i] = new ReceiptItems();
                    ri[i].RecieptID=(recieptid);
                    ri[i].BuyerID=(buyerid);
                    ri[i].MerchandiserName= (merchandiserName);
                    ri[i].SoldDate=(soldDate);
                    ri[i].ItemID=(itemid);
                    ri[i].Quantity=(quantity);
                    ri[i].Amount = (amount);
                    Total +=Convert.ToInt32(amount);
                    i++;
                }

                
        }
    }
}
