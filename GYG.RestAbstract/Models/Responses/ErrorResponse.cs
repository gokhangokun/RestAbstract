﻿namespace GYG.RestAbstract.Models.Responses
{
    public class ErrorResponse : BaseResponse
    {
        public string ErrorCode { get; set; }

        public string AdditionalInfo { get; set; }
    }
}
