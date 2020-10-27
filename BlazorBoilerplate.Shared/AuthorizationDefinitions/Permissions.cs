using System.ComponentModel;

namespace BlazorBoilerplate.Shared.AuthorizationDefinitions
{
    public static class Actions
    {
        public const string Create = nameof(Create);
        public const string Read = nameof(Read);
        public const string Update = nameof(Update);
        public const string Delete = nameof(Delete);
    }

    public static class Permissions
    {
        public static class Todo
        {
            [Description("Create a new ToDo")]
            public const string Create = nameof(Todo) + "." + nameof(Actions.Create);
            [Description("Read ToDos")]
            public const string Read = nameof(Todo) + "." + nameof(Actions.Read);
            [Description("Edit existing ToDos")]
            public const string Update = nameof(Todo) + "." + nameof(Actions.Update);
            [Description("Delete any ToDo")]
            public const string Delete = nameof(Todo) + "." + nameof(Actions.Delete);
        }

        public static class Quiz
        {
            [Description("Create a new Quiz")]
            public const string Create = nameof(Quiz) + "." + nameof(Actions.Create);
            [Description("Read Quizzes")]
            public const string Read = nameof(Quiz) + "." + nameof(Actions.Read);
            [Description("Edit existing Quizzes")]
            public const string Update = nameof(Quiz) + "." + nameof(Actions.Update);
            [Description("Delete any Quizzes")]
            public const string Delete = nameof(Quiz) + "." + nameof(Actions.Delete);
        }

        public static class ScienceDirection
        {
            [Description("Create a new ScienceDirection")]
            public const string Create = nameof(ScienceDirection) + "." + nameof(Actions.Create);
            [Description("Read ScienceDirections")]
            public const string Read = nameof(ScienceDirection) + "." + nameof(Actions.Read);
            [Description("Edit existing ScienceDirections")]
            public const string Update = nameof(ScienceDirection) + "." + nameof(Actions.Update);
            [Description("Delete any ScienceDirections")]
            public const string Delete = nameof(ScienceDirection) + "." + nameof(Actions.Delete);
        }

        public static class ContentFile
        {
            [Description("Create a new ContentFile")]
            public const string Create = nameof(ContentFile) + "." + nameof(Actions.Create);
            [Description("Read ContentFile")]
            public const string Read = nameof(ContentFile) + "." + nameof(Actions.Read);
            [Description("Edit existing ContentFile")]
            public const string Update = nameof(ContentFile) + "." + nameof(Actions.Update);
            [Description("Delete any ContentFile")]
            public const string Delete = nameof(ContentFile) + "." + nameof(Actions.Delete);
        }

        public static class Course
        {
            [Description("Create a new Course")]
            public const string Create = nameof(Course) + "." + nameof(Actions.Create);
            [Description("Read ScienceDirections")]
            public const string Read = nameof(Course) + "." + nameof(Actions.Read);
            [Description("Edit existing ScienceDirections")]
            public const string Update = nameof(Course) + "." + nameof(Actions.Update);
            [Description("Delete any ScienceDirections")]
            public const string Delete = nameof(Course) + "." + nameof(Actions.Delete);
        }

        public static class Text
        {
            [Description("Create a new Text")]
            public const string Create = nameof(Text) + "." + nameof(Actions.Create);
            [Description("Read Texts")]
            public const string Read = nameof(Text) + "." + nameof(Actions.Read);
            [Description("Edit existing Texts")]
            public const string Update = nameof(Text) + "." + nameof(Actions.Update);
            [Description("Delete any Texts")]
            public const string Delete = nameof(Text) + "." + nameof(Actions.Delete);
        }
        public static class Role
        {
            [Description("Create a new Role")]
            public const string Create = nameof(Role) + "." + nameof(Actions.Create);
            [Description("Read roles data (permissions, etc.")]
            public const string Read = nameof(Role) + "." + nameof(Actions.Read);
            [Description("Edit existing Roles")]
            public const string Update = nameof(Role) + "." + nameof(Actions.Update);
            [Description("Delete any Role")]
            public const string Delete = nameof(Role) + "." + nameof(Actions.Delete);
        }
        public static class User
        {
            [Description("Create a new User")]
            public const string Create = nameof(User) + "." + nameof(Actions.Create);
            [Description("Read Users data (Names, Emails, Phone Numbers, etc.)")]
            public const string Read = nameof(User) + "." + nameof(Actions.Read);
            [Description("Edit existing users")]
            public const string Update = nameof(User) + "." + nameof(Actions.Update);
            [Description("Delete any user")]
            public const string Delete = nameof(User) + "." + nameof(Actions.Delete);
        }
        public static class WeatherForecasts
        {
            [Description("Read Weather Forecasts")]
            public const string Read = nameof(WeatherForecasts) + "." + nameof(Actions.Read);
        }
    }
}