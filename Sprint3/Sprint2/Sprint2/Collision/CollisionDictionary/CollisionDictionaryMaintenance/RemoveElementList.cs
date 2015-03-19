using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sprint2.Collision.CollisionDictionary.CollisionDictionaryMaintenance
{
    class RemoveElementList
    {
        static ArrayList toRemove = new ArrayList();

        public RemoveElementList() {}

        public void Add(object o)
        {
            toRemove.Add(o);
        }

        public ArrayList GetList()
        {
            return toRemove;
        }

        public void Clear()
        {
            toRemove.Clear();
        }
    }
}
