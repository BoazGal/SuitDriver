using System;
using System.Collections.Generic;
using System.Text;

namespace SuitDriver
{
    public enum ASTMStackLevel
    {
        OUTSIDE = 0,
        COMM_START,         //1
        PATIENT_LEVEL,      //2
        ORDER_LEVEL,        //3
        RESULT_LEVEL,       //4
        QUERY_LEVEL,        //5
        COMMENT_LEVEL,      //6
        TERMINATION_LEVEL   //7

    }

}
