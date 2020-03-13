using System;
using System.Collections.Generic;
using System.Text;

namespace WebApp.Data.Interfaces
{
    public interface IHasSortDelete
    {
        bool IsDeleted { get; set; }
    }
}
