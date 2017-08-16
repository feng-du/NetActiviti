using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NetActiviti.BPMN.Model
{
    public abstract class Activity : FlowNode
    {

        private string failedJobRetryTimeCycleValue;
        public string FailedJobRetryTimeCycleValue
        {
            get { return failedJobRetryTimeCycleValue; }
            set { failedJobRetryTimeCycleValue = value; }
        }

        private bool forCompensation;
        public bool ForCompensation
        {
            get { return forCompensation; }
            set { forCompensation = value; }
        }

        private List<BoundaryEvent> boundaryEvents = new List<BoundaryEvent>();
        public List<BoundaryEvent> BoundaryEvents
        {
            get { return boundaryEvents; }
            set { boundaryEvents = value == null ? new List<BoundaryEvent>() : value; }
        }


        private string defaultFlow;
        public string DefaultFlow
        {
            get { return defaultFlow; }
            set { defaultFlow = value; }
        }

        private MultiInstanceLoopCharacteristics loopCharacteristics;
        public MultiInstanceLoopCharacteristics LoopCharacteristics
        {
            get { return loopCharacteristics; }
            set { loopCharacteristics = value; }
        }



        public bool HasMultiInstanceLoopCharacteristics()
        {
            return LoopCharacteristics != null;
        }

        private IOSpecification ioSpecification;
        public IOSpecification IoSpecification
        {
            get { return ioSpecification; }
            set { ioSpecification = value; }
        }


        private List<DataAssociation> dataInputAssociations = new List<DataAssociation>();
        public List<DataAssociation> DataInputAssociations
        {
            get { return dataInputAssociations; }
            set { dataInputAssociations = value == null ? new List<DataAssociation>() : value; }
        }

        public void setDataInputAssociations(List<DataAssociation> dataInputAssociations)
        {
            this.dataInputAssociations = dataInputAssociations;
        }

        private List<DataAssociation> dataOutputAssociations = new List<DataAssociation>();
        public List<DataAssociation> DataOutputAssociations
        {
            get { return dataOutputAssociations; }
            set { dataOutputAssociations = value == null ? new List<DataAssociation>() : value; }
        }

        private List<MapExceptionEntry> mapExceptions = new List<MapExceptionEntry>();
        public List<MapExceptionEntry> MapExceptions
        {
            get { return mapExceptions; }
            set { mapExceptions = value == null ? new List<MapExceptionEntry>() : value; }
        }


        public void SetValues(Activity otherActivity)
        {
            base.SetValues(otherActivity);
            failedJobRetryTimeCycleValue = otherActivity.FailedJobRetryTimeCycleValue;
            defaultFlow = otherActivity.DefaultFlow;
            forCompensation = otherActivity.ForCompensation;
            if (otherActivity.LoopCharacteristics != null)
            {
                loopCharacteristics = (MultiInstanceLoopCharacteristics)otherActivity.LoopCharacteristics.Clone();
            }
            if (otherActivity.IoSpecification != null)
            {
                ioSpecification = (IOSpecification)otherActivity.IoSpecification.Clone();
            }

            dataInputAssociations = new List<DataAssociation>();
            if (otherActivity.DataInputAssociations != null && otherActivity.DataInputAssociations.Count > 0)
            {
                foreach (DataAssociation association in otherActivity.DataInputAssociations)
                {
                    dataInputAssociations.Add((DataAssociation)association.Clone());
                }
            }

            dataOutputAssociations = new List<DataAssociation>();
            if (otherActivity.DataOutputAssociations != null && otherActivity.DataOutputAssociations.Count > 0)
            {
                foreach (DataAssociation association in otherActivity.DataOutputAssociations)
                {
                    dataOutputAssociations.Add((DataAssociation)association.Clone());
                }
            }

            boundaryEvents.Clear();
            foreach (BoundaryEvent _event in otherActivity.BoundaryEvents)
            {
                boundaryEvents.Add(_event);
            }
        }
    }
}
