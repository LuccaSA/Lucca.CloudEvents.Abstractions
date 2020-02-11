using CloudNative.CloudEvents;

namespace Lucca.CloudEvents.Abstractions
{
    public interface ICloudEventAccessor
    {
        CloudEvent CloudEvent { get; set; }
    }
}
