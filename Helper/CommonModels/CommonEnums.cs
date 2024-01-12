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

        public enum CourseType
        {
            LongTermCourse = 1,
            ShortTermCourse,
            UniversityCourse,
            SpecialCourse
        }

        public enum CourseStatus
        {
            Ongoing = 1,
            Pending,
            Completed
        }
    }
}
