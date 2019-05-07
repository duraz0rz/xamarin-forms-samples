using System.Collections.Generic;

namespace Phoneword.SharedProject.Models
{
    public static class AppModel
    {
        static List<string> phoneNumbers;

        public static List<string> PhoneNumbers
        {
            get
            {
                if (phoneNumbers == null)
                {
                    phoneNumbers = new List<string>();
                }
                return phoneNumbers;
            }
            set
            {
                phoneNumbers = value;
            }
        }
    }
}
