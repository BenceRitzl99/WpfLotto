using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfLotto.Models
{
    public class Sorsolas
    {
        public int Id { get; set; }
        public int szam1 { get; set; }
        public int szam2 { get; set; }
        public int szam3 { get; set; }
        public int szam4 { get; set; }
        public int szam5 { get; set; }

        public Sorsolas()
        {

        }
        public Sorsolas(HashSet<int> set)
        {
            var t = set.ToArray();
            szam1 = t[0];
            szam2 = t[1];
            szam3 = t[2];
            szam4 = t[3];
            szam5 = t[4];

        }
    }
}
