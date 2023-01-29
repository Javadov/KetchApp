using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp.Interfaces
{
    internal interface IService
    {
        void CreateContact(IContact contact);

        void RemoveContact(IContact contact);

        IEnumerable<IContact> GetAll();

        IContact Get(int id);
    }
}
