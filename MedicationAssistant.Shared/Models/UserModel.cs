using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace MedicationAssistant.Data
{
    public class UserModel
    {  // will be provider from the Azure B2c service
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public string Id { get; set; }

        public virtual ICollection<PrescriptionModel> Medications { get; set; }

        public virtual ICollection<AlertModel> Alerts { get; set; }

        public UserModel()
        {
            Medications = new List<PrescriptionModel>();
            Alerts = new List<AlertModel>();
        }
    }
}
