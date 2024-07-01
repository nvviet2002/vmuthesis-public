namespace BE_thesis.Data
{
    public class ApiResponse
    {
        private static ApiResponse _instance;
        public static ApiResponse Instance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = new ApiResponse();
                }
                return _instance;
            }
        }
        public int Code { get; set; }
        public string Message { get; set; }
        public object? Data { get; set; }
        public ApiResponse(int code, string message, object? data)
        {
            Code = code;
            Message = message;
            Data = data;
        }
        public ApiResponse() { }

        public ApiResponse Response(int code, string message, object? data)
        {
            Instance.Code = code;
            Instance.Message = message;
            Instance.Data = data;
            return Instance;
        }


    }
}
