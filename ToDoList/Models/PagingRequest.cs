using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ToDoList.Models
{
    public class PageRequestModel
    {
        int pageIndex = 0;
        public int PageIndex
        {
            get => pageIndex;
            set => pageIndex = value == 0 ? 0 : value - 1;
        }
        public int PageSize { get; set; }
        public int FromIndex
        {
            get => PageIndex * PageSize;
            private set { }
        }
    }
}
