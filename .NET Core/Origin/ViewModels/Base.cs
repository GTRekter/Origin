namespace Origin.ViewModels
{
    public class Base
    {
        /// <summary>
        /// Constructor
        /// </summary>
        public Base()
        {
            ResultInfo = new ResultInfoDto
            {
                Result = ResultInfoDto.ResultEnum.Success
            };
        }

        /// <summary>
        /// Class which contains the information about the operation exit
        /// </summary>
        public ResultInfoDto ResultInfo { get; set; }

        public class ResultInfoDto
        {
            public enum ResultEnum
            {
                Success = 0,
                Error = 1,
                Unauthorized = 100,
                PermissionDenied = 101,
                YubikTokenExpired = 200
            }

            /// <summary>
            /// Error type
            /// </summary>
            public ResultEnum Result { get; set; }

            /// <summary>
            /// Error message
            /// </summary>
            public string ErrorMessage { get; set; }

        }
    }
}
