using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace CEP
{
    public class clCEP
    {
        private static WebClient GerarClient(string sCEP)
        {
            WebClient client = new WebClient();
            client.BaseAddress = string.Format("https://viacep.com.br/ws/{0}/json/", sCEP);
            client.Headers.Add("content-type", "application/json; charset=utf-8");//set your header here, you can add multiple headers
            client.Encoding = Encoding.UTF8;
            return client;
        }

        public static CAMPOS GetCEP(string sCEP)
        {
            WebClient client = GerarClient(sCEP);
            string response = Encoding.UTF8.GetString(client.DownloadData(client.BaseAddress));
            return (CAMPOS)JsonConvert.DeserializeObject(response, typeof(CAMPOS));
        }

    }

    public class CAMPOS
    {
        public string cep { get; set; }
        public string logradouro { get; set; }
        public string complemento { get; set; }
        public string bairro { get; set; }
        public string localidade { get; set; }
        public string uf { get; set; }
        public string unidade { get; set; }
        public string ibge { get; set; }
        public string gia { get; set; }
    }
}
