using CalcLib;

namespace Tests
{
    public class TestInputRetriever: InputRetriever
    {
        private string[] _values;
        private int _index;
        public TestInputRetriever(string []values)
        {
            _values = values;
            //values.CopyTo(_values,0);
            _index = 0;
        }
        public override string GetValue()
        {
            return _values[_index++];
        }
    }
}