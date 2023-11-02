using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.ViewModels
{
    public abstract record RecordWithValidation
    {
        protected RecordWithValidation()
        {
            Validate();
        }

        protected virtual void Validate()
        {
        }
    }
}
