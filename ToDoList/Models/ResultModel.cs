using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ToDoList.Models
{
    public class ResultModel
    {
        public object Data { get; set; }
        public string Message { get; set; } = string.Empty;
        public int Status { get; set; } = 0;
        public int TotalCount { get; set; } = 0;

        public static ResultModel GetResult(object Data = null, int Status = 0, int TotalCount = 0, string Message = "")
        {
            return new ResultModel()
            {
                Data = Data,
                Status = Status,
                TotalCount = TotalCount,
                Message = Message
            };
        }
    }
}
