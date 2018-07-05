

using System;
namespace T4ConsoleApplication.Entities
{    

    public class BC_OC_OCCloudStock
    {
              
        public string CompanyID { get; set; }
              
        public object CloudStockID { get; set; }
              
        public string CloudStockCode { get; set; }
              
        public string CloudStockName { get; set; }
              
        public int BillStatus { get; set; }
              
        public string Remark { get; set; }
              
        public string Operator { get; set; }
              
        public string Checker { get; set; }
              
        public DateTime? CheckDate { get; set; }
              
        public bool AllowUsed { get; set; }
              
        public DateTime? BillDate { get; set; }
              
        public DateTime ModifyDTM { get; set; }
              
        public object UnChecker { get; set; }
              
        public DateTime? UnCheckDate { get; set; }
              
        public string Signature { get; set; }
              
        public object BillTypeID { get; set; }
              
        public object ShareRatio { get; set; }
         
      
    }
}

