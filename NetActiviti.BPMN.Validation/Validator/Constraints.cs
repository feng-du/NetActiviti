using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NetActiviti.Process.Validation.Validator
{
    public class Constraints
    {

        /**
         * Max length database field ACT_RE_PROCDEF.CATEGORY
         */
        public static  int BPMN_MODEL_TARGET_NAMESPACE_MAX_LENGTH = 255;

        /**
         * Max length database field ACT_RE_PROCDEF.KEY
         */
        public static  int PROCESS_DEFINITION_ID_MAX_LENGTH = 255;

        /**
         * Max length database field ACT_RE_PROCDEF.NAME
         */
        public static  int PROCESS_DEFINITION_NAME_MAX_LENGTH = 255;

        /**
         * Max length of database field ACT_RE_PROCDEF.DESCRIPTION
         */
        public static  int PROCESS_DEFINITION_DOCUMENTATION_MAX_LENGTH = 2000;

    }
}
