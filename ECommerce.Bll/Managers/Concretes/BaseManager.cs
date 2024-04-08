using ECommerce.BLL.Managers.Abstracts;
using ECommerce.DAL.Repositories.Abstracts;
using ECommerce.ENTITIES.CoreInterfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using ECommerce.BLL.Managers.Abstracts;

namespace ECommerce.BLL.Managers.Concretes
{
    public class BaseManager<T> : IManager<T> where T : class,IEntity
    {
        // Bu class Repository ile birlikte çalışmak istiyor.
        IRepository<T> _iRep;

        // Dependemcy injection(Middleware) den instance alınarak buraya enjekte edilir. IOC kısmı RepositoryServices tarafından yapılır.
        public BaseManager(IRepository<T> iRep) // Burada dikkat ederseniz BaseManager Constructer'ı bir parametre alıyor(IRepository<T> tipinde) IOC(Inversion of Controls) paternine göre burada belirtilen tip Middleware'de görülürse bize instance'ı alınabilecek bir şey gönderilir... Bizim istediğimiz IRepository<T> generic tipi algılandığı anda BaseRepository instance'i gönderilecektir... Bu yüzdendir ki BaseRepository'i Abstract yapmadık...
        {
            _iRep = iRep;
        }

        public void Save()
        {
            _iRep.Save();
        }
        public virtual string Add(T item)
        {       
            _iRep.Add(item);
            return "Ekleme Başarılıdır";
        }

        public string AddRange(List<T> list)
        {
            if (!ElemanKontrol(list)) return "Maksium 10 veri ekleyebileceğiniz için işlem gerçekleştirilemedi";
            _iRep.AddRange(list);
            return "Ekleme başarılı bir şekilde gerçekleştirildi";
        }
        bool ElemanKontrol(List<T> list)
        {
            if (list.Count > 10) return false;
            return true;
        }

        public void Delete(T item)
        {
            if (item.CreatedDate == default)
            {
                return;
            }
            _iRep.Delete(item);
        }

        public void DeleteRange(List<T> list)
        {
            _iRep.DeleteRange(list);
        }

        public string Destroy(T item)
        {
            if (item.Status == ENTITIES.Enums.DataStatus.Deleted)
            {
                _iRep.Destroy(item);
                return "Veri başarıyla yok edildi";
            }
            return $"Veriyi silemezsiniz cünkü {item.ID} {item.Status} pasif değil";
        }

        public string DestroyRange(List<T> list)
        {           
            foreach (T item in list)
            {
                return Destroy(item);
            }
            return "Silme işleminde bir sorunla karşılaşıldı lütfen veri durumunun pasif olduğundan emin olunuz";
        }

        public List<T> GetActives()
        {
            return _iRep.GetActives();
        }

        public List<T> GetAll()
        {
            return _iRep.GetAll();
        }

        public List<T> GetModifieds()
        {
            return _iRep.GetModifieds();
        }

        public List<T> GetPassives()
        {
            return _iRep.GetPassives();
        }
        public List<T> Where(Expression<Func<T, bool>> exp)
        {
            return _iRep.Where(exp);
        }

        List<T> IManager<T>.GetAll()
        {
            throw new NotImplementedException();
        }

        List<T> IManager<T>.GetActives()
        {
            throw new NotImplementedException();
        }

        List<T> IManager<T>.GetPassives()
        {
            throw new NotImplementedException();
        }

        List<T> IManager<T>.GetModifieds()
        {
            throw new NotImplementedException();
        }

        List<T> IManager<T>.Where(Expression<Func<T, bool>> exp)
        {
            throw new NotImplementedException();
        }

        void IManager<T>.Add(T item)
        {
            throw new NotImplementedException();
        }

        void IManager<T>.AddRange(List<T> list)
        {
            throw new NotImplementedException();
        }

        void IManager<T>.Delete(T item)
        {
            throw new NotImplementedException();
        }

        void IManager<T>.DeleteRange(List<T> list)
        {
            throw new NotImplementedException();
        }

        void IManager<T>.Destroy(T item)
        {
            throw new NotImplementedException();
        }

        void IManager<T>.DestroyRange(List<T> list)
        {
            throw new NotImplementedException();
        }
    }
}
