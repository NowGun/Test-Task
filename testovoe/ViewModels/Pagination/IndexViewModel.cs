using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using testovoe.Models;

namespace testovoe.ViewModels.Pagination
{
    public class IndexViewModel
    {
        public IEnumerable<Film> Films { get; set; }
        public PageViewModel PageViewModel { get; set; }
    }
}
