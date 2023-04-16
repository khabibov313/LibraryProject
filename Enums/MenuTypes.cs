using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryProject.Enums
{
    internal class MenuTypes
    {
        public enum MenuTypes : byte
        {
            AuthorAdd = 1,
            AuthorEdit,
            AuthorRemove,
            AuthorGetAll,
            AuthorFindByName,
            AuthorGetById,

            BookAdd,
            BookEdit,
            BookRemove,
            BookGetAll,
            BookFindByName,
            BookGetById,

        }
    }
}
