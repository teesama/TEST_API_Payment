using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using RestSharp;
using Newtonsoft.Json;
using System.Web.Script.Serialization;

public partial class CallBack : System.Web.UI.Page
{

    public class MerchantTextResponse
    {
        public int Code { get; set; }
        public string Message { get; set; }
        public bool POBOOL { get; set; }
        public string POMSG { get; set; }

    }
    protected void Page_Load(object sender, EventArgs e)
    {
        int Codereturn = 0;
        string Messagereturn = "";

        //SET Global
        string PayNowAPI_KEY = "";

        try
        {

            // STEP 1 รับ ค่ามา 2 ค่า
            // 1 คือ reference
            // 2 คือ status

            string Reference = Request.QueryString["reference"];
            string Status = Request.QueryString["status"];
            

            // STEP2 นำค่าที่รับมา ส่งเข้า API 
            var client = new RestClient("");
            client.Timeout = -1;
            var request = new RestRequest(Method.GET);
            request.AddHeader("X-BUSINESS-API-KEY", PayNowAPI_KEY);
            request.AddHeader("Content-Type", "application/x-www-form-urlencoded");
            request.AddHeader("X-Requested-With", "XMLHttpRequest");
            IRestResponse response = client.Execute(request);

            // STEP3 นำค่าที่ Return กลับมาของ STEP2 เก็บไว้ในตัวแปร JSON 
            JavaScriptSerializer jSonData = new JavaScriptSerializer();
            var respData = jSonData.Deserialize<ResultData>(response.Content);


            #region Payment Gateway Data
            int paymentid = 0;
            int eventid = 0;
            string eventname = String.Empty;
            string eventreference01 = String.Empty;
            string eventreference02 = String.Empty;
            string eventreference03 = String.Empty;
            int fixprice = 0;
            int paymentprice = 0;
            int paymentstatus = 0;
            string eventurl = String.Empty;
            string eventip = String.Empty;
            string ipaddress = Request.UserHostAddress.ToString();
            string errormessage = String.Empty;
            string PaymentType = "44";

            //TODO
            string referenceId = respData.reference_number.ToString();
            string jsonResult = JsonConvert.SerializeObject(respData);
            #endregion


            long referencecode = 0;


        }
        catch (Exception ex)
        {
            Console.WriteLine("Error "+ex.Message);
        }
    }




    // SET CONTEXTDATA

    public class Payment
    {
        public string id { get; set; }
        public int quantity { get; set; }
        public string status { get; set; }
        public string buyer_name { get; set; }
        public string buyer_phone { get; set; }
        public string buyer_email { get; set; }
        public string currency { get; set; }
        public string amount { get; set; }
        public string payment_type { get; set; }
        public string fees { get; set; }
        public DateTime created_at { get; set; }
        public DateTime updated_at { get; set; }
    }

    public class ResultData
    {
        public string id { get; set; }
        public object name { get; set; }
        public string email { get; set; }
        public object phone { get; set; }
        public string amount { get; set; }
        public string currency { get; set; }
        public string status { get; set; }
        public object purpose { get; set; }
        public object reference_number { get; set; }
        public IList<string> payment_methods { get; set; }
        public string url { get; set; }
        public string redirect_url { get; set; }
        public string webhook { get; set; }
        public bool send_sms { get; set; }
        public bool send_email { get; set; }
        public string sms_status { get; set; }
        public string email_status { get; set; }
        public bool allow_repeated_payments { get; set; }
        public object expiry_date { get; set; }
        public DateTime created_at { get; set; }
        public DateTime updated_at { get; set; }
        public IList<Payment> payments { get; set; }
    }
}