namespace VueTOView.Common
{
    public enum Environment : int
    {
        /// <summary>
        /// To use if no specific environment is defined.
        /// </summary>
        None = 0,

        /// <summary>
        /// Represents the Live environment.
        /// </summary>
        Live = 1,

        /// <summary>
        /// Represents the Test environment.
        /// </summary>
        Test = 2,

        /// <summary>
        /// Represents the Edu environment.
        /// </summary>
        Edu = 3,

        /// <summary>
        /// Represents the Local environment.
        /// </summary>
        Local = 4,
    }
}
