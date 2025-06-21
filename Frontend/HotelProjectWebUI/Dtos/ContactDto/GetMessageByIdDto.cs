using System;

namespace HotelProjectWebUI.Dtos.ContactDto
{
    public class GetMessageByIdDto
    {

        public int SendMessageId { get; set; }
        public string RecevierName { get; set; }
        public string RecevierMail { get; set; }
        public string SenderName { get; set; }
        public string SenderMail { get; set; }
        public string Content { get; set; }
        public string Title { get; set; }


        public DateTime Date { get; set; }
    }
}
