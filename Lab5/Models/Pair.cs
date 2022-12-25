
namespace Lab5.Models
{
    internal class Pair<F,S>
    {
        private F _first;
        private S _second;

        public F First { get => _first; set => this._first = value; }

        public S Second { get => _second; set => this._second = value; }

        public Pair(F first, S second)
        {
            this._first = first;
            this._second = second;
        }
    }
}
