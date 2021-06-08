using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AssessmentThinkBridge.Models
{
    public class ItemModel
    {
		public int ItemID { get; set; }
		public string ItemName { get; set; }
		public string ItemDescriotion { get; set; }
		public int ItemQuentity { get; set; }
		public int ItemPrice { get; set; }
		public int ItemDiscountPercentage { get; set; }
		public string ItemImageUrl { get; set; }
		public bool IsActive { get; set; }
		public int CreatedBy { get; set; }
		public DateTime CreatedDate { get; set; }
		public int? UpdateBy { get; set; }
		public DateTime? UpdatedDate { get; set; }
	}
}
