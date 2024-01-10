namespace Helper.CommonModels
{
    public class CommonEnums
    {
        public enum UserType
        {
            Admin = 1,
            Tutor,
            Student
        }

        public enum TimeZone
        {
            UK = 1,
            China
        }

        public enum Localization
        {
            English = 1,
            Chinese
        }

        public enum PlatformPreference
        {
            Zoom = 1,
            Zhumu,
            Other
        }
    }
}
