
namespace Lab5.Models
{
    internal class Pair<F,S>
    {
        private readonly F _first;
        private readonly S _second;

        public F First { get => _first; }

        public S Second { get => _second; }

        public Pair(F first, S second)
        {
            this._first = first;
            this._second = second;
        }
    }
}
