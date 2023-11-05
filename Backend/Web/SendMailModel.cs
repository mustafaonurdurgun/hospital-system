using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Web
{
    
    public class SendMailModel 
    {
        public string Subject { get; set; }
        public string Mail { get; set; }
        public string Recepients { get; set; }
    }
}
