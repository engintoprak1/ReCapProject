using Core.Entities.Concrete;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;

namespace Business.Constants
{
    public static class Messages
    {
        public static string MaintenanceTime = "Sistem bakımda";
        public static string CarAdded = "Araç eklendi";
        public static string CarDeleted = "Araç silindi";
        public static string CarsListed = "Araçlar listelendi";
        public static string CarUpdated = "Araç güncellendi";
        public static string CarBusy = "Araç şu an meşgul";

        public static string BrandAdded = "Marka eklendi";
        public static string BrandDeleted = "Marka silindi";
        public static string BrandsListed = "Markalar listelendi";
        public static string BrandUpdated = "Marka güncellendi";

        public static string ModelAdded = "Model eklendi";
        public static string ModelUpdated = "Model güncellendi";
        public static string ModelDeleted = "Model silindi";

        public static string ColorAdded = "Renk eklendi";
        public static string ColorDeleted = "Renk silindi";
        public static string ColorsListed = "Renkler listelendi";
        public static string ColorUpdated = "Renk güncellendi";

        public static string CustomerAdded = "Müşteri eklendi";
        public static string CustomerDeleted = "Müşteri silindi";
        public static string CustomerUpdated = "Müşteri güncellendi";
        public static string CustomersListed = "Müşteriler listelendi";

        public static string RentalAdded = "Kiralama başarılı";
        public static string RentalDeleted = "Kiralama iptal edildi";
        public static string RentalUpdated = "Kiralama bilgisi güncellendi";
        public static string RentalsListed = "Kiralama bilgisi listelendi";

        public static string UserAdded = "Kullanıcı eklendi";
        public static string UserUpdated = "Kullanıcı güncellendi";
        public static string UsersListed = "Kullanıcı listelendi";
        public static string UserDeleted = "Kullanıcı silindi";


        public static string CarImageLimitExceeded = "Fotoğraf sınırı aşıldı";
        public static string CarImageAdded = "Araç fotoğrafı eklendi";
        public static string CarImageDeleted = "Araç fotoğrafı silindi";
        public static string CarImageUpdated = "Araç fotoğrafı güncellendi";

        public static string AuthorizationDenied = "Yetkiniz yok";
        public static string UserRegistered = "Kullanıcı başarıyla kaydedildi";
        public static string UserNotFound = "Kullanıcı bulunamadı";
        public static string PasswordError = "Şifre hatalı";
        public static string SuccessfulLogin = "Sisteme giriş başarılı";
        public static string UserAlreadyExists = "Bu kullanıcı zaten mevcut";
        public static string AccessTokenCreated = "Access token başarıyla oluşturuldu";

        public static string CarNotExists = "Böyle bir araba mevcut değil";
    }
}
