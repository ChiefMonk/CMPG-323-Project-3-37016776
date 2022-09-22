using System.ComponentModel.DataAnnotations;

namespace Project3.DeviceManagement.Shared.Dtos
{
	/// <summary>
	/// 
	/// </summary>
	/// <seealso cref="Dto" />
	/// <seealso cref="IDto" />
	public class DtoZone : Dto, IDto
	{
		/// <summary>
		/// Gets or sets the name of the zone.
		/// </summary>
		/// <value>
		/// The name of the zone.
		/// </value>
		[Required(ErrorMessage = "Zone Name is required")] 
		public string ZoneName { get; set; }
		/// <summary>
		/// Gets or sets the zone description.
		/// </summary>
		/// <value>
		/// The zone description.
		/// </value>
		[Required(ErrorMessage = "Zone Description is required")] 
		public string ZoneDescription { get; set; }
	}
}