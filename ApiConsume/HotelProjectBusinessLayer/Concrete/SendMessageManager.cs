using HotelProjectBusinessLayer.Abstract;
using HotelProjectDataAccessLayer.Abstract;
using HotelProjectEntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelProjectBusinessLayer.Concrete
{
    public class SendMessageManager : ISendMessageService
    {
        private readonly ISendMessageDal _sendMessageDal;

        public SendMessageManager(ISendMessageDal sendMessageDal)
        {
            _sendMessageDal = sendMessageDal;
        }

        public void TDelete(SendMessage t)
        {
            _sendMessageDal.Delete(t);
        }

        public SendMessage TGetByID(int id)
        {
            return _sendMessageDal.GetByID(id);
        }

        public List<SendMessage> TGetList()
        {
           return _sendMessageDal.GetList();
        }

        public void TInsert(SendMessage t)
        {
            _sendMessageDal.Insert(t);
        }

        public void TUpdate(SendMessage t)
        {
            _sendMessageDal.Update(t);
        }

        int ISendMessageService.TGetSendMessageCount()
        {
           return _sendMessageDal.GetSendMessageCount();
        }
    }
}
