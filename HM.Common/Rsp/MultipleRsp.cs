using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HM.Common.Rsp
{
    public class MultipleRsp : BaseRsp
    {
        #region -- Methods --

        /// <summary>
        /// Initialize
        /// </summary>
        public MultipleRsp() : base() { }

        /// <summary>
        /// Initialize
        /// </summary>
        /// <param name="message">Message</param>
        public MultipleRsp(string message) : base(message) { }

        /// <summary>
        /// Initialize
        /// </summary>
        /// <param name="message">Message</param>
        /// <param name="titleError">Title error</param>
        public MultipleRsp(string message, string titleError) : base(message, titleError) { }

        /// <summary>
        /// Set data
        /// </summary>
        /// <param name="key">Key</param>
        /// <param name="o">Data</param>
        public void SetData(List<object> o, string code)
        {
            if (Data == null)
            {
                Data = new List<object>();
            }
            Code = code;
            Data.AddRange(o);
        }

        /// <summary>
        /// Set success data
        /// </summary>
        /// <param name="o">Data</param>
        /// <param name="message">Message</param>
        public void SetSuccess(List<object> o, string message)
        {
            var t = new Dto(o, message);

            SetData(t.Data, "success");
        }

        /// <summary>
        /// Set failure data
        /// </summary>
        /// <param name="o">Data</param>
        /// <param name="message">Message</param>
        public void SetFailure(List<object> o, string message)
        {
            var t = new Dto(o, message);

            SetData(t.Data, "failure");
        }

        #endregion

        #region -- Properties --

        /// <summary>
        /// Data
        /// </summary>
        public List<object> Data { get; private set; }

        #endregion

        #region -- Classes --

        /// <summary>
        /// Data transfer object
        /// </summary>
        public class Dto
        {
            #region -- Methods --

            /// <summary>
            /// Initialize
            /// </summary>
            /// <param name="data">Data</param>
            /// <param name="message">Message</param>
            public Dto(List<object> data, string message)
            {
                Data = data;
                Message = message;
            }

            #endregion

            #region -- Properties --

            /// <summary>
            /// Data
            /// </summary>
            public List<object> Data { get; private set; }

            /// <summary>
            /// Message
            /// </summary>
            public string Message { get; private set; }

            #endregion
        }

        #endregion
    }
}
