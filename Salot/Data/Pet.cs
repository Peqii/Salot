using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Salot.Data
{
    class Pet : ILivingThings<Pet>
    {
        public string Name { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public int Age { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public DateTime CreatedOn { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public DateTime ModifiedOn { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public Guid ID { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

        enum Species { }
    }
}
