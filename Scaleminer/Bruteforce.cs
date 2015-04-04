using System;
using System.Collections;
using System.Text;
namespace Scaleminer
{
    public class Bruteforce : IEnumerable
    {
        #region constructors
        private StringBuilder sb = new StringBuilder();
        //the string we want to permutate 
        public string charset = "abcdefghijklmnopqrstuvwxyz";
        private ulong len;
        private int _max;
        public int max { get { return _max; } set { _max = value; } }
        private int _min;
        public int min { get { return _min; } set { _min = value; } }
        #endregion
        #region Methods
        public System.Collections.IEnumerator GetEnumerator()
        {
            len = (ulong)this.charset.Length;
            for (double x = min; x <= max; x++)
            {
                ulong total = (ulong)Math.Pow((double)charset.Length, (double)x);
                ulong counter = 0;
                while (counter < total)
                {
                    string a = factoradic(counter, x - 1);
                    yield return a;
                    counter++;
                }
            }
        }
        private string factoradic(ulong l, double power)
        {
            sb.Length = 0;
            while (power >= 0)
            {
                sb = sb.Append(this.charset[(int)(l % len)]);
                l /= len;
                power--;
            }
            return sb.ToString();
        }
        #endregion
    }
}