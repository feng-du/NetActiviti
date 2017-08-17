using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NetActiviti.BPMN.Model
{
    public class UserTask : Task
    {

        private string assignee;
        private string owner;
        private string priority;
        private string formKey;
        private string dueDate;
        private string businessCalendarName;
        private string category;
        private string extensionId;
        private List<string> candidateUsers = new List<string>();
        private List<string> candidateGroups = new List<string>();
        private List<FormProperty> formProperties = new List<FormProperty>();
        private List<ActivitiListener> taskListeners = new List<ActivitiListener>();
        private string skipExpression;

        private Dictionary<string, HashSet<string>> customUserIdentityLinks = new Dictionary<string, HashSet<string>>();
        private Dictionary<string, HashSet<string>> customGroupIdentityLinks = new Dictionary<string, HashSet<string>>();

        private List<CustomProperty> customProperties = new List<CustomProperty>();

        public string Assignee
        {
            get { return assignee; }
            set { assignee = value; }
        }


        public string Owner
        {
            get { return owner; }
            set { owner = value; }
        }


        public string Priority
        {
            get { return priority; }
            set { priority = value; }
        }


        public string FormKey
        {
            get { return formKey; }
            set { formKey = value; }
        }


        public string DueDate
        {
            get { return dueDate; }
            set { dueDate = value; }
        }


        public string BusinessCalendarName
        {
            get { return businessCalendarName; }
            set { businessCalendarName = value; }
        }


        public string Category
        {
            get { return category; }
            set { category = value; }
        }


        public string ExtensionId
        {
            get { return extensionId; }
            set { extensionId = value; }
        }


        public bool IsExtended
        {
            get { return !string.IsNullOrEmpty(extensionId); }
        }

        public List<string> CandidateUsers
        {
            get { return candidateUsers; }
            set { candidateUsers = value == null ? new List<string>() : value; }
        }


        public List<string> CandidateGroups
        {
            get { return candidateGroups; }
            set { candidateGroups = value == null ? new List<string>() : value; }
        }


        public List<FormProperty> FormProperties
        {
            get { return formProperties; }
            set { formProperties = value == null ? new List<FormProperty>() : value; }
        }


        public List<ActivitiListener> TaskListeners
        {
            get { return taskListeners; }
            set { taskListeners = value == null ? new List<ActivitiListener>() : value; }
        }


        public void AddCustomUserIdentityLink(string userId, string type)
        {
            HashSet<string> userIdentitySet = null;

            if (!customUserIdentityLinks.ContainsKey(type))
            {
                userIdentitySet = new HashSet<string>();
                customUserIdentityLinks.Add(type, userIdentitySet);
            }

            customUserIdentityLinks[type].Add(userId);
        }

        public void AddCustomGroupIdentityLink(string groupId, string type)
        {
            HashSet<string> groupIdentitySet = null;

            if (!customGroupIdentityLinks.ContainsKey(type))
            {
                groupIdentitySet = new HashSet<string>();
                customGroupIdentityLinks.Add(type, groupIdentitySet);
            }

            customGroupIdentityLinks[type].Add(groupId);
        }

        public Dictionary<string, HashSet<string>> CustomUserIdentityLinks
        {
            get { return customUserIdentityLinks; }
            set { customUserIdentityLinks = value == null ? new Dictionary<string, HashSet<string>>() : value; }
        }


        public Dictionary<string, HashSet<string>> CustomGroupIdentityLinks
        {
            get { return customGroupIdentityLinks; }
            set { customGroupIdentityLinks = value == null ? new Dictionary<string, HashSet<string>>() : value; }
        }


        public List<CustomProperty> CustomProperties
        {
            get { return customProperties; }
            set { customProperties = value == null ? new List<CustomProperty>() : value; }
        }

        public string SkipExpression
        {
            get { return skipExpression; }
            set { skipExpression = value; }
        }


        public override BaseElement Clone()
        {
            UserTask clone = new UserTask();
            clone.SetValues(this);
            return clone;
        }

        public void SetValues(UserTask otherElement)
        {
            base.SetValues(otherElement);
            assignee = otherElement.Assignee;
            owner = otherElement.Owner;
            formKey = otherElement.FormKey;
            dueDate = otherElement.DueDate;
            priority = otherElement.Priority;
            category = otherElement.Category;
            extensionId = otherElement.ExtensionId;
            skipExpression = otherElement.SkipExpression;

            candidateGroups = new List<string>(otherElement.CandidateGroups);
            candidateUsers = new List<string>(otherElement.CandidateUsers);

            customGroupIdentityLinks = otherElement.CustomGroupIdentityLinks;
            customUserIdentityLinks = otherElement.CustomUserIdentityLinks;

            formProperties = new List<FormProperty>();
            if (otherElement.FormProperties != null && otherElement.FormProperties.Count > 0)
            {
                foreach (FormProperty property in otherElement.FormProperties)
                {
                    formProperties.Add((FormProperty)property.Clone());
                }
            }

            taskListeners = new List<ActivitiListener>();
            if (otherElement.TaskListeners != null && otherElement.TaskListeners.Count > 0)
            {
                foreach (ActivitiListener listener in otherElement.TaskListeners)
                {
                    taskListeners.Add((ActivitiListener)listener.Clone());
                }
            }
        }
    }
}
