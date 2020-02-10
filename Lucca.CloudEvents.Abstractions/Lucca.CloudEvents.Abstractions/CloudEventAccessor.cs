using CloudNative.CloudEvents;
using System.Threading;

namespace Lucca.CloudEvents.Abstractions
{
    public class CloudEventAccessor
    {
        private static readonly AsyncLocal<CloudEventHolder> _cloudEventCurrent = new AsyncLocal<CloudEventHolder>();

        public CloudEvent Cloudevent
        {
            get
            {
                return _cloudEventCurrent.Value?.CloudEvent;
            }
            set
            {
                var holder = _cloudEventCurrent.Value;
                if (holder != null)
                {
                    holder.CloudEvent = null;
                }
                if (value != null)
                {
                    _cloudEventCurrent.Value = new CloudEventHolder { CloudEvent = value };
                }
            }
        }

        private class CloudEventHolder
        {
            public CloudEvent CloudEvent;
        }
    }
}
