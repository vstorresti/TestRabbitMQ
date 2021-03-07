using System;

namespace Faces.SharedLib.Messaging.InterfacesConstants.Commands
{
    public interface IRegisterOrderCommand
    {
        Guid OrderId { get; set; }
        string PictureUrl {get; set;}
        string UserEmail { get; set;}
        byte[] ImageData {get; set;}
    }
}