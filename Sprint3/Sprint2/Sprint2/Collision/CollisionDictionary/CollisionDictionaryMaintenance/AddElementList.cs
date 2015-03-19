using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sprint2.Collision.CollisionDictionary.CollisionDictionaryMaintenance
{
    class AddElementList
    {
        static ArrayList toAdd = new ArrayList();

        public AddElementList() { }

        public void Add(object o)
        {
            toAdd.Add(o);
        }

        public ArrayList GetList()
        {
            return toAdd;
        }

        public void Clear()
        {
            toAdd.Clear();
        }
    }
}
