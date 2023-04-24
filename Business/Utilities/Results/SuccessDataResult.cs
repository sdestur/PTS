using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Utilities.Results
{
    public class SuccessDataResult<T> : DataResult<T>
    {
        //kullanıcıya mesaj dondurerek : 
        public SuccessDataResult(T data, string message) : base(data, true, message)
        {

        }
        //message dondurmeden
        public SuccessDataResult(T data) : base(data, true)
        {

        }
        //sadece message alip, default data degeriyle dondurerek
        //aşağıdaki default data'ya karşılık geliyor
        public SuccessDataResult(string message) : base(default, true, message)
        {

        }
        public SuccessDataResult() : base(default, true)
        {

        }
    }
}
