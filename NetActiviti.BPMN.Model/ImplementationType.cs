using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NetActiviti.BPMN.Model
{
    public class ImplementationType
    {

        public static string IMPLEMENTATION_TYPE_CLASS = "class";
        public static string IMPLEMENTATION_TYPE_EXPRESSION = "expression";
        public static string IMPLEMENTATION_TYPE_DELEGATEEXPRESSION = "delegateExpression";
        public static string IMPLEMENTATION_TYPE_INSTANCE = "instance";
        public static string IMPLEMENTATION_TYPE_THROW_SIGNAL_EVENT = "throwSignalEvent";
        public static string IMPLEMENTATION_TYPE_THROW_GLOBAL_SIGNAL_EVENT = "throwGlobalSignalEvent";
        public static string IMPLEMENTATION_TYPE_THROW_MESSAGE_EVENT = "throwMessageEvent";
        public static string IMPLEMENTATION_TYPE_THROW_ERROR_EVENT = "throwErrorEvent";
        public static string IMPLEMENTATION_TYPE_WEBSERVICE = "##WebService";

        public static string IMPLEMENTATION_TYPE_INVALID_THROW_EVENT = "invalidThrowEvent";

    }
}
