using System;
using System.Collections.Generic;
using System.Text;
using System.Data;

using AForge.Mathematics;

using Sinapse.Core.Sources;

namespace Sinapse.Core.Filters
{
    class TableToMatrix : IFilter
    {

        private Dictionary<int, string>[] stringColumnCaptions;
        private Matrix output;
        private DataTable input;

        
        public TableToMatrix()
        {

        }

        public override void Apply()
        {
            throw new NotImplementedException();
            // this.stringColumnCaptions = new Dictionary<int,string>[]
        }


        public override object Input
        {
            get
            {
                throw new Exception("The method or operation is not implemented.");
            }
            set
            {
                throw new Exception("The method or operation is not implemented.");
            }
        }

        public override object Output
        {
            get
            {
                throw new Exception("The method or operation is not implemented.");
            }
            protected set
            {
                throw new Exception("The method or operation is not implemented.");
            }
        }
    }
}
