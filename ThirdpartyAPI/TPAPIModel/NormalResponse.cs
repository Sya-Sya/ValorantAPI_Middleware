using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TPAPIModel
{
    public class NormalResponseModel
    {
        public enum ResponseCode
        {
            SUCCESS,
            FAILED,
            PENDING,
            UNKNOWN
        }

        public class NormalResponse
        {
            public ResponseCode ResCode { get; set; }
            public object Error { get; set; }
            public string Message { get; set; }
            public object Data { get; set; }
        }
    }
}