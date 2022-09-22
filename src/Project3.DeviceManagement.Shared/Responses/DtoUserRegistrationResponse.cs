using Project3.DeviceManagement.Shared.Dtos;

namespace Project3.DeviceManagement.Shared.Responses
{

    /// <summary>
    /// 
    /// </summary>
    public class DtoUserRegistrationResponse
    {
        /// <summary>
        /// Gets or sets the user.
        /// </summary>
        /// <value>
        /// The user.
        /// </value>
        public DtoSystemUser User { get; set; }

        /// <summary>
        /// Gets or sets the message.
        /// </summary>
        /// <value>
        /// The message.
        /// </value>
        public string Message { get; set; }
    }
}