namespace GYG.RestAbstract.Models.Responses
{
    using System.Collections.Generic;
    using System.Linq;
    using Constants;
    using DTOs;

    public class BaseResponse
    {
        public bool HasError => Messages.Any(m => m.Type == BaseConstants.MessageTypes.Error);

        public List<MessageDto> Messages { get; set; }

        public BaseResponse()
        {
            Messages = new List<MessageDto>();
        }

        public void AddErrorMessage(string content)
        {
            AddMessage(content, BaseConstants.MessageTypes.Error);
        }

        public void AddInfoMessage(string content)
        {
            AddMessage(content, BaseConstants.MessageTypes.Info);
        }

        public void AddSuccessMessage(string content)
        {
            AddMessage(content, BaseConstants.MessageTypes.Success);
        }

        public void AddWarningMessage(string content)
        {
            AddMessage(content, BaseConstants.MessageTypes.Warning);
        }

        private void AddMessage(string content, string type)
        {
            Messages.Add(new MessageDto(content, type));
        }
    }
}
