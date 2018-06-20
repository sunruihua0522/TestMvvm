using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BindCollection.Modle
{
    public class Modle
    {
        private List<string> _names = new List<string>() { "Jim","Lucy","LinTao"};
        public Country Ctry = new Country();
        public List<string> NamesList { get { return _names; } set { _names = value; } }
    }

    public class Country
    {
        public List<Province> Province=new List<Province>() { new Province()};
    }
    public class Province
    {
        public List<City> City=new List<City>() { new City()};
    }
    public class City
    {
        public List<Person> Person=new List<Person>() { new Person()};
    }
    public class Person
    {
        public List<string> name=new List<string> { "abc","abcd","abcdefg"};
    }
}
