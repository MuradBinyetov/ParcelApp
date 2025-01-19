using System.ComponentModel.DataAnnotations.Schema;

namespace OrderService.Models
{
    [NotMapped]
    public class Response
    {
        public int Code { get; set; } 
        public bool Success { get; set; } 
        public object Data { get; set; } 
        public string ResponseMessage { get; set; }
    }
}
