using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NetActiviti.Process.Validation.Validator
{
    public abstract class Problems
    {

        public static readonly string ALL_PROCESS_DEFINITIONS_NOT_EXECUTABLE = "activiti-process-definition-not-executable";
        public static readonly string PROCESS_DEFINITION_NOT_EXECUTABLE = "activiti-specific-process-definition-not-executable";

        public static readonly string ASSOCIATION_INVALID_SOURCE_REFERENCE = "activiti-asscociation-invalid-source-reference";

        public static readonly string ASSOCIATION_INVALID_TARGET_REFERENCE = "activiti-asscociation-invalid-target-reference";

        public static readonly string EXECUTION_LISTENER_IMPLEMENTATION_MISSING = "activiti-execution-listener-implementation-missing";
        public static readonly string EXECUTION_LISTENER_INVALID_IMPLEMENTATION_TYPE = "activiti-execution-listener-invalid-implementation-type";

        public static readonly string EVENT_LISTENER_IMPLEMENTATION_MISSING = "activiti-event-listener-implementation-missing";
        public static readonly string EVENT_LISTENER_INVALID_IMPLEMENTATION = "activiti-event-listener-invalid-implementation";
        public static readonly string EVENT_LISTENER_INVALID_THROW_EVENT_TYPE = "activiti-event-listener-invalid-throw-event-type";

        public static readonly string START_EVENT_MULTIPLE_FOUND = "activiti-start-event-multiple-found";
        public static readonly string START_EVENT_INVALID_EVENT_DEFINITION = "activiti-start-event-invalid-event-definition";

        public static readonly string SEQ_FLOW_INVALID_SRC = "activiti-seq-flow-invalid-src";
        public static readonly string SEQ_FLOW_INVALID_TARGET = "activiti-seq-flow-invalid-target";

        public static readonly string USER_TASK_LISTENER_IMPLEMENTATION_MISSING = "activiti-usertask-listener-implementation-missing";

        public static readonly string SERVICE_TASK_INVALID_TYPE = "activiti-servicetask-invalid-type";
        public static readonly string SERVICE_TASK_RESULT_VAR_NAME_WITH_DELEGATE = "activiti-servicetask-result-var-name-with-delegate";
        public static readonly string SERVICE_TASK_MISSING_IMPLEMENTATION = "activiti-servicetask-missing-implementation";
        public static readonly string SERVICE_TASK_WEBSERVICE_INVALID_OPERATION_REF = "activiti-servicetask-webservice-invalid-operation-ref";

        public static readonly string SEND_TASK_INVALID_IMPLEMENTATION = "activiti-sendtask-invalid-implementation";
        public static readonly string SEND_TASK_INVALID_TYPE = "activiti-sendtask-invalid-type";
        public static readonly string SEND_TASK_WEBSERVICE_INVALID_OPERATION_REF = "activiti-send-webservice-invalid-operation-ref";

        public static readonly string SCRIPT_TASK_MISSING_SCRIPT = "activiti-scripttask-missing-script";

        public static readonly string MAIL_TASK_NO_RECIPIENT = "activiti-mailtask-no-recipient";
        public static readonly string MAIL_TASK_NO_CONTENT = "activiti-mailtask-no-content";

        public static readonly string SHELL_TASK_NO_COMMAND = "activiti-shelltask-no-command";
        public static readonly string SHELL_TASK_INVALID_PARAM = "activiti-shelltask-invalid-param";

        public static readonly string DMN_TASK_NO_KEY = "activiti-dmntask-no-decision-table-key";

        public static readonly string EXCLUSIVE_GATEWAY_NO_OUTGOING_SEQ_FLOW = "activiti-exclusive-gateway-no-outgoing-seq-flow";
        public static readonly string EXCLUSIVE_GATEWAY_CONDITION_NOT_ALLOWED_ON_SINGLE_SEQ_FLOW = "activiti-exclusive-gateway-condition-not-allowed-on-single-seq-flow";
        public static readonly string EXCLUSIVE_GATEWAY_CONDITION_ON_DEFAULT_SEQ_FLOW = "activiti-exclusive-gateway-condition-on-seq-flow";
        public static readonly string EXCLUSIVE_GATEWAY_SEQ_FLOW_WITHOUT_CONDITIONS = "activiti-exclusive-gateway-seq-flow-without-conditions";

        public static readonly string EVENT_GATEWAY_ONLY_CONNECTED_TO_INTERMEDIATE_EVENTS = "activiti-event-gateway-only-connected-to-intermediate-events";

        public static readonly string BPMN_MODEL_TARGET_NAMESPACE_TOO_LONG = "activiti-bpmn-model-target-namespace-too-long";

        public static readonly string PROCESS_DEFINITION_ID_TOO_LONG = "activiti-process-definition-id-too-long";
        public static readonly string PROCESS_DEFINITION_NAME_TOO_LONG = "activiti-process-definition-name-too-long";
        public static readonly string PROCESS_DEFINITION_DOCUMENTATION_TOO_LONG = "activiti-process-definition-documentation-too-long";

        public static readonly string FLOW_ELEMENT_ID_TOO_LONG = "activiti-flow-element-id-too-long";

        public static readonly string SUBPROCESS_MULTIPLE_START_EVENTS = "activiti-subprocess-multiple-start-event";

        public static readonly string SUBPROCESS_START_EVENT_EVENT_DEFINITION_NOT_ALLOWED = "activiti-subprocess-start-event-event-definition-not-allowed";

        public static readonly string EVENT_SUBPROCESS_INVALID_START_EVENT_DEFINITION = "activiti-event-subprocess-invalid-start-event-definition";

        public static readonly string BOUNDARY_EVENT_NO_EVENT_DEFINITION = "activiti-boundary-event-no-event-definition";
        public static readonly string BOUNDARY_EVENT_INVALID_EVENT_DEFINITION = "activiti-boundary-event-invalid-event-definition";
        public static readonly string BOUNDARY_EVENT_CANCEL_ONLY_ON_TRANSACTION = "activiti-boundary-event-cancel-only-on-transaction";
        public static readonly string BOUNDARY_EVENT_MULTIPLE_CANCEL_ON_TRANSACTION = "activiti-boundary-event-multiple-cancel-on-transaction";

        public static readonly string INTERMEDIATE_CATCH_EVENT_NO_EVENTDEFINITION = "activiti-intermediate-catch-event-no-eventdefinition";
        public static readonly string INTERMEDIATE_CATCH_EVENT_INVALID_EVENTDEFINITION = "activiti-intermediate-catch-event-invalid-eventdefinition";

        public static readonly string ERROR_MISSING_ERROR_CODE = "activiti-error-missing-error-code";
        public static readonly string EVENT_MISSING_ERROR_CODE = "activiti-event-missing-error-code";
        public static readonly string EVENT_TIMER_MISSING_CONFIGURATION = "activiti-event-timer-missing-configuration";

        public static readonly string THROW_EVENT_INVALID_EVENTDEFINITION = "activiti-throw-event-invalid-eventdefinition";

        public static readonly string MULTI_INSTANCE_MISSING_COLLECTION = "activiti-multi-instance-missing-collection";

        public static readonly string MESSAGE_MISSING_NAME = "activiti-message-missing-name";
        public static readonly string MESSAGE_INVALID_ITEM_REF = "activiti-message-invalid-item-ref";
        public static readonly string MESSAGE_EVENT_MISSING_MESSAGE_REF = "activiti-message-event-missing-message-ref";
        public static readonly string MESSAGE_EVENT_INVALID_MESSAGE_REF = "activiti-message-event-invalid-message-ref";
        public static readonly string MESSAGE_EVENT_MULTIPLE_ON_BOUNDARY_SAME_MESSAGE_ID = "activiti-message-event-multiple-on-boundary-same-message-id";

        public static readonly string OPERATION_INVALID_IN_MESSAGE_REFERENCE = "activiti-operation-invalid-in-message-reference";

        public static readonly string SIGNAL_EVENT_MISSING_SIGNAL_REF = "activiti-signal-event-missing-signal-ref";
        public static readonly string SIGNAL_EVENT_INVALID_SIGNAL_REF = "activiti-signal-event-invalid-signal-ref";

        public static readonly string COMPENSATE_EVENT_INVALID_ACTIVITY_REF = "activiti-compensate-event-invalid-activity-ref";
        public static readonly string COMPENSATE_EVENT_MULTIPLE_ON_BOUNDARY = "activiti-compensate-event-multiple-on-boundary";

        public static readonly string SIGNAL_MISSING_ID = "activiti-signal-missing-id";
        public static readonly string SIGNAL_MISSING_NAME = "activiti-signal-missing-name";
        public static readonly string SIGNAL_DUPLICATE_NAME = "activiti-signal-duplicate-name";
        public static readonly string SIGNAL_INVALID_SCOPE = "activiti-signal-invalid-scope";

        public static readonly string DATA_ASSOCIATION_MISSING_TARGETREF = "activiti-data-association-missing-targetref";

        public static readonly string DATA_OBJECT_MISSING_NAME = "activiti-data-object-missing-name";

        public static readonly string END_EVENT_CANCEL_ONLY_INSIDE_TRANSACTION = "activiti-end-event-cancel-only-inside-transaction";

        public static readonly string DI_INVALID_REFERENCE = "activiti-di-invalid-reference";
        public static readonly string DI_DOES_NOT_REFERENCE_FLOWNODE = "activiti-di-does-not-reference-flownode";
        public static readonly string DI_DOES_NOT_REFERENCE_SEQ_FLOW = "activiti-di-does-not-reference-seq-flow";

    }
}
