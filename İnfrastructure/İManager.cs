using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryProject.İnfrastructure
{
    internal class İManager
    {
        void Add(T item);
        void Edit(T item);
        void Remove(T item);
        void Read(T item);
        T GetById(int id);
        T[] FindByName(string name);

    }
}
}
