using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _02_DZ
{
    internal class Sales
    {
        public int Id {  get; set; }
        public int Custumer_id { get; set; }
        public int Seller_id { get; set; }
        public decimal Amount {  get; set; }
        public DateTime Sale_date { get; set; }
    }
}
