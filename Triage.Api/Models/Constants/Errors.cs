using System;
using System.Collections.Generic;
using System.Text;

namespace Models.Constants
{
    public static class Errors
    {
        /// <summary>
        /// API call from  mobile, no error occurred
        /// </summary>
        public const int ERROR_CODE_GENERAL_EXCEPTION = -1;

        /// <summary>
        /// API call from  mobile, no error occurred message
        /// </summary>
        public const string ERROR_MESSAGE_GENERAL_EXCEPTION = "Exception occurred, exception message: {0}!";
    }
}
